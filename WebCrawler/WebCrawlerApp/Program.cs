using HtmlAgilityPack;
using System;
using System.Net;

namespace WebCrawlerApp
{
    class Program
    {
        static void Main(string[] args)
        {
            const string URL = @"http://example.com";
            
            var pageSource = GetPageSource(URL);
            //Console.WriteLine(pageSource);

            var pageHtml = new HtmlDocument();
            pageHtml.LoadHtml(pageSource);

            PrintHtmlElements(pageHtml);
        }

        private static void PrintHtmlElements(HtmlDocument pageHtml)
        {
            var headingText = pageHtml.DocumentNode.SelectSingleNode(@"/html/body/div[1]/h1").InnerText;
            Console.WriteLine($"[Title]\n{headingText}");
            var paragraphs = pageHtml.DocumentNode.SelectNodes(@"/html/body/div[1]/p");
            foreach (var pNode in paragraphs)
            {
                Console.WriteLine($"[Paragraph]\n{pNode.InnerText}");
            }
        }

        private static string GetPageSource(string url)
        {
            var webClient = new WebClient();
            return webClient.DownloadString(url);
        }
    }
}
