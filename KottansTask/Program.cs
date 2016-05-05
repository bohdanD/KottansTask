using System;

namespace KottansTask
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("enter card number:");
            string cardNumber = Console.ReadLine();
            Console.Write("Credit card vendor : ");
            Console.WriteLine(CreditCardMethods.GetCreditCardVendor(cardNumber));
            Console.Write("Is card valid : ");
            Console.WriteLine(CreditCardMethods.IsCreditCardNumberValid(cardNumber));
            Console.Write("Next valid credit card number : ");
            Console.WriteLine(CreditCardMethods.GenerateNextCreditCardNumber(cardNumber));
            Console.ReadKey();
        }
    }
}
