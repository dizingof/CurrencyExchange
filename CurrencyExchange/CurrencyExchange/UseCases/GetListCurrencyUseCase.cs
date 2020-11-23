using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using AngleSharp;
using AngleSharp.Dom;
using CurrencyExchange.Contracts.UseCases;
using CurrencyExchange.Models;

namespace CurrencyExchange.UseCases
{
    public class GetListCurrencyUseCase : IGetListCurrencyUseCase
    {
        private readonly HttpClient client;
        private string url = "https://finance.i.ua/";
        public GetListCurrencyUseCase()
        {
            client = new HttpClient();
        }
        string source = null;
        public async Task<List<Currency>> GetSourceByPageId()
        {
            var response = await client.GetAsync(url);

            string source = null;
            if (response != null && response.StatusCode == HttpStatusCode.OK)
            {


                ////////////////////////////////////////////////////////////////////////////
                //var config = Configuration.Default.WithDefaultLoader();
                //var address = "https://finance.i.ua/";
                //var document = await BrowsingContext.New(config).OpenAsync(address);



                //var cellSelector = "bank_rates_usd";

                //var cells = document.GetElementsByClassName(cellSelector);

                //var titles = cells.Select(m => m.InnerHtml);


                //foreach (var VARIABLE in titles)
                //{
                //    source += VARIABLE;
                //}

                //var massivStrok = source.Split("</tr>");

                //Array.Resize(ref massivStrok, massivStrok.Length - 1);

                //List<Currency> listModels = new List<Currency>();
                //foreach (var VARIABLE in massivStrok)
                //{

                //    var context = BrowsingContext.New(Configuration.Default);
                //    var document2 = await context.OpenAsync(req => req.Content(VARIABLE));
                //    var emphasize = document2.QuerySelector("a");
                //    var emphasize2 = document2.QuerySelectorAll("span");
                //   var instance = new Currency();
                //    instance.Name = emphasize.Text();
                //    instance.Buy = emphasize2.First().TextContent;
                //    instance.Sell = emphasize2.Last().TextContent;
                //    listModels.Add(instance);
                //}

                //return listModels;
            }
            else
            {
                throw new Exception($"Status code is {response.StatusCode}");
            }
        }
    }
}
