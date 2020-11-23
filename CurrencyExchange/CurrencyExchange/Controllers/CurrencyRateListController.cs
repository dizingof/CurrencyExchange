using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CurrencyExchange.Contracts.UseCases;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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

            var result = _getListCurrencyUseCase.GetSourceByPageId();
            var first = result.Result.First().Name;
            return Ok(first);
        }
    }
}
