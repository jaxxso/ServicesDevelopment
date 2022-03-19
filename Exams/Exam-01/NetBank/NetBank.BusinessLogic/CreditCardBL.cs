﻿using System;
using System.Text;

namespace NetBank.BusinessLogic
{
    public class CreditCardBL
    {
        public static bool IsValid(string creditCardNumber)
        {
            var digitsOnly = GetDigits(creditCardNumber);
            int maxCreditNumber = 19;
            int minCreditNumber = 13;
            if (digitsOnly.Length > maxCreditNumber || digitsOnly.Length < minCreditNumber) return false;

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
            return (sum % 10) == 0;
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
