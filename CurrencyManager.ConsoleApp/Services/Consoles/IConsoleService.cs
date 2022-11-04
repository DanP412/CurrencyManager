namespace CurrencyManager.ConsoleApp.Services.Consoles
{
    public interface IConsoleService
    {
        string GetString(string message);

        int GetInteger(string message, string errorMessage = null);

        int GetIntegerWithinRange(string message, int rangeFrom, int rangeTo);

        bool GetDecision(string question, string postiveAnswer, string negativeAnswer);

        void GetConvertedValue(double exchangeRate, double secondExchangeRate, string valueName, string secondValueName, string message, string tpyeValueMessage, string conversionErrorMessage);

        public decimal GetDecimal(string message, string errorMessage = null);

    }
}
