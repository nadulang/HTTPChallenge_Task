using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using IronWebScraper;
using Newtonsoft.Json;

namespace HTTPChallenge
{
    public class Kompas
    {
        public class BlogScrapper : WebScraper
        {
            public override void Init()
            {
                LoggingLevel = WebScraper.LogLevel.All;
                Request("https://kompas.com", Parse);
            }
            public override void Parse(Response response)
            {
                foreach (var result in response.Css("a.headline__thumb__link"))
                {
                    Console.WriteLine(result.InnerText);
                    Console.WriteLine(result.Attributes["href"]);
                    Console.WriteLine("");
                }
            }
        }
    }
}