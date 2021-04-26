using CurrencyExchange.Constants;
using CurrencyExchange.Contracts.UseCases;
using CurrencyExchange.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
using CurrencyExchange.Models.UIModels;
using Microsoft.AspNetCore.Mvc;

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

        public async Task<WeatherUi> GetWeatherByLocation(double lat, double lon)
        {
            var apiWeatherToken = _configuration["WeatherApiToken:Key"];
            var urlWeatherApi = string.Format(Urls.AddressWeatherApi, lat, lon, apiWeatherToken);
            var response = await _httpClient.GetAsync(urlWeatherApi);
            var stringContent = response.Content.ReadAsStringAsync().Result;
            var weather = JsonConvert.DeserializeObject<WeatherFull>(stringContent);
            return new WeatherUi { Location = weather.name, Temperature = weather.main.temp };
        }
    }
}
