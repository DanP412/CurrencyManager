using System.Collections.Generic;

namespace CurrencyManager.Logic.Models
{
    public class Currency
    {
        public string Name { get; set; }

        public string Code { get; set; }

        public string Symbol { get; set; }

        public List<string> Countries { get; set; }
    }
}
