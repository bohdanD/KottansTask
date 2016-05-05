using System.Linq;
using System.Text.RegularExpressions;

namespace KottansTask
{
    public static class CreditCardMethods
    {
        public static string GetCreditCardVendor(string cardNumber)
        {

            cardNumber = new string(cardNumber.Where(x => x != ' ').ToArray());
            string AEPattern = "^34|37[0-9]{13}$";
            string MaestroPattern = "^(5[06789])|(6[0-9])[0-9]{10, 17}$";
            string MCPattern = "^5[1-5][0-9]{14}$";
            string VisaPattern = "^4[0-9]{12}|[0-9]{15}|[0-9]{18}$";
            string JCBPattern = "^(35[3-8][0-9])|(3528|3529)[0-9]{12}$";


            if (Regex.IsMatch(cardNumber, AEPattern))
                return "American Express";
            if (Regex.IsMatch(cardNumber, MaestroPattern))
                return "Maestro";
            if (Regex.IsMatch(cardNumber, MCPattern))
                return "Master Card";
            if (Regex.IsMatch(cardNumber, VisaPattern))
                return "Visa";
            if (Regex.IsMatch(cardNumber, JCBPattern))
                return "JCB";

            return "Unknown";

        }

        public static bool IsCreditCardNumberValid(string cardNumber)
        {
            cardNumber = new string(cardNumber.Where(x => x != ' ').ToArray());
            int[] numbersArr = new int[cardNumber.Length + 1];
            long test;
            if (!long.TryParse(cardNumber, out test))
                return false;
            for (int i = 1; i <= cardNumber.Length; i++)
            {
                numbersArr[i] = int.Parse(cardNumber.ElementAt(cardNumber.Length - i).ToString());
                if (i % 2 == 0)
                {
                    numbersArr[i] *= 2;
                    if (numbersArr[i] > 9)
                        numbersArr[i] = numbersArr[i] % 10 + (numbersArr[i] / 10) % 10;
                }
            }
            if (numbersArr.Sum() % 10 == 0)
                return true;
            return false;
        }

        public static string GenerateNextCreditCardNumber(string cardNumber)
        {
            if (!IsCreditCardNumberValid(cardNumber))
                return "input valid card number";
            cardNumber = new string(cardNumber.Where(x => x != ' ').ToArray());
            do
            {
                cardNumber = (long.Parse(cardNumber) + 1).ToString();
            }
            while (!IsCreditCardNumberValid(cardNumber));
            return cardNumber;
        }
    }
}
