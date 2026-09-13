using System;
using System.Data;

namespace KALKULATOR.Services
{
    public class CalculatorService
    {
        public string Calculate(string expression)
        {
            try
            {
                string text = expression.Replace(",", ".").Replace("^", "**");

                if (string.IsNullOrWhiteSpace(text))
                    return "0";

                var result = new DataTable().Compute(text, null);
                return result.ToString();
            }
            catch
            {
                return "Ошибка";
            }
        }

        public string CalculateSquare(string input)
        {
            try
            {
                double num = Convert.ToDouble(input);
                return (num * num).ToString();
            }
            catch { return "Ошибка"; }
        }

        public string CalculateSqrt(string input)
        {
            try
            {
                double num = Convert.ToDouble(input);
                if (num < 0) return "Ошибка";
                return Math.Sqrt(num).ToString();
            }
            catch { return "Ошибка"; }
        }

        public string CalculateReciprocal(string input)
        {
            try
            {
                double num = Convert.ToDouble(input);
                if (num == 0) return "Ошибка";
                return (1 / num).ToString();
            }
            catch { return "Ошибка"; }
        }

        public string CalculatePercent(string input)
        {
            try
            {
                double num = Convert.ToDouble(input);
                return (num / 100).ToString();
            }
            catch { return "Ошибка"; }
        }

        public string CalculateSin(string input)
        {
            try
            {
                double num = Convert.ToDouble(input);
                return Math.Sin(num * Math.PI / 180).ToString();
            }
            catch { return "Ошибка"; }
        }

        public string CalculateCos(string input)
        {
            try
            {
                double num = Convert.ToDouble(input);
                return Math.Cos(num * Math.PI / 180).ToString();
            }
            catch { return "Ошибка"; }
        }

        public string CalculateTan(string input)
        {
            try
            {
                double num = Convert.ToDouble(input);
                return Math.Tan(num * Math.PI / 180).ToString();
            }
            catch { return "Ошибка"; }
        }

        public string CalculateCtg(string input)
        {
            try
            {
                double num = Convert.ToDouble(input);
                double tan = Math.Tan(num * Math.PI / 180);
                if (tan == 0) return "Ошибка";
                return (1 / tan).ToString();
            }
            catch { return "Ошибка"; }
        }

        public string CalculateExp(string input)
        {
            try
            {
                double num = Convert.ToDouble(input);
                return Math.Exp(num).ToString();
            }
            catch { return "Ошибка"; }
        }
    }
}