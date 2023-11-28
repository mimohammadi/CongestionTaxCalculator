using CongestionTaxCalculator.Enums;
using System;

namespace CongestionTaxCalculator.Models.TaxFreeRules
{
    public class TaxFreeMonth:TaxFreeRule
    {
        public int Month { get; private set; }
        protected TaxFreeMonth()
        {
            
        }
        public TaxFreeMonth(int month)
        {
            Category = RuleCategory.Month;
            Month = month;
        }

        public void Update(int month)
        {
            Month = month;
        }
    }
}
