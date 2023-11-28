using CongestionTaxCalculator.Interface;

namespace CongestionTaxCalculator.Models.MaxTax
{
    public interface IMaxTaxRepository : IRepository<MaxTax, int>,
        IReadRepository<MaxTax, int>,
        IWriteRepository<MaxTax, int>
    {
    }
}
