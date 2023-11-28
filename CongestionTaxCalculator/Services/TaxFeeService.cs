using CongestionTaxCalculator.Dto;
using CongestionTaxCalculator.Interface;
using CongestionTaxCalculator.Models.TaxFee;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CongestionTaxCalculator.Services
{
    public class TaxFeeService : ITaxFeeService
    {
        private readonly ITaxFeeRepository _taxFeeRepository;

        public TaxFeeService(ITaxFeeRepository taxFeeRepository)
        {
            _taxFeeRepository = taxFeeRepository;
        }

        public async Task AddFee(TaxFeeCreateDto taxFee)
        {
            await _taxFeeRepository.Add(new TaxFee(TimeSpan.Parse( taxFee.StartTime), TimeSpan.Parse(taxFee.EndTime), taxFee.Fee));
        }

        public async Task DeleteFee(int id)
        {
            var fee = await _taxFeeRepository.GetQuerable()
                .AsTracking()
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();

            if (fee == null) throw new ArgumentNullException("Fee Not Found");
            fee.Delete();
            await _taxFeeRepository.Update(fee);
        }

        public async Task<IEnumerable<TaxFeeDto>> GetFeeList()
        {
            return await _taxFeeRepository.GetQuerable()
                .Select(a => new TaxFeeDto
                {
                    Id = a.Id,
                    StartTime = a.StartTime,
                    EndTime = a.EndTime,
                    Fee = a.Fee
                }).ToListAsync();
        }

        public async Task UpdateFee(TaxFeeDto taxFee)
        {
            var fee = await _taxFeeRepository.GetQuerable()
                .AsTracking()
                .Where(x => x.Id == taxFee.Id)
                .FirstOrDefaultAsync();

            if (fee == null) throw new ArgumentNullException("Fee Not Found");
            fee.Update(taxFee.StartTime, taxFee.EndTime, taxFee.Fee);
            await _taxFeeRepository.Update(fee);
        }
    }
}
