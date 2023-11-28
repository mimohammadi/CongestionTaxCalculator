using CongestionTaxCalculator.Dto;
using CongestionTaxCalculator.Interface;
using CongestionTaxCalculator.Models.MaxTax;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CongestionTaxCalculator.Services
{
    public class MaxTaxService : IMaxTaxService
    {
        private readonly IMaxTaxRepository _maxTaxRepository;

        public MaxTaxService(IMaxTaxRepository maxTaxRepository)
        {
            _maxTaxRepository = maxTaxRepository;
        }

        public async Task AddMaxAmount(MaxTaxCreateDto dto)
        {
            await _maxTaxRepository.Add(new MaxTax(dto.MaxAmount));
        }

        public async Task DeleteAmount(int id)
        {
            var fee = await _maxTaxRepository.GetQuerable()
                .AsTracking()
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();

            if (fee == null) throw new ArgumentNullException("MaxTax Not Found");
            fee.Delete();
            await _maxTaxRepository.Update(fee);
        }

        public async Task UpdateAmount(MaxTaxDto dto)
        {
            var fee = await _maxTaxRepository.GetQuerable()
                .AsTracking()
                .Where(x => x.Id == dto.Id)
                .FirstOrDefaultAsync();

            if (fee == null) throw new ArgumentNullException("MaxTax Not Found");
            fee.Update(dto.MaxAmount);
            await _maxTaxRepository.Update(fee);
        }

        public async Task<int> GetMaxTax()
        {
            var amount =  await _maxTaxRepository.GetQuerable()
                .OrderByDescending(a => a.Id)
                .FirstOrDefaultAsync();

            return amount?.MaxAmount?? 0;
        }
    }
}
