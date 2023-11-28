using CongestionTaxCalculator.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CongestionTaxCalculator.Interface
{
    public interface ITaxFeeService
    {
        Task AddFee(TaxFeeCreateDto taxFee);
        Task UpdateFee(TaxFeeDto taxFee);
        Task DeleteFee(int id);
        Task<IEnumerable<TaxFeeDto>> GetFeeList();
    }
}
