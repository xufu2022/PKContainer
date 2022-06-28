using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Elasticsearch.Net;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Core;
using Serilog.Events;
using Serilog.Exceptions;
using Serilog.Formatting.Json;
using Serilog.Sinks.Elasticsearch;
using Serilog.Sinks.File;
using Serilog.Sinks.MSSqlServer;

namespace KP.Serilog
{
    public static class CommonLogger
    {
        public static IWebHostBuilder AddCommonLog(this IWebHostBuilder builder, Func<IConfiguration, LoggingOptions> logOptions)
        {
            builder.ConfigureLogging((context, logging) =>
            {
                // logging.AddAzureWebAppDiagnostics();
                logging.AddSerilog();
                var options = SetDefault(logOptions(context.Configuration));
                context.HostingEnvironment.UseCommonLogger(options);
            });
            return builder;
        }
        private static void UseCommonLogger(this IHostEnvironment env, LoggingOptions options)
        {
            var assemblyName = Assembly.GetEntryAssembly()?.GetName().Name;
            var logsPath = Path.Combine(env.ContentRootPath, "logs");
            var loggerConfiguration = new LoggerConfiguration();

            if (options.DbLogOptions!=null && ! string.IsNullOrEmpty(options.DbLogOptions.ConnectionString))
            {
                loggerConfiguration = loggerConfiguration
                    .Enrich.FromLogContext()
                    .Enrich.WithMachineName()
                    .Enrich.WithProperty("Application", $"{assemblyName}-{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}")
                    .Enrich.WithExceptionDetails()
                    .WriteTo.MSSqlServer(options.DbLogOptions.ConnectionString, 
                        sinkOptions: new MSSqlServerSinkOptions { TableName = options.DbLogOptions.TableName }, 
                        columnOptions: new ColumnOptions
                        {
                            AdditionalColumns = new List<SqlColumn>
                            {
                                new SqlColumn
                                {
                                    AllowNull = true,
                                    DataType = SqlDbType.NVarChar,
                                    ColumnName = "Application"
                                },
                                new SqlColumn
                                {
                                    AllowNull = true,
                                    DataType = SqlDbType.NVarChar,
                                    ColumnName = "MachineName"
                                }
                            }
                        },
                        restrictedToMinimumLevel: GetLogEventLevel(options));
            }

            if (options.File !=null)
            {
                loggerConfiguration = loggerConfiguration
                    .WriteTo.File(Path.Combine(env.ContentRootPath, options.File.FileName),
                        fileSizeLimitBytes: 10 * 1024 * 1024,
                        rollOnFileSizeLimit: true,
                        shared: true,
                        flushToDiskInterval: TimeSpan.FromSeconds(1),
                        outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] [{SourceContext}] [TraceId: {TraceId}] {Message:lj}{NewLine}{Exception}",
                        restrictedToMinimumLevel: options.File.MinimumLogEventLevel);
            }
            if (options.Elasticsearch !=null && options.Elasticsearch.IsEnabled)
            {
                loggerConfiguration = loggerConfiguration
                    .WriteTo.Elasticsearch(new ElasticsearchSinkOptions(new Uri(options.Elasticsearch.Host))
                    {
                        MinimumLogEventLevel = options.Elasticsearch.MinimumLogEventLevel,
                        AutoRegisterTemplate = true,
                        AutoRegisterTemplateVersion = AutoRegisterTemplateVersion.ESv6,
                        IndexFormat = options.Elasticsearch.IndexFormat + "-{0:yyyy.MM.dd}",
                        // BufferBaseFilename = Path.Combine(env.ContentRootPath, "logs", "buffer"),
                        InlineFields = true,
                        EmitEventFailure = EmitEventFailureHandling.WriteToFailureSink,
                        FailureSink = new FileSink(Path.Combine(logsPath, "elasticsearch-failures.txt"), new JsonFormatter(), null),
                    });
            }


            Log.Logger = loggerConfiguration.CreateLogger();

        }
        private static LoggingOptions SetDefault(LoggingOptions options)
        {
            options ??= new LoggingOptions{};

            options.LogLevel ??= new Dictionary<string, string>();

            if (!options.LogLevel.ContainsKey("Default"))
            {
                options.LogLevel["Default"] = "Warning";
            }

            options.File ??= new FileOptions
            {
                MinimumLogEventLevel = LogEventLevel.Warning,
            };

            options.Elasticsearch ??= new ElasticSearchOptions
            {
                IsEnabled = false,
                MinimumLogEventLevel = LogEventLevel.Warning,
            };

            return options;
        }
        private static LogEventLevel GetLogEventLevel(LoggingOptions options)
        {
            string level = "Default";
            //log set in log configuration
            var matches = options.LogLevel.Keys;
            level = matches.Max()!;
            return (LogEventLevel)Enum.Parse(typeof(LogEventLevel), options.LogLevel[level], true);
        }
    }
}
