using System;

namespace CurrencyManager.ConsoleApp.Services.Consoles
{
    public class ConsoleService : IConsoleService
    {
        public string GetString(string message)
        {
            Console.Write(message);
            string stringFromUser = Console.ReadLine();
            return stringFromUser;
        }

        public int GetInteger(string message, string errorMessage = null)
        {
            while (true)
            {
                Console.Write(message);
                string stringFromUser = Console.ReadLine();

                bool parsingResult = int.TryParse(stringFromUser, out int integerFromUser);

                bool errorMessageWasPassed = errorMessage != null;

                if (parsingResult)
                {
                    return integerFromUser;
                }
                else if (errorMessageWasPassed)
                {
                    Console.WriteLine(errorMessage);
                }
            }
        }
        public decimal GetDecimal(string message, string errorMessage = null)
        {
            while (true)
            {
                Console.Write(message);
                string stringFromUser = Console.ReadLine();
                bool parsingResult = decimal.TryParse(stringFromUser, out decimal decimalFromUser);
                bool errorMessageWasPassed = errorMessage != null;

                if (parsingResult)
                {
                    return decimalFromUser;
                }
                else if (errorMessageWasPassed)
                {
                    Console.WriteLine(errorMessage);
                }
            }
        }

        public int GetIntegerWithinRange(string message, int rangeFrom, int rangeTo)
        {
            while (true)
            {
                Console.Write($"{message} ({rangeFrom}-{rangeTo}) : ");

                string potentialInteger = Console.ReadLine();
                bool parsingSuccess = int.TryParse(potentialInteger, out int parsedInteger);
                bool isIntegerWithinRange = parsedInteger >= rangeFrom && parsedInteger <= rangeTo;

                if (parsingSuccess && isIntegerWithinRange)
                {
                    return parsedInteger;
                }
            }
        }

        public bool GetDecision(string question, string postiveAnswer, string negativeAnswer)
        {
            while (true)
            {
                Console.Write(question);
                string userDecision = Console.ReadLine();

                if (userDecision == postiveAnswer)
                {
                    return true;
                }
                else if (userDecision == negativeAnswer)
                {
                    return false;
                }
            }
        }

        public void GetConvertedValue(double exchangeRate, double secondExchangeRate, string valueName, string secondValueName, string message, string tpyeValueMessage, string conversionErrorMessage)
        {
            while (true)
            {
                Console.WriteLine(message);
                string userValueAnswer = Console.ReadLine();
                bool userAnswerParseResult = double.TryParse(userValueAnswer, out double ParsedValue);

                Console.WriteLine(tpyeValueMessage);
                string userTypeExchangeRate = Console.ReadLine();

                if (userAnswerParseResult && userTypeExchangeRate == valueName)
                {
                    double convertedValue = ParsedValue / exchangeRate;
                    Console.WriteLine($"Masz {convertedValue} {valueName}!");
                    break;
                }
                else if (userAnswerParseResult && userTypeExchangeRate == secondValueName)
                {
                    double convertedValue = ParsedValue / secondExchangeRate;
                    Console.WriteLine($"Masz {convertedValue} {secondValueName}!");
                    break;
                }
                else
                {
                    Console.WriteLine(conversionErrorMessage);
                }
            }
        }
    }
}