using CongestionTaxCalculator.Interface;

namespace CongestionTaxCalculator.Models.TaxFee
{
    public interface ITaxFeeRepository : IRepository<TaxFee, int>,
        IReadRepository<TaxFee, int>,
        IWriteRepository<TaxFee, int>
    {
    }
}
