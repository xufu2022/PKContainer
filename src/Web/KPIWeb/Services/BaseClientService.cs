using System.Text.Json;
using KPIWeb.Configurations;
using KPIWeb.DTO;
using Microsoft.Extensions.Options;

namespace KPIWeb.Services
{

    public class BaseClientService
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<BaseClientService> _logger;

        public BaseClientService(HttpClient httpClient, ILogger<BaseClientService> logger, IOptions<HttpClientSettings> settings, IHttpContextAccessor httpContextAccessor)
        {
            _httpClient = httpClient;
            _logger = logger;
            _httpClient.BaseAddress =new Uri(settings.Value.KPIApiUri);
        }
        public async Task<TD> GetItem<TD>(string url) where TD : class
        {
            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            var returnItem = JsonSerializer.Deserialize<TD>(responseString, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
            return returnItem;
        }

        public async Task PostItem<TInput>(string url, TInput input)
            where TInput : class
        {
            var itemContent = new StringContent(JsonSerializer.Serialize(input), System.Text.Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(url, itemContent);
            if (response.StatusCode == System.Net.HttpStatusCode.InternalServerError)
            {
                throw new Exception($"Error update Item {nameof(TInput)}, try later.");
            }

            response.EnsureSuccessStatusCode();
        }

        public async Task<TOut> PostItem<TInput, TOut>(string url, TInput input)
            where TInput : class
            where TOut : BaseModelDto
        {
            var itemContent = new StringContent(JsonSerializer.Serialize(input), System.Text.Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(url, itemContent);
            if (response.StatusCode == System.Net.HttpStatusCode.InternalServerError)
            {
                throw new Exception($"Error update Item {nameof(TInput)}, try later.");
            }
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();

            var returnItem = JsonSerializer.Deserialize<TOut>(responseString, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
            return returnItem;

        }

        public async Task PutItem<TInput>(string url, TInput input) 
            where TInput: class
        {
            var itemContent = new StringContent(JsonSerializer.Serialize(input), System.Text.Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync(url, itemContent);
            if (response.StatusCode == System.Net.HttpStatusCode.InternalServerError)
            {
                throw new Exception($"Error update Item {nameof(TInput)}, try later.");
            }

            response.EnsureSuccessStatusCode();
        }

        public async Task<TOut> PutItem<TInput, TOut>(string url, TInput input)
            where TInput : class
            where TOut : BaseModelDto
        {
            var itemContent = new StringContent(JsonSerializer.Serialize(input), System.Text.Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync(url, itemContent);
            if (response.StatusCode == System.Net.HttpStatusCode.InternalServerError)
            {
                throw new Exception($"Error update Item {nameof(TInput)}, try later.");
            }
            response.EnsureSuccessStatusCode();
            var responseString =await response.Content.ReadAsStringAsync();

            var returnItem = JsonSerializer.Deserialize<TOut>(responseString, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
            return returnItem;

        }



    }
}
