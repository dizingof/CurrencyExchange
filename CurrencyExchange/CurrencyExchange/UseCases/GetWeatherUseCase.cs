using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace CurrencyExchange.UseCases
{
    public class GetWeatherUseCase
    {
        private readonly HttpClient _httpClient;

        public GetWeatherUseCase()
        {
            _httpClient = new HttpClient();
        }

        public void GetWeatherByLocation(decimal lat, decimal lon)
        {

        }
    }
}
