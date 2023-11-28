using CongestionTaxCalculator.DbContext;
using CongestionTaxCalculator.Models.TaxFreeRules;

namespace CongestionTaxCalculator.Repositories
{
    public class TaxFreeRuleRepository : Repository<TaxFreeRule, int>,
        ITaxFreeRuleRepository
    {
        public TaxFreeRuleRepository(DataBaseContext dbContext) : base(dbContext)
        {
        }
    }
}
