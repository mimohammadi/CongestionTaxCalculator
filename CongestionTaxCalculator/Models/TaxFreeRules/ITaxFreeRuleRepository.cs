using CongestionTaxCalculator.Interface;

namespace CongestionTaxCalculator.Models.TaxFreeRules
{
    public interface ITaxFreeRuleRepository : IRepository<TaxFreeRule, int>,
        IReadRepository<TaxFreeRule, int>,
        IWriteRepository<TaxFreeRule, int>
    {
    }
}
