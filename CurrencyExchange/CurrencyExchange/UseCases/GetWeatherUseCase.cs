using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using CurrencyExchange.Constants;

namespace CurrencyExchange.UseCases
{
    public class GetWeatherUseCase
    {
        private readonly HttpClient _httpClient;

        public GetWeatherUseCase()
        {
            _httpClient = new HttpClient();
        }

        public async Task GetWeatherByLocation(decimal lat, decimal lon)
        {
            var response = await _httpClient.GetAsync(Urls.AddressWeatherApi);
        }
    }
}
