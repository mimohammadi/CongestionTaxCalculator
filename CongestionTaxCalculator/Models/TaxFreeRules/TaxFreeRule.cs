using CongestionTaxCalculator.Enums;
using CongestionTaxCalculator.Interface;

namespace CongestionTaxCalculator.Models.TaxFreeRules
{
    public class TaxFreeRule: BaseEntity<int>, IAggregateRoot
    {
        public RuleCategory Category { get; protected set; }
        protected TaxFreeRule()
        {
            
        }
        public TaxFreeRule(RuleCategory category)
        {
            Category = category;
        }
    }
}
