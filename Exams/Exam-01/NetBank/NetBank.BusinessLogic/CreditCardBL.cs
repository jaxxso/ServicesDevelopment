using NPOI.SS.Formula.Functions;
using System;
using System.Linq;
using System.Text;

namespace NetBank.BusinessLogic
{
    public static class CreditCardBL
    {
        public static bool IsValid(string creditCardNumber)
        {
            var digitsOnly = GetDigits(creditCardNumber);
            
            bool timestwo = false;
            int sum = 0;
            int digit = 0;
            int addend = 0;
            private const int maxValueDigit = 9;
            private const int MIN = 13;
            private const int MAX = 19;
            private const int MODTEN = 10;
            private const int FACTORTWO = 2;

            if (digitsOnly.Length > MAX || digitsOnly.Length<MIN) return false;

            for (var i = digitsOnly.Length - 1; i >= 0; i--)
            {
                digit = int.Parse(digitsOnly.ToString(i, 1));
                if (timesTwo)
                {
                    addend = digit * FACTORTWO;
                    if (addend > maxValueDigit)
                        addend -= maxValueDigit;
                }
                else
                    addend = digit;

                sum += addend;

                timesTwo = !timesTwo;

            }
            return (sum % MODTEN) == 0;
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
}