using KP.Grpc.Mapper;
using KP.GRPC.Services;
using KP.Infrastructure.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Additional configuration is required to successfully run gRPC on macOS.
// For instructions on how to configure Kestrel and gRPC clients on macOS, visit https://go.microsoft.com/fwlink/?linkid=2099682

// Add services to the container.
if (builder.Environment.IsDevelopment())
{
    builder.Configuration.AddUserSecrets<Program>();
    //TODO:
    //IdentityModelEventSource.ShowPII = true;
}
var connectionString1 = Environment.GetEnvironmentVariable("KpConnection");
string connectionString = builder.Configuration.GetConnectionString("KpConnection");
builder.Services.AddInfrastructure(connectionString, builder.Environment.IsDevelopment());

builder.Services.AddAutoMapper(typeof(KPGrpcProfile).Assembly);
builder.Services.AddGrpc();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapGrpcService<GreeterService>();
app.MapGrpcService<ThemeGrpcService>();
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();
