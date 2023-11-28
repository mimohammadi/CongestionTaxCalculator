using CongestionTaxCalculator.Enums;
using System;

namespace CongestionTaxCalculator.Models.TaxFreeRules
{
    public class TaxFreeDate:TaxFreeRule
    {
        public DateTime Date { get; private set; }

        protected TaxFreeDate()
        {
            
        }
        public TaxFreeDate(DateTime date)
        {
            Category = RuleCategory.Date;
            Date = date;
        }

        public void Update(DateTime date)
        {
            Date = date;
        }
    }
}
