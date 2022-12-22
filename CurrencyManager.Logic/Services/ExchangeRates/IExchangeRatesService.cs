using System.Threading.Tasks;

namespace CurrencyManager.Logic.Services.ExchangeRates
{
    public interface IExchangeRatesService
    {
        Task InitializeData();

        decimal GetExchangeRate(string currencyToPurchase, string currencyToSell);

        decimal GetAmonuntOfExchangingMoney(string currencyToPurchase, string currencyToSell, decimal amountOfmoney);
        
        bool CurrencyExists(string currencyCode);
    }

}