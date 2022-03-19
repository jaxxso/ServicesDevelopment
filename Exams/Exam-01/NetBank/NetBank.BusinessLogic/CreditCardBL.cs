using System;
using System.Linq;
using System.Text;

namespace LuhnAlgorithm.Library
{
    public static class LuhnAlgorithmValidator
    {
        private static int Mod_10 = 10;
        private static int Mod_18 = 18;

        public static bool IsValid(string creditCardNumber)
        {
            var digitsOnly = GetDigits(creditCardNumber);


            if (digitsOnly.Length >= Mod_18 || digitsOnly.Length < Mod_10) return false;

            int sum = 0;
            int digit = 0;
            int addend = 0;
            bool timesTwo = false;

            for (var i = digitsOnly.Length - 1; i >= 0; i--)
            {
                digit = int.Parse(digitsOnly.ToString(i, 1));
                if (timesTwo)
                {
                    addend = digit * 2;
                    if (addend > 9)
                        addend -= 9;
                }
                else
                    addend = digit;

                sum += addend;

                timesTwo = !timesTwo;

            }
            return (sum % Mod_10) == 0;
            return (sum % Mod_18) == 0;

        }
        private static StringBuilder GetDigits(string creditCardNumber)
        {
            var digitsOnly = new StringBuilder();
            foreach (var character in creditCardNumber)
            {
                if (char.IsDigit(character))
                    digitsOnly.Append(character);
            }
            return digitsOnly;
        }
    }
}
