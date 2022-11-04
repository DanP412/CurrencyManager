namespace CurrencyManager.Logic.Models
{
    public class ExchangeRate
    {
        public Currency CurrencyToPurchase { get; set; }

        public Currency CurrencyToSell { get; set; }

        public decimal Rate { get; set; }
    }
}
