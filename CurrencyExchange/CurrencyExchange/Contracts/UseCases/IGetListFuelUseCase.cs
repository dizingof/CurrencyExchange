using CurrencyExchange.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CurrencyExchange.Contracts.UseCases
{
    public interface IGetListFuelUseCase
    {
        Task<List<Fuel>> GetGetCurrencyListFromRemoteResourceAsync(string rateName, string selector);
    }
}
