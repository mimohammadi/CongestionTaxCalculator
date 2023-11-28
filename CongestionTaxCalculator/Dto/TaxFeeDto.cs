using System;

namespace CongestionTaxCalculator.Dto
{
    public class TaxFeeCreateDto
    {
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public int Fee { get; set; }

    }
    public class TaxFeeDto
    {
        public int Id { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public int Fee { get;  set; }

    }
}
