﻿using AngleSharp.Dom;
using CurrencyExchange.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CurrencyExchange.Contracts.Querys
{
    public interface IUsdRatesQuery
    {
        Task<IDocument> GetSourceHtmlDocumentAsync(string rateName);
        string GetOutputStringAfterCssSelector(IDocument document, string selector);
        public string[] ConvertOutputStringToArrayHtmlString(string outputString);
        Task<List<Currency>> CreateCurrencyListAsync(string[] massivStrok);
    }
}
