using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CurrencyExchange.Models;

namespace CurrencyExchange.Contracts.UseCases
{
    public interface IGetListFuelUseCase
    {
        Task<List<Currency>> GetGetCurrencyListFromRemoteResourceAsync(string rateName, string selector);
    }
}
