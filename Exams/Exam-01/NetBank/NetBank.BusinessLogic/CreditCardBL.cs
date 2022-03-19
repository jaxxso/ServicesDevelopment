using System;
using System.Linq;
using System.Text;

namespace NetBank.BusinessLogic
{
    public static class CreditCardBL
    {
        private const int valorMaximo = 9;
        private const int MINIMO = 13;
        private const int MAXIMO = 19;
        public static bool IsValid(string creditCardNumber)
        {
            var digitsOnly = GetDigits(creditCardNumber);
            int sum = 0;
            int digit = 0;
            int addend = 0;
            bool timesTwo = false;
            int uno = 1;
            int dos = 2;
            int diez = 10;
            int cero = 0;

            if (digitsOnly.Length > MAXIMO || digitsOnly.Length < MINIMO) return false;

            for (var i = digitsOnly.Length - uno; i >= 0; i--)
            {
                digit = int.Parse(digitsOnly.ToString(i, uno));
                if (timesTwo)
                {
                    addend = digit * dos;
                    if (addend > valorMaximo)
                        addend -= valorMaximo;
                }
                else
                    addend = digit;

                sum += addend;

                timesTwo = !timesTwo;

            }
            return (sum % diez) == cero;
        }
    
    }

}
}