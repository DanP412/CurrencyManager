using CurrencyManager.Logic.Models;
using CurrencyManager.Logic.Services.CurrencyProvider;
using Newtonsoft.Json.Linq;
using RestSharp;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace CurrencyManager.Logic.Services.ExchangeRatesProvider
{
    public class ApiExchangeRatesProviderService : IExchangeRateProviderService
    {
        private readonly ICurrencyProviderService _currencyProviderService;

        private readonly string _apiUrl = "https://api.fastforex.io";
        private readonly string _developmentKey = "98a34cff65-03813dd93e-rn99bj";

        public ApiExchangeRatesProviderService(ICurrencyProviderService currencyProviderService)
        {
            _currencyProviderService = currencyProviderService;
        }

        public async Task<IEnumerable<ExchangeRate>> GetExchangeRatesAsync()
        {
            var currencies = await _currencyProviderService.GetCurrenciesAsync();

            var allExchangeRates = new List<ExchangeRate>();

            foreach (var currencyToSell in currencies)
            {
                var currenciesToPurchase = currencies.Where(c => c != currencyToSell);

                var exchangeRatesForOneCurrency = await GetExchangeRatesForOneCurrency(currencyToSell, currenciesToPurchase);

                allExchangeRates.AddRange(exchangeRatesForOneCurrency);
            }

            return allExchangeRates;
        }

        private async Task<IEnumerable<ExchangeRate>> GetExchangeRatesForOneCurrency(Currency currencyToSell, IEnumerable<Currency> currenciesToPurchase)
        {
            var currencyCodes = currenciesToPurchase.Select(c => c.Code);
            string codesString = string.Join(',', currencyCodes);

            string apiEndpoint = $"{_apiUrl}/fetch-multi?from={currencyToSell.Code}&to={codesString}&api_key={_developmentKey}";

            var restClientOptions = new RestClientOptions(_apiUrl)
            {
                ThrowOnAnyError = true,
                MaxTimeout = 1000
            };

            var client = new RestClient(restClientOptions);

            var request = new RestRequest(apiEndpoint, Method.Get);

            var restResponse = await client.GetAsync(request);

            string jsonResponse = restResponse.Content;

            var exchangeRateProperties = JObject.Parse(jsonResponse);

            var responseRootChildren = exchangeRateProperties.Children();

            string ratesPropertyName = "results";

            var responseRateJObjects = responseRootChildren.Single(x => x.Path == ratesPropertyName).Children().First().Children();

            var exchangeRates = new List<ExchangeRate>();

            foreach (var exchangeRateJObject in responseRateJObjects)
            {
                string currencyToPurchaseCode = exchangeRateJObject.Path.Replace($"{ratesPropertyName}.", string.Empty);
                decimal rate = exchangeRateJObject.Children().First().Value<decimal>();

                var currencyToPurchase = currenciesToPurchase.Single(c => c.Code == currencyToPurchaseCode);

                var exchangeRate = new ExchangeRate
                {
                    CurrencyToPurchase = currencyToPurchase,
                    CurrencyToSell = currencyToSell,
                    Rate = rate
                };

                exchangeRates.Add(exchangeRate);
            }

            return exchangeRates;
        }
    }
}
