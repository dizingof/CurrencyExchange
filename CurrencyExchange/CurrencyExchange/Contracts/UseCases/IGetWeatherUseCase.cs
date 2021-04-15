using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyExchange.Contracts.UseCases
{
    public interface IGetWeatherUseCase
    {
        Task GetWeatherByLocation(decimal lat, decimal lon);
    }
}
