using CongestionTaxCalculator.Interface;

namespace CongestionTaxCalculator.Models.MaxTax
{
    public class MaxTax:BaseEntity<int>, IAggregateRoot
    {
        public int MaxAmount { get; private set; }
        protected MaxTax()
        {
            
        }
        public MaxTax (int maxAmount)
        {
            MaxAmount = maxAmount;
        }

        public void Update(int maxAmount)
        {
            MaxAmount = maxAmount;
        }
    }
}
