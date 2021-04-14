using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyExchange.Constants
{
    public static class Urls
    {
        public static string AddressUsdPage = new string("https://finance.i.ua/usd/");
        public static string AddressEurPage = new string("https://finance.i.ua/eur/");
        public static string AddressRubPage = new string("https://finance.i.ua/rub/");

        public static string AddressWeatherApi = new string($"https://api.openweathermap.org/data/2.5/weather?lat=${lat}&lon=${lon}&units=metric&appid=217383a0acc26e401adcadaa58f77818");
    }
}
