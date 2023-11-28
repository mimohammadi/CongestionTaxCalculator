using CongestionTaxCalculator.Enums;
using System;

namespace CongestionTaxCalculator.Models.TaxFreeRules
{
    public class TaxFreeDayOfWeek:TaxFreeRule
    {
        public DayOfWeek Day { get; private set; }
        protected TaxFreeDayOfWeek()
        {
            
        }

        public TaxFreeDayOfWeek(DayOfWeek day)
        {
            Category = RuleCategory.Day_Of_Week;
            Day = day;
        }

        public void Update(DayOfWeek day)
        {
            Day = day;
        }
    }
}
