using CongestionTaxCalculator.Enums;
using System;

namespace CongestionTaxCalculator.Dto
{
    public class TaxFreeRuleCreateDto
    {
        public RuleCategory Category { get; set; }
        public int? Month { get; set; }
        public DateTime? Date { get; set; }
        public DayOfWeek? Day { get; set; }
        public Vehicles? Vehicle { get; set; }
    }

    public class TaxFreeRuleDto
    {
        public int Id { get; set; }
        public RuleCategory Category { get; set; }
        public int? Month { get; set; }
        public DateTime? Date { get; set; }
        public DayOfWeek? Day { get; set; }
        public Vehicles? Vehicle { get; set; }
    }
}
