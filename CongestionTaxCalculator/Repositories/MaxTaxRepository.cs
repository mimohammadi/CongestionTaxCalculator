using CongestionTaxCalculator.DbContext;
using CongestionTaxCalculator.Models.MaxTax;

namespace CongestionTaxCalculator.Repositories
{
    public class MaxTaxRepository : Repository<MaxTax, int>,
        IMaxTaxRepository
    {
        public MaxTaxRepository(DataBaseContext dbContext) : base(dbContext)
        {
        }
    }
}
