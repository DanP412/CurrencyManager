using System.Threading.Tasks;

namespace CurrencyManager.Logic.Services.ExchangeRates
{
    public interface IExchangeRatesService
    {
        bool CurrencyExists(string currencyToPurchase, string currencyToSell);

        Task<decimal> GetExchangeRateAsync(string baseCurrencyCode, string currencyToGetCode, decimal amount);

    }
}