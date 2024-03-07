using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Daily_Quotes_Rest_Api;
using System.Net.Http;

namespace Daily_Quotes_Rest_Api
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Random Quote:");
            string Quote = await RandomDailyQuote();
            Console.WriteLine("\n" + Quote);

            Console.ReadKey();
        }

        private static async Task<string> RandomDailyQuote()
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage responseMessage = await client.GetAsync("https://zenquotes.io/api/random");
                    if (responseMessage.IsSuccessStatusCode)
                    {
                        string jsonString = await responseMessage.Content.ReadAsStringAsync();
                        var randomQuotes = RandomQuotes.FromJson(jsonString);

                        return randomQuotes[0].Q;   //Azért, mert tömb, és így lehet kiolvasni
                    }
                    else
                    {
                        return "Hiba a csatlakozás során";
                    }
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
            }
        }
    }
}
