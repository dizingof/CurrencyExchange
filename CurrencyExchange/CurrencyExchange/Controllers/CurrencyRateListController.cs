using CurrencyExchange.Constants;
using CurrencyExchange.Contracts.UseCases;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CurrencyExchange.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrencyRateListController : ControllerBase
    {
        private readonly IGetListCurrencyUseCase _getListCurrencyUseCase;

        public CurrencyRateListController(IGetListCurrencyUseCase getListCurrencyUseCase)
        {
            _getListCurrencyUseCase = getListCurrencyUseCase;
        }


        [HttpGet]
        [Route("GetCurrencyUsdList")]
        public IActionResult CreateWorkItemUsd()
        {
            var result = _getListCurrencyUseCase.GetGetCurrencyListFromRemoteResourceAsync(Urls.AddressUsdPage, Selectors.SelectorForUsdRatesSheets);
            var json = JsonConvert.SerializeObject(result.Result);
            return Ok(json);
        }

        [HttpGet]
        [Route("GetCurrencyEurList")]
        public IActionResult CreateWorkItemEur()
        {
            var result = _getListCurrencyUseCase.GetGetCurrencyListFromRemoteResourceAsync(Urls.AddressEurPage, Selectors.SelectorForEurRatesSheets);
            var json = JsonConvert.SerializeObject(result.Result);
            return Ok(json);
        }

        [HttpGet]
        [Route("GetCurrencyRubList")]
        public IActionResult CreateWorkItemRub()
        {
            var result = _getListCurrencyUseCase.GetGetCurrencyListFromRemoteResourceAsync(Urls.AddressRubPage, Selectors.SelectorForRubRatesSheets);
            var json = JsonConvert.SerializeObject(result.Result);
            return Ok(json);
        }

    }



}
