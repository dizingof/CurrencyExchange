using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyExchange.Constants
{
    public static class Urls
    {
        public static string AddressUsdPage = "https://finance.i.ua/usd/";
        public static string AddressEurPage = "https://finance.i.ua/eur/";
        public static string AddressRubPage = "https://finance.i.ua/rub/";

        public static string AddressWeatherApi = "https://api.openweathermap.org/data/2.5/weather?lat={0}&lon={1}&units=metric&appid={2}";
    }
}
