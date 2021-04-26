using CurrencyExchange.Models.UIModels;
using System.Threading.Tasks;

namespace CurrencyExchange.Contracts.UseCases
{
    public interface IGetWeatherUseCase
    {
        Task<WeatherUi> GetWeatherByLocation(double lat, double lon);
    }
}
