using CurrencyManager.Logic.Services.CurrencyProvider;
using CurrencyManager.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CurrencyManager.WebApp.Controllers
{
    public class CurrencyController : Controller
    {
        private readonly ICurrencyProviderService _currencyProviderService;

        public CurrencyController(ICurrencyProviderService currencyProviderService)
        {
            _currencyProviderService = currencyProviderService;
        }

        // Metoda return View zwraca plik cshtml
        // Wybiera go na podstawie konwencji nazewnictwa, więcej info w komentarzu w klasie Program przy metodzie AddControllersWithViews
        public async Task<IActionResult> Index(int? id)
        {
            var currencies = await _currencyProviderService.GetCurrenciesAsync(); 
            return View(currencies);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}