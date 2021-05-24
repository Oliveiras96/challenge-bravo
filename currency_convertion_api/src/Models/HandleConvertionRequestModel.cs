using System.Collections.Generic;

namespace src.Models
{
    public class HandleConvertionRequestModel
    {
        public string From ;
        public string To ;
        public double Amount ;
        public List<EntriesModelInput> Currencies ;

        public double NewAmount;

        public HandleConvertionRequestModel(string from, string to, double amount, List<EntriesModelInput> currencies)
        {
            From = from;
            To = to;
            Amount = amount;
            Currencies = currencies;
        }

        public bool hasValidEntries()
        {
            
            var isOldCurrValid = Currencies.Contains(Currencies.Find(curr => curr.ISOCode == From));

            var isNewCurrValid = Currencies.Contains(Currencies.Find(curr => curr.ISOCode == To));

            var isAmountValid = (Amount >= 0.0);

            return isOldCurrValid && isNewCurrValid && isAmountValid;
        }

        public double convert(double amount)
        {
            var quotationNew = Currencies.Find(curr => curr.ISOCode == To).Quotation;
            var quotationCurrent = Currencies.Find(curr => curr.ISOCode == From).Quotation;

            var currentAmountInUsd = amount * quotationCurrent;

            return currentAmountInUsd * quotationNew;
        }
    }
}