using System.Threading.Tasks;

namespace CurrencyManager.Logic.Services.ExchangeRates
{
    public interface IExchangeRatesService
    {
        decimal GetExchangeRate(string currencyToPurchase, string currencyToSell);

        decimal GetAmonuntOfExchangingMoney(string currencyToPurchase, string currencyToSell, decimal amountOfmoney);
        
        bool CurrencyExists(string currencyToPurchase, string currencyToSell);

        // Usunęliśmy symbol bo nie było w api
        //Task<string> GetCurrencySymbolAsync(string currencyCode);
    }
}