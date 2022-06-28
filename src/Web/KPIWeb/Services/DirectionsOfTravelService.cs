using KPIWeb.Services.Interfaces;
using Microsoft.Extensions.Options;

namespace KPIWeb.Services
{
    public class DirectionsOfTravelService : BaseClientService, IDirectionsOfTravelService
    {
        public DirectionsOfTravelService(HttpClient httpClient, ILogger<BaseClientService> logger, IOptions<HttpClientSettings> settings, IHttpContextAccessor httpContextAccessor) : base(httpClient, logger, settings, httpContextAccessor)
        {
        }

        public async Task<List<DirectionsOfTravelDto>> GetAllTravelDirections() => await GetItem<List<DirectionsOfTravelDto>>("DirectionsOfTravel");


        public async Task<DirectionsOfTravelDto> GetById(int id) => await GetItem<DirectionsOfTravelDto>($"DirectionsOfTravel/{id}");
        
    }
}
