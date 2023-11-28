using CongestionTaxCalculator.Dto;
using System.Threading.Tasks;

namespace CongestionTaxCalculator.Interface
{
    public interface IMaxTaxService
    {
        Task AddMaxAmount(MaxTaxCreateDto dto);
        Task UpdateAmount(MaxTaxDto dto);
        Task DeleteAmount(int id);

        Task<int> GetMaxTax();
    }
}
