using CongestionTaxCalculator.Dto;
using CongestionTaxCalculator.Enums;
using CongestionTaxCalculator.Models.TaxFreeRules;
using System;
using System.Threading.Tasks;

namespace CongestionTaxCalculator.Interface
{
    public interface ITaxFreeRuleService
    {
        Task AddTaxFreeRule(TaxFreeRuleCreateDto date);
        Task UpdateRule(TaxFreeRuleDto taxFreeRule);
        Task DeleteRule(int id);
        Task<bool> IsTaxFreeVehicle(Vehicles vehicle);
        Task<bool> IsFreeDate(DateTime date);
    }
}
