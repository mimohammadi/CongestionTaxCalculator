using CongestionTaxCalculator.Interface;
using System;

namespace CongestionTaxCalculator.Models.TaxFee
{
    public class TaxFee:BaseEntity<int>, IAggregateRoot
    {
        public TimeSpan StartTime { get; private set; }
        public TimeSpan EndTime { get; private set; }
        public int Fee { get; private set; }

        protected TaxFee()
        {
            
        }
        public TaxFee(TimeSpan startTime, TimeSpan endTime, int fee)
        {
            StartTime = startTime;
            EndTime = endTime;
            Fee = fee;
        }

        public void Update(TimeSpan startTime, TimeSpan endTime, int fee)
        {
            StartTime = startTime;
            EndTime = endTime;
            Fee = fee;
        }
    }
}
