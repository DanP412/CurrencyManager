using CurrencyManager.Logic.Models;
using CurrencyManager.Logic.Services.CurrencyProvider;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyManager.Logic.Services.ExchangeRates
{
    public class ApiExchangeRateService : IExchangeRatesService
    {
        string _apiUrl = "https://api.apilayer.com";
        private readonly string _developmentKey = "wtPTiykGgPLBEZPD3wZDxPlBZMYjbmIl";

        private readonly ICurrencyProviderService _currencyProviderService;

        private readonly List<ExchangeRate> _exchangeRates;

        private List<Currency> _currencies;

        private decimal ConvertJsonStringToExchangeRateAsync(string exchangeRatePropertiesJson)
        {
            JObject exchangeRateProperties = JObject.Parse(exchangeRatePropertiesJson);

            var responseRootChildren = exchangeRateProperties.Children();

            var responseData = responseRootChildren.Skip(2).Children();

            var responseDataRows = responseData.Children().Skip(1).Values();

            var responseDataRowsRate = responseDataRows.Values().Single();

            //rate
            string responseDataRowsRateString = responseDataRowsRate.ToString();

            bool isRateDecimal = decimal.TryParse(responseDataRowsRateString, out decimal parsedRate);

            if (isRateDecimal)
            {
                return parsedRate;
            }
            else
            {
                return 0;
            }
        }

        public async Task<decimal> GetExchangeRateAsync(string baseCurrencyCode, string currencyToGetCode, decimal amount)
        {
            string apiEndpoint = $"exchangerates_data/convert?to={currencyToGetCode}&from={baseCurrencyCode}&amount={amount}";

            bool isBaseCurrencyNull = baseCurrencyCode == null;
            bool isCurrencyToGetCodeNull = currencyToGetCode == null;
            bool isAmonutValid = amount > 0;

            if (!isBaseCurrencyNull)
            {
                throw new Exception("Niepoprawna bazowa waluta!");
            }
            else if (!isCurrencyToGetCodeNull)
            {
                throw new Exception("Niepoprawna waluta do wymiany! ");
            }
            else if (!isAmonutValid)
            {
                throw new Exception("Niepoprawna kwota pieniędzy! ");
            }

            var restClientOptions = new RestClientOptions(_apiUrl)
            {
                ThrowOnAnyError = true,
                MaxTimeout = 1000
            };

            var client = new RestClient(restClientOptions);

            var request = new RestRequest(apiEndpoint, Method.Get);

            request.AddHeader("apikey", _developmentKey);

            var restResponse = await client.GetAsync(request);

            string jsonResponse = restResponse.Content;

            decimal rate = ConvertJsonStringToExchangeRateAsync(jsonResponse);

            return rate;
        }

        
    }
}

