using KPIWeb.Services.Interfaces;
using Microsoft.Extensions.Options;

namespace KPIWeb.Services
{
    public class ThemeService : BaseClientService, IThemeService
    {


        public async Task<List<ThemeDto>> GetThemes() =>await GetItem<List<ThemeDto>>("Theme");
       
        public async Task<ThemeDto> GetById(int id) => await GetItem<ThemeDto>($"Theme/{id}");
       
        public ThemeService(HttpClient httpClient, ILogger<BaseClientService> logger, IOptions<HttpClientSettings> settings, IHttpContextAccessor httpContextAccessor) : base(httpClient, logger, settings, httpContextAccessor)
        {
        }
    }
}
