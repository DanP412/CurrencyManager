using CurrencyManager.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyManager.Logic.Services.ExchangeRatesProvider
{
    public class HardcodedExchangeRatesProviderService : IExchangeRateProviderService
    {
        private readonly List<ExchangeRate> _exchangeRates;

        public HardcodedExchangeRatesProviderService()
        {
            var polishCurrency = new Currency { Name = "Polish zloty", Code = "PLN" };
            var gbpCurrency = new Currency { Name = "British pound sterling", Code = "GBP" };
            var euroCurrency = new Currency { Name = "Euro", Code = "EUR" };
            var usdCurrency = new Currency { Name = "United States dollar", Code = "USD" };

            _exchangeRates = new List<ExchangeRate>
            {
                new ExchangeRate
                {
                    CurrencyToPurchase = polishCurrency,
                    CurrencyToSell = euroCurrency,
                    Rate = 4.70M
                },
                new ExchangeRate
                {
                    CurrencyToPurchase = polishCurrency,
                    CurrencyToSell = gbpCurrency,
                    Rate = 5.38M
                },
                new ExchangeRate
                {
                    CurrencyToPurchase = polishCurrency,
                    CurrencyToSell = usdCurrency,
                    Rate = 4.42M
                },
                new ExchangeRate
                {
                    CurrencyToPurchase = polishCurrency,
                    CurrencyToSell = polishCurrency,
                    Rate = 1
                },
                new ExchangeRate
                {
                    CurrencyToPurchase = euroCurrency,
                    CurrencyToSell = polishCurrency,
                    Rate = 0.21M
                },
                new ExchangeRate
                {
                    CurrencyToPurchase = euroCurrency,
                    CurrencyToSell = usdCurrency,
                    Rate = 0.94M
                },
                new ExchangeRate
                {
                    CurrencyToPurchase = euroCurrency,
                    CurrencyToSell = gbpCurrency,
                    Rate = 2.70M
                },
                new ExchangeRate
                {
                    CurrencyToPurchase = euroCurrency,
                    CurrencyToSell = euroCurrency,
                    Rate = 1
                },
                new ExchangeRate
                {
                    CurrencyToPurchase = gbpCurrency,
                    CurrencyToSell = polishCurrency,
                    Rate = 0.19M
                },
                new ExchangeRate
                {
                    CurrencyToPurchase = gbpCurrency,
                    CurrencyToSell = usdCurrency,
                    Rate = 0.82M
                },
                new ExchangeRate
                {
                    CurrencyToPurchase = gbpCurrency,
                    CurrencyToSell = euroCurrency,
                    Rate = 0.87M
                },
                new ExchangeRate
                {
                    CurrencyToPurchase = gbpCurrency,
                    CurrencyToSell = gbpCurrency,
                    Rate = 1
                },
                new ExchangeRate
                {
                    CurrencyToPurchase = usdCurrency,
                    CurrencyToSell = polishCurrency,
                    Rate = 0.23M
                },
                new ExchangeRate
                {
                    CurrencyToPurchase = usdCurrency,
                    CurrencyToSell = gbpCurrency,
                    Rate = 1.22M
                },
                new ExchangeRate
                {
                    CurrencyToPurchase = usdCurrency,
                    CurrencyToSell = euroCurrency,
                    Rate = 1.06M
                },
                new ExchangeRate
                {
                    CurrencyToPurchase = usdCurrency,
                    CurrencyToSell = usdCurrency,
                    Rate = 1
                },

            };
        }

        public async Task<IEnumerable<ExchangeRate>> GetExchangeRatesAsync()
        {
            return await Task.FromResult(_exchangeRates.ToList());
        }
    }
}
