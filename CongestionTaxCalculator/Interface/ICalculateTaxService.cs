using CongestionTaxCalculator.Enums;
using System;
using System.Threading.Tasks;

namespace CongestionTaxCalculator.Interface
{
    public interface ICalculateTaxService
    {
        Task<int> GetTax(Vehicles vehicle, DateTime[] dates);
    }
}
