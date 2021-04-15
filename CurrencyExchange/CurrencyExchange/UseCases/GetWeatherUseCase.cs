using CurrencyExchange.Constants;
using System.Net.Http;
using System.Threading.Tasks;
using CurrencyExchange.Contracts.UseCases;
using Microsoft.Extensions.Configuration;

namespace CurrencyExchange.UseCases
{
    public class GetWeatherUseCase : IGetWeatherUseCase
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public GetWeatherUseCase(IConfiguration configuration)
        {
            _httpClient = new HttpClient();
            _configuration = configuration;
        }

        public async Task GetWeatherByLocation(decimal lat, decimal lon)
        {
            var apiWeatherToken = _configuration["WeatherApiToken:Key"];
            var urlWeatherApi = string.Format(Urls.AddressWeatherApi, lat, lon, apiWeatherToken);
            var response = await _httpClient.GetAsync(urlWeatherApi);
            var stringContent = response.Content.ReadAsStringAsync().Result;


        }
    }
}
