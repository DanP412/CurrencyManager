using CurrencyManager.Logic.Models;
using System.Collections.Generic;

namespace CurrencyManager.ConsoleApp.Services.Menu
{
    public interface IMenuService
    {
        void DisplayOptions();

        int GetOption();

        void DisplayCurrencies(List<Currency> currencies);
    }
}
