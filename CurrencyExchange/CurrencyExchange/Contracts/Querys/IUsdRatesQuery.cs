using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AngleSharp.Dom;
using CurrencyExchange.Models;

namespace CurrencyExchange.Contracts.Querys
{
    public interface IUsdRatesQuery
    {
        Task<IDocument> GetSourceHtmlDocumentAsync();
        string GetOutputStringAfterCssSelector(IDocument document);
        public string[] ConvertOutputStringToArrayHtmlString(string outputString);
        Task<List<Currency>> CreateCurrencyListAsync(string[] massivStrok);


    }
}
