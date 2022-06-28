using KPIWeb.Configurations;
using KPIWeb.DTO;
using KPIWeb.Services.Interfaces;
using Microsoft.Extensions.Options;

namespace KPIWeb.Services
{
    public class KPIApiService : BaseClientService, IKPIApiService
    {


        public async Task<List<KpiDto>> GetList()=> await GetItem<List<KpiDto>>("Kpi");
       

        public async Task<KpiDto> GetById(int id) => await GetItem<KpiDto>($"Kpi/{id}");
        

        public async Task<KpiDto> Update(int id, KpiDto item) => await PutItem<KpiDto, KpiDto>($"Kpi/{id}",item);
        
        public async Task<KpiDto> Create(KpiDto item) => await PostItem<KpiDto,KpiDto>($"Kpi", item);
        

        public KPIApiService(HttpClient httpClient, ILogger<BaseClientService> logger, IOptions<HttpClientSettings> settings, IHttpContextAccessor httpContextAccessor) : base(httpClient, logger, settings, httpContextAccessor)
        {
        }
    }
}