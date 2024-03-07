using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Random_Viccek_Rest_Api;
using System.Net.Http;

namespace Random_Viccek_Rest_Api
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Here's another joke, but this isn't Chuck Norris:");
            string AnotherJoke = await AnotherDailyJoke();

            Console.WriteLine("\n" + AnotherJoke);
            Console.ReadKey();
        }

        private static async Task<string> AnotherDailyJoke()
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage responseMessage = await client.GetAsync("https://v2.jokeapi.dev/joke/Any?blacklistFlags=religious,political,racist&type=single");
                    if (responseMessage.IsSuccessStatusCode)
                    {
                        string jsonString = await responseMessage.Content.ReadAsStringAsync();
                        var randomViccek = RandomViccek.FromJson(jsonString);

                        return randomViccek.Joke;
                    }
                    else
                    {
                        return "Hiba történt a csatlakozás során";
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
