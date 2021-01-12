using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AngleSharp;
using AngleSharp.Dom;
using CurrencyExchange.Constants;
using CurrencyExchange.Contracts.Querys;
using CurrencyExchange.Models;

namespace CurrencyExchange.DataAccess
{
    public class UsdRatesQuery : IUsdRatesQuery
    {

        public async Task<IDocument> GetSourceHtmlDocumentAsync(string rateName)
        {
            var config = Configuration.Default.WithDefaultLoader();
            var address = rateName;
            var document = await BrowsingContext.New(config).OpenAsync(address);
            return document;
        }

        public string GetOutputStringAfterCssSelector(IDocument document, string selector)
        {
            var elements = document.GetElementsByClassName(selector);
            var InnerHtmlPropertyElements = elements.Select(m => m.InnerHtml);

            string outputString = null;
            foreach (var VARIABLE in InnerHtmlPropertyElements)
            {
                outputString += VARIABLE;
            }

            return outputString; 
        }

        public string[] ConvertOutputStringToArrayHtmlString(string outputString)
        {
            var massivStrok = outputString.Split("</tr>");
            Array.Resize(ref massivStrok, massivStrok.Length - 1);
            return massivStrok;
        }

        public async Task<List<Currency>> CreateCurrencyListAsync(string[] massivStrok)
        {
            List<Currency> listCurrency = new List<Currency>();

            foreach (var VARIABLE in massivStrok)
            {
                var document = await BrowsingContext.New(Configuration.Default).OpenAsync(req => req.Content(VARIABLE));
                var valueTagA = document.QuerySelector("a");
                var listValueTagSpan = document.QuerySelectorAll("span");
                var instanceCurrency = new Currency();
                instanceCurrency.Name = valueTagA.Text();
                instanceCurrency.Buy = listValueTagSpan.First().TextContent;
                instanceCurrency.Sell = listValueTagSpan.Last().TextContent;
                listCurrency.Add(instanceCurrency);
            }

            return listCurrency;
        }


    }
}
