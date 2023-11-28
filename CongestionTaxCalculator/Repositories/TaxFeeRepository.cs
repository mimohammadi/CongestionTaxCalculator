using CongestionTaxCalculator.DbContext;
using CongestionTaxCalculator.Models.TaxFee;

namespace CongestionTaxCalculator.Repositories
{
    public class TaxFeeRepository : Repository<TaxFee, int>,
        ITaxFeeRepository
    {
        public TaxFeeRepository(DataBaseContext dbContext) : base(dbContext)
        {
        }
    }
}
