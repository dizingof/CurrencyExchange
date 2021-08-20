using CurrencyExchange.Constants;
using CurrencyExchange.Contracts.UseCases;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CurrencyExchange.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuelRateListController : ControllerBase
    {
        private readonly IGetListFuelUseCase _getListFuelUseCase;


        public FuelRateListController(IGetListFuelUseCase getListFuelUseCase)
        {
            _getListFuelUseCase = getListFuelUseCase;
        }

        [HttpGet]
        [Route("GetFuelList")]
        public IActionResult GetCurrencyUsdList()
        {
            var result = _getListFuelUseCase.GetGetCurrencyListFromRemoteResourceAsync(Urls.AddressUsdPage, Selectors.SelectorForUsdRatesSheets);
            var json = JsonConvert.SerializeObject(result.Result);
            return Ok(json);
        }
    }
}
