using CurrencyManager.Logic.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyManager.Logic.Services.CurrencyProvider
{
    public class HardcodedCurrencyProviderService : ICurrencyProviderService
    {
        private readonly List<Currency> _currencies = new List<Currency>
        {
            new Currency { Name = "złoty", Code = "PLN", Symbol = "zł", Countries = new List<string> { "Polska" } },
            new Currency { Name = "dolar", Code = "USD", Symbol = "$", Countries = new List<string> { "Stany Zjednoczone" } },
            new Currency { Name = "Brytyjski funt szterling", Code = "GBP", Symbol = "£", Countries = new List<string> { "Polska" } },
            new Currency { Name = "euro", Code = "EUR", Symbol = "€", Countries = new List<string> { "Polska" } }
        };

        public async Task<List<Currency>> GetCurrenciesAsync()
        {
            // Metoda ToList tworzy nową instancję listy. W ten sposób zwracasz INNĄ listę z tymi samymi danymi
            // Jak ktoś pobierze sobie listę walut i doda do niej nową walutę to ona nie uwzględni się w tej liście,
            // dlatego, że ToList stworzyło nową referencję

            var currencies = _currencies.ToList();

            return await Task.FromResult(currencies);
        }
    }
}