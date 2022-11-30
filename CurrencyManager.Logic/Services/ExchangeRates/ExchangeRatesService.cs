using CurrencyManager.Logic.Models;
using CurrencyManager.Logic.Services.CurrencyProvider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyManager.Logic.Services.ExchangeRates
{
    public class ExchangeRatesService : IExchangeRatesService
    {
        private readonly ICurrencyProviderService _currencyProviderService;

        private readonly List<ExchangeRate> _exchangeRates;

        public ExchangeRatesService(ICurrencyProviderService currencyProviderService)
        {
            _currencyProviderService = currencyProviderService;

            var currencyPLN = GetCurrencyByCodeAsync("PLN").Result;
            var currencyEUR = GetCurrencyByCodeAsync("EUR").Result;
            var currencyGBP = GetCurrencyByCodeAsync("GBP").Result;
            var currencyUSD = GetCurrencyByCodeAsync("USD").Result;

            _exchangeRates = new List<ExchangeRate>
            {
                new ExchangeRate { CurrencyToPurchase = currencyPLN, CurrencyToSell = currencyEUR, Rate = 4.22M },
                new ExchangeRate { CurrencyToPurchase = currencyPLN, CurrencyToSell = currencyUSD, Rate = 4.22M },
                new ExchangeRate { CurrencyToPurchase = currencyEUR, CurrencyToSell = currencyPLN, Rate = 4.22M },
                new ExchangeRate { CurrencyToPurchase = currencyUSD, CurrencyToSell = currencyEUR, Rate = 1.00M },
                new ExchangeRate { CurrencyToPurchase = currencyGBP, CurrencyToSell = currencyPLN, Rate = 0.18M },
                new ExchangeRate { CurrencyToPurchase = currencyPLN, CurrencyToSell = currencyGBP, Rate = 5.60M },
                new ExchangeRate { CurrencyToPurchase = currencyEUR, CurrencyToSell = currencyUSD, Rate = 1.00M }
            };
        }

        public async Task<string> GetExchangeRateAsync(string currencyToPurchase, string currencyToSell, decimal amonut)
        {
            string currencyToPurchaseUpper = currencyToPurchase.ToUpper();
            string currencyToSellUpper = currencyToSell.ToUpper();

            var exchangeRate = _exchangeRates.Single(er => er.CurrencyToPurchase.Code == currencyToPurchaseUpper && er.CurrencyToSell.Code == currencyToSellUpper);
            throw new NotImplementedException();

            return "S";
            //return await exchangeRate.Rate;
        }


        //public async Task<decimal> GetAmonuntOfExchangingMoney(string currencyToPurchase, string currencyToSell, decimal amountOfmoney)
        //{
        //    decimal exchangeRate = await  GetExchangeRateAsync(currencyToPurchase, currencyToSell, amountOfmoney);

        //    decimal amonuntOfExchangingMoney = exchangeRate * amountOfmoney;

        //    return amonuntOfExchangingMoney;
        //}

        public bool CurrencyExists(string currencyToPurchase, string currencyToSell)
        {
            string currencyToPurchaseUpper = currencyToPurchase.ToUpper();
            string currencyToSellUpper = currencyToSell.ToUpper();

            bool currencyExists = _exchangeRates.Any(er => er.CurrencyToPurchase.Code == currencyToPurchaseUpper && er.CurrencyToSell.Code == currencyToSellUpper);

            return currencyExists;
        }

        // First - kiedy chcemy pierwszy pasujący obiekt z kolekcji (z założeniem, że na pewno jakiś tam szukany obiekt)
        // FirstOrDefault - kiedy chcemy pierwszy pasujący obiekt z kolekcji (z założeniem, że może nie być szukanego obiektu)
        // Single - kiedy chcemy dokładnie 1 szukany obiekt (z założeniem, że szukany obiekt tam jest i jest tylko 1 pasujący)
        // SingleOrDefault - kiedy chcemy dokładnie 1 szukany obiekt (z założeniem, że może nie być szukanego obiektu)
        private async Task<Currency> GetCurrencyByCodeAsync(string currencyCode)
        {
            var currencies = await _currencyProviderService.GetCurrenciesAsync();

            var currency = currencies.Single(c => c.Code == currencyCode);

            return currency;
        }
    }
}