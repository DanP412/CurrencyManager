using CurrencyManager.ConsoleApp.Services.Consoles;
using CurrencyManager.Logic.Models;
using CurrencyManager.Logic.Services.CurrencyProvider;
using System;
using System.Collections.Generic;

namespace CurrencyManager.ConsoleApp.Services.Menu
{
    public class MenuService : IMenuService
    {
        private readonly IConsoleService _consoleService;

        private List<string> _options = new List<string>
        {
            "Wyświetl dostępne waluty",
            "sprawdź kurs waluty",
            "Otwórz przelicznik walut",
            
        };

        public MenuService(IConsoleService consoleService)
        {
            _consoleService = consoleService;
        }

        public void DisplayOptions()
        {
            int number = 1;

            foreach (var option in _options)
            {
                Console.WriteLine($"{number}. {option}");
                number++;
            }
        }

        public int GetOption()
        {
            int optionCount = _options.Count;
            int option = _consoleService.GetIntegerWithinRange("Podaj opcję: ", 1, optionCount);
            return option;
        }

        public void DisplayCurrencies(List<Currency> currencies)
        {
            int numberOfCurrency = 1;

            Console.WriteLine();

            foreach (var currency in currencies)
            {
                Console.WriteLine($"{numberOfCurrency}.{currency.Name}");
                numberOfCurrency++;
            }

            Console.WriteLine();
        }
    }
}
