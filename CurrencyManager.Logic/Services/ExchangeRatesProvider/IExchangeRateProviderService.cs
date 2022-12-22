using CurrencyManager.Logic.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CurrencyManager.Logic.Services.ExchangeRatesProvider
{
    public interface IExchangeRateProviderService
    {
        Task<IEnumerable<ExchangeRate>> GetExchangeRatesAsync();
    }
}
