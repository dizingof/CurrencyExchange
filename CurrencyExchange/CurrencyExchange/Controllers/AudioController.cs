using System;
using System.IO;
using System.Media;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CurrencyExchange.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AudioController : ControllerBase
    {
        private readonly HttpClient _httpClient;

        public AudioController()
        {
            _httpClient = new HttpClient();
        }

        [HttpGet]
        [Route("Fm")]
        public byte[] GetAudio()
        {
            //var a = await _httpClient.GetStreamAsync("https://online.hitfm.ua/HitFM");
            //byte[] bytes = new byte[100000];
            //await a.ReadAsync(bytes, 0, bytes.Length);
           
            //var b = new SoundPlayer();
            //b.Load();
            //b.Play();

            //var webRequest = WebRequest.Create("https://online.hitfm.ua/HitFM");
            //webRequest.Method = "GET";
            //webRequest.Timeout = 12000;
            //webRequest.Headers.Add("Accept", "*/*");
            //webRequest.Headers.Add("Accept-Encoding", "identity;q=1, *;q=0");
            //webRequest.Headers.Add("Accept-Language",
            //    "ru-UA,ru;q=0.9,uk-UA;q=0.8,uk;q=0.7,ru-RU;q=0.6,en-US;q=0.5,en;q=0.4");
            //webRequest.Headers.Add("Connection", "keep-alive");
            //webRequest.Headers.Add("Host", "online.hitfm.ua");
            //webRequest.Headers.Add("Range", "bytes=0-");
            //webRequest.Headers.Add("Referer", "https://online.hitfm.ua/HitFM");
            //webRequest.Headers.Add("sec-ch-ua", "\"Chromium\";v=\"92\", \" Not A;Brand\";v=\"99\", \"Google Chrome\";v=\"92\"");
            //webRequest.Headers.Add("sec-ch-ua-mobile", "?0");
            //webRequest.Headers.Add("Sec-Fetch-Dest", "video");
            //webRequest.Headers.Add("Sec-Fetch-Mode", "no-cors");
            //webRequest.Headers.Add("Sec-Fetch-Site", "same-origin");
            //webRequest.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/92.0.4515.159 Safari/537.36");

            string url = @"https://online.hitfm.ua/HitFM";
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            using (HttpWebResponse resp = (HttpWebResponse)req.GetResponse())
            {
                int total = 0;
                byte[] buffer = new byte[1024];

                var networkStream = resp.GetResponseStream();
                while (true)
                {
                    int bytesRead = networkStream.Read(buffer, 0, buffer.Length);
                    Console.WriteLine("{0} bytesRead", bytesRead);
                    total += bytesRead;
                    return buffer;

                }

            }
        }
    }
}