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
    public class GetListCurrencyUseCase : IGetListCurrencyUseCase
    {
        private readonly IUsdRatesQuery _usdRatesQuery;
        private readonly HttpClient _httpClient;
        
        public GetListCurrencyUseCase(IUsdRatesQuery UsdRatesQuery)
        {
            _usdRatesQuery = UsdRatesQuery;
            _httpClient = new HttpClient();
        }

        public async Task<List<Currency>> GetGetCurrencyListFromRemoteResourceAsync(string rateName, string selector)
        {
            var response = await _httpClient.GetAsync(rateName);
            if (response != null && response.StatusCode == HttpStatusCode.OK)
            {
               var sourceHtmlDocument = await _usdRatesQuery.GetSourceHtmlDocumentAsync(rateName);
               var outputString = _usdRatesQuery.GetOutputStringAfterCssSelector(sourceHtmlDocument, selector);
               var getArrayFromOutput =_usdRatesQuery.ConvertOutputStringToArrayHtmlString(outputString);
               var currencyList =await _usdRatesQuery.CreateCurrencyListAsync(getArrayFromOutput);

               return currencyList;
            }
            else
            {
                throw new Exception($"Status code is {response.StatusCode}");
            }
        }
    }
}
