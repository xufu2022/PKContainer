using KPIWeb.Services.Interfaces;
using Microsoft.Extensions.Options;

namespace KPIWeb.Services
{
    public class MeasureService : BaseClientService, IMeasureService
    {
        //private readonly HttpClient _httpClient;

        //public MeasureService(HttpClient httpClient, IHttpContextAccessor httpContextAccessor)
        //{
        //    _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        //    if (httpContextAccessor.HttpContext != null)
        //    {
        //        _httpClient.DefaultRequestHeaders.Add("UserId",
        //            httpContextAccessor.HttpContext.User.Claims.First(x => x.Type == "sub").Value);
        //        _httpClient.DefaultRequestHeaders.Add("UserName",
        //            $"{httpContextAccessor.HttpContext.User.Claims.First(x => x.Type == "firstname").Value} {httpContextAccessor.HttpContext.User.Claims.First(x => x.Type == "lastname").Value}");
        //    }
        //}
        //public async Task<List<MeasureDto>> GetMeasures()
        //{
        //    HttpResponseMessage response = await _httpClient.GetAsync("Measure");
        //    response.EnsureSuccessStatusCode();
        //    return await response.Content.ReadAsAsync<List<MeasureDto>>();
        //}
        public MeasureService(HttpClient httpClient, ILogger<MeasureService> logger, IOptions<HttpClientSettings> settings, IHttpContextAccessor httpContextAccessor) : base(httpClient, logger, settings, httpContextAccessor)
        {
            var username = httpClient.DefaultRequestHeaders;

        }

        public async Task<List<MeasureDto>> GetMeasures() => await GetItem<List<MeasureDto>>("Measure");


    }
}
