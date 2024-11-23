using Alfateam.DB.ServicesDBs;
using Alfateam.Services.CurrencyRates.API.Models;
using Newtonsoft.Json;
using RestSharp;

namespace Alfateam.Services.CurrencyRates.API.Jobs
{
    public class RatesParserJob
    {
        private static RestClient client = new RestClient();
        private const string API_URL = "https://data.fixer.io/api/latest?access_key=d23716c963b88ffd843e8f0399835b6a"; 
        public static async Task Start()
        {
            while (true)
            {
                var restResponse = client.Execute(new RestRequest(API_URL));
                var response = JsonConvert.DeserializeObject<FixerAPIRatesResponse>(restResponse.Content);

                using (var db = new CurrencyRatesDbContext())
                {
                    foreach(var rate in response.Rates)
                    {
                        db.Rates.Add(new CurrencyRates.Models.Rate
                        {
                            ActualAt = response.Date,
                            From = response.Base,
                            To = rate.Key,
                            Value = rate.Value,
                        });
                    }
                    db.SaveChanges();
                }


                await Task.Delay(TimeSpan.FromHours(1));
            }
        }
    }
}
