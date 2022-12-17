using CurrencyManager.ConsoleApp.Services.Consoles;
using CurrencyManager.ConsoleApp.Services.Menu;
using CurrencyManager.Logic.Services.CurrencyProvider;
using CurrencyManager.Logic.Services.ExchangeRates;
using Ninject;
using System;
using System.Threading.Tasks;

namespace CurrencyManager.ConsoleApp
{
    public static class Program
    {
        // Klasa pełniąca rolę KONTENERA (w nomenklaturze wstrzykiwania zależności)
        private static readonly IKernel _kernel = new StandardKernel();

        private static IMenuService _menuService;
        private static IConsoleService _consoleService;
        private static IExchangeRatesService _exchangeRatesService;
        private static ICurrencyProviderService _currencyProviderService;


        public static async Task Main(string[] args)
        {
            PerformDependencyInjectionBindings();

            while (true)
            {
                Console.Clear();

                _menuService.DisplayOptions();

                int option = _menuService.GetOption();

                if (option == 1)
                {
                    var currencies = await _currencyProviderService.GetCurrenciesAsync();

                    _menuService.DisplayCurrencies(currencies);
                }
                else if (option == 2)
                {
                    string currencyToPurchase = _consoleService.GetString("Wpisz rodzaj waluty krórą chcesz kupić: ");
                    string currencyToSell = _consoleService.GetString("Wpisz rodzaj waluty krórą chcesz sprzedać: ");
                    //decimal amount = _consoleService.GetDecimal("Podaj ilość pieniędzy do przewalutowania: ");

                    decimal exchangeRate = _exchangeRatesService.GetExchangeRate(currencyToSell, currencyToPurchase);

                    Console.WriteLine($"kurs waluty {currencyToSell} do {currencyToPurchase} wynosi: {exchangeRate}");
                }
                else if (option == 3)
                {
                    string CurrencyToPurchase = _consoleService.GetString("Wpisz rodzaj waluty krórą chcesz kupić: ");
                    string CurrencyToSell = _consoleService.GetString("Wpisz rodzaj waluty krórą chcesz sprzedać: ");
                    decimal amountOfMoney = _consoleService.GetDecimal("Podaj ilość pieniędzy do sprzedaży: ");

                    //_exchangeRatesService.GetExchangeRate(CurrencyToPurchase, CurrencyToSell, amountOfMoney);

                    //if (isValueExist)
                    //{
                    //    decimal amountOfMoney = _consoleService.GetDecimal("podaj ilość pieniędzy do przewalutowania: ", "Podaj poprawne dane! ");

                    //    decimal ConvertedMoney = _exchangeRatesService.GetAmonuntOfExchangingMoney(CurrencyToPurchase, CurrencyToSell, amountOfMoney);

                    //    string convertedCurrencySymbol = await _exchangeRatesService.GetCurrencySymbolAsync(CurrencyToPurchase);

                    //    Console.WriteLine($"\ntwoje pieniądze po przewalutowaniu to {ConvertedMoney} {convertedCurrencySymbol}!\n  ");
                    //}
                    //else
                    //{
                    //    Console.WriteLine("Podaj Poprawne dane! ");
                    //}
                }

                Console.Write("\nNaciśnij dowolny przycisk, aby powrócić do menu głównego...");
                Console.ReadKey();
            }
        }

        private static void PerformDependencyInjectionBindings()
        {
            _kernel.Bind<IMenuService>().To<MenuService>();
            _kernel.Bind<IConsoleService>().To<ConsoleService>();
            _kernel.Bind<ICurrencyProviderService>().To<ApiCurrencyProviderService>();
            _kernel.Bind<IExchangeRatesService>().To<ExchangeRatesService>();

            // Odpytanie kontenera o obiekt (on sam go utworzy oraz wszystkie potrzebne zależności, czyli co trzeba wsadzić w konstruktor)
            _menuService = _kernel.Get<IMenuService>();
            _consoleService = _kernel.Get<IConsoleService>();
            _exchangeRatesService = _kernel.Get<IExchangeRatesService>();
            _currencyProviderService = _kernel.Get<ICurrencyProviderService>();

        }
    }
}