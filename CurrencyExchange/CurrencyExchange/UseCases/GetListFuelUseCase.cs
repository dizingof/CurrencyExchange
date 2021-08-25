using CurrencyExchange.Contracts.Querys;
using CurrencyExchange.Contracts.UseCases;
using CurrencyExchange.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace CurrencyExchange.UseCases
{
    public class GetListFuelUseCase : IGetListFuelUseCase
    {
        private readonly IFuelRatesQuery _fuelRatesQuery;
        private readonly HttpClient _httpClient;

        public GetListFuelUseCase(IFuelRatesQuery usdRatesQuery)
        {
            _fuelRatesQuery = usdRatesQuery;
            _httpClient = new HttpClient();
        }

        public async Task<List<Fuel>> GetGetCurrencyListFromRemoteResourceAsync(string rateName, string selector)
        {
            var response = await _httpClient.GetAsync(rateName);
            if (response != null && response.StatusCode == HttpStatusCode.OK)
            {
                var sourceHtmlDocument = await _fuelRatesQuery.GetSourceHtmlDocumentAsync(rateName);
                var outputString = _fuelRatesQuery.GetOutputStringAfterCssSelector(sourceHtmlDocument, selector);
                var getArrayFromOutput = _fuelRatesQuery.ConvertOutputStringToArrayHtmlString(outputString);
                var fuelList = await _fuelRatesQuery.CreateCurrencyListAsync(getArrayFromOutput);

                return fuelList;
            }
            else
            {
                throw new Exception($"Status code is {response.StatusCode}");
            }
        }
    }
}
