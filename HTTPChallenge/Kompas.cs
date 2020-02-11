using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using IronWebScraper;

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
                foreach (var result in response.Css("div.headline.ga--headline.clearfix"))
                {
                    string title = result.Css("a[href]")[0].Attributes["href"];
                    Console.WriteLine(title);
                    Console.WriteLine("");
                    string title1 = result.Css("a[href]")[1].Attributes["href"];
                    Console.WriteLine(title1);
                    Console.WriteLine("");
                    string title2 = result.Css("a[href]")[2].Attributes["href"];
                    Console.WriteLine(title2);
                    Console.WriteLine("");
                    string title3 = result.Css("a[href]")[0].Attributes["href"];
                    Console.WriteLine(title3);
                    Console.WriteLine("");
                    string title4 = result.TextContentClean;
                    Console.WriteLine(title4);
                    Console.WriteLine("");
                }

            }
            
        }


    }
}
