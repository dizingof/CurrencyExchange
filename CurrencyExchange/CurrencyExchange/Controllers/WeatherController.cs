﻿using CurrencyExchange.Contracts.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace CurrencyExchange.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherController : ControllerBase
    {
        private readonly IGetWeatherUseCase _getWeatherUseCase;

        public WeatherController(IGetWeatherUseCase getWeatherUseCase)
        {
            _getWeatherUseCase = getWeatherUseCase; 
        }

        [HttpGet]
        [Route("GetWeatherByLocation")]
        public IActionResult GetWeatherByLocation(double lat, double lon)
        {
            var result = _getWeatherUseCase.GetWeatherByLocation(lat, lon);
            
            return Ok(result.Result);
        }
    }
}
