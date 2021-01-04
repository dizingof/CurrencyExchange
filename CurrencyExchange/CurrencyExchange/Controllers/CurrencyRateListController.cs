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
        [Route("GetCurrencyList")]
        public IActionResult CreateWorkItem()
        {

            var result = _getListCurrencyUseCase.GetGetCurrencyListFromRemoteResourceAsync();
            var json = JsonConvert.SerializeObject(result.Result);
            return Ok(json);
        }
    }



}
