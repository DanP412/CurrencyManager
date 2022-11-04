using CurrencyManager.Logic.Models;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CurrencyManager.Logic.Services.CurrencyProvider
{
    public class ApiCurrencyProviderService : ICurrencyProviderService
    {
        private readonly string _apiUrl = "https://api.apilayer.com";

        public async Task<List<Currency>> GetCurrenciesAsync()
        {
            var restClientOptions = new RestClientOptions(_apiUrl)
            {
                ThrowOnAnyError = true,
                MaxTimeout = 1000
            };

            var restClient = new RestClient(restClientOptions);

            string resource = "exchangerates_data/symbols";

            var restRequest = new RestRequest(resource);

            restRequest.AddHeader("apikey", "wtPTiykGgPLBEZPD3wZDxPlBZMYjbmIl");

            // Pobranie danych cząstkowych (2 pola)

            // Pobranie brakujących danych

            // Sklejenie wszystkich danych z powyższych strzałów do różnych api w jedną spójną List<Currency> (bo tak nakazuje interfejs ICurrencyProviderService)

            // 2 prywatne metody na 2 strzały do api (obydwie zwracają JObject)
            // 1 metoda prywatna łącząca te 2 powyższe informacje i zwracająca ostateczny wynik, który powinna zwrócić metoda główna (publiczna)

            try
            {
                var restResponse = await restClient.GetAsync(restRequest);

                string jsonResponse = restResponse.Content;

                JObject json = JObject.Parse(jsonResponse);

            }
            catch (Exception e)
            {

                throw;
            }
            
            return null;
        }

        public async Task<JObject> GetCurrenciesPropertiesAsync()
        {
            var restClientOptions = new RestClientOptions(_apiUrl)
            {
                ThrowOnAnyError = true,
                MaxTimeout = 1000
            };

            var restClient = new RestClient(restClientOptions);
            string resource = "exchangerates_data/symbols";

            var restRequest = new RestRequest(resource);
            restRequest.AddHeader("apikey", "wtPTiykGgPLBEZPD3wZDxPlBZMYjbmIl");


            var restResponse = await restClient.GetAsync(restRequest);
            string jsonResponse = restResponse.Content;

            JObject json = JObject.Parse(jsonResponse);
            

            return json;
        }

        //public async Task<JObject> GetCurrenciesPropertiesAsync()
        //{
        //    var restClientOptions = new RestClientOptions(_apiUrl)
        //    {
        //        ThrowOnAnyError = true,
        //        MaxTimeout = 1000
        //    };

        //    var restClient = new RestClient(restClientOptions);
        //    string resource = "exchangerates_data/symbols";

        //    var restRequest = new RestRequest(resource);
        //    restRequest.AddHeader("apikey", "wtPTiykGgPLBEZPD3wZDxPlBZMYjbmIl");


        //    var restResponse = await restClient.GetAsync(restRequest);
        //    string jsonResponse = restResponse.Content;

        //    JObject json = JObject.Parse(jsonResponse);

        //    return json;
        //}



    }
}
