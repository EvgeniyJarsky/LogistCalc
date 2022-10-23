using System;

namespace LogisticCalcLib
{
    /// <summary>
    /// Собственное исключение для проверки положительности числа
    /// </summary>
    class NegativeValueException : Exception
    {
        public NegativeValueException(string message, string paramName)
            : base(message) { }
    }
}
