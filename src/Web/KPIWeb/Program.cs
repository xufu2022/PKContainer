using KPIWeb.Configurations;
using KPIWeb.Services;
using KPIWeb.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<HttpClientSettings>(builder.Configuration.GetSection("HttpClientSettings"));
builder.Services.Configure<WebApplicationSettings>(builder.Configuration.GetSection("WebApplicationSettings"));
builder.Services.AddHttpClient<IKPIApiService, KPIApiService>();
builder.Services.AddHttpClient<IMeasureService, MeasureService>();
builder.Services.AddHttpClient<IThemeService, ThemeService>();
builder.Services.AddHttpContextAccessor();

builder.Services.AddRazorPages().AddRazorPagesOptions(options =>
{
    options.Conventions.AddPageRoute("/home/index","");
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
