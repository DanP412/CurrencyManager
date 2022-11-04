using CurrencyManager.Logic.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CurrencyManager.Logic.Services.CurrencyProvider
{
    public interface ICurrencyProviderService
    {
        Task<List<Currency>> GetCurrenciesAsync();
    }
}