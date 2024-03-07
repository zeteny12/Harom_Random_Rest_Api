using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chuck_Norris_Rest_Api;
using System.Net.Http;

namespace Chuck_Norris_Rest_Api
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine($"Daily Chuck Norris:");
            string MaiVicc = await MaiRandomApi();
            Console.WriteLine("\n" + MaiVicc);
            Console.ReadKey();
        }

        private static async Task<string> MaiRandomApi()
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync("https://api.chucknorris.io/jokes/random");
                    if (response.IsSuccessStatusCode)
                    {
                        string jsonString = await response.Content.ReadAsStringAsync();
                        var chuckNorris = ChuckNorris.FromJson(jsonString);

                        return chuckNorris.Value;
                    }
                    else
                    {
                        return "Hiba történt az API hívása során";
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
