using Serilog.Events;

namespace KP.Serilog;

public class LoggingOptions
{
    public Dictionary<string, string> LogLevel { get; set; }
    public FileOptions? File { get; set; }
    public ElasticSearchOptions? Elasticsearch { get; set; }

    public DbLogOptions? DbLogOptions { get; set; }

}

public class DbLogOptions
{
    public string? ConnectionString { get; set; }
    public string? TableName { get; set; } = "Log";
}
public class FileOptions
{
    public LogEventLevel MinimumLogEventLevel { get; set; }
    public string FileName { get; set; } = "log";
}

public class ElasticSearchOptions
{
    public bool IsEnabled { get; set; }

    public string Host { get; set; }
    
    public string IndexFormat { get; set; }

    public LogEventLevel MinimumLogEventLevel { get; set; }
}

public class EventLogOptions
{
    public bool IsEnabled { get; set; }

    public string LogName { get; set; }

    public string SourceName { get; set; }
}