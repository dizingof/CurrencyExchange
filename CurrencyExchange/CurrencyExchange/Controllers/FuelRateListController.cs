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
            var result = _getListFuelUseCase.GetGetCurrencyListFromRemoteResourceAsync(Urls.AddressFuelPage, Selectors.SelectorForFuelRatesSheets);
            return Ok(result.Result);
        }
    }
}
