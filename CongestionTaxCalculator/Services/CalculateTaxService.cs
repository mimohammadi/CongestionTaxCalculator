using CongestionTaxCalculator.Enums;
using CongestionTaxCalculator.Interface;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CongestionTaxCalculator.Services
{
    public class CalculateTaxService : ICalculateTaxService
    {
        private readonly ITaxFeeService _taxFeeService;
        private readonly ITaxFreeRuleService _taxFreeRuleService;
        private readonly IMaxTaxService _maxTaxService;

        public CalculateTaxService(ITaxFeeService taxFeeService, 
            ITaxFreeRuleService taxFreeRuleService, 
            IMaxTaxService maxTaxService)
        {
            _taxFeeService = taxFeeService;
            _taxFreeRuleService = taxFreeRuleService;
            _maxTaxService = maxTaxService;
        }

        /// <summary>
        /// Tax Of One Day
        /// </summary>
        /// <param name="vehicle"></param>
        /// <param name="dates"></param>
        /// <returns></returns>
        public async Task<int> GetTax(Vehicles vehicle, DateTime[] dates)
        {
            DateTime intervalStart = dates[0];
            if (await _taxFreeRuleService.IsTaxFreeVehicle(vehicle) ||
                await _taxFreeRuleService.IsFreeDate(intervalStart))
                return 0;
            
            int totalFee = 0;
            int tempFee = await GetTaxFee(intervalStart);
            foreach (DateTime date in dates)
            {
                int nextFee = await GetTaxFee(date);
                
                var diffInMillies = date.TimeOfDay - intervalStart.TimeOfDay;

                if (diffInMillies <= new TimeSpan(1,0,0))
                {
                    if (totalFee > 0) totalFee -= tempFee;
                    if (nextFee >= tempFee) tempFee = nextFee;
                    totalFee += tempFee;
                }
                else
                {
                    totalFee += nextFee;
                }

                intervalStart = date;
                tempFee = nextFee;
            }

            var max = await _maxTaxService.GetMaxTax();
            if (max > 0)
            {
                if (totalFee > max) totalFee = max;
            }
            return totalFee;
        }

        private async Task<int> GetTaxFee(DateTime date)
        {
            var fees = await _taxFeeService.GetFeeList();
            if(fees == null) return 0;

            var time = new TimeSpan(date.Hour, date.Minute, date.Second);

            var fee = fees.Where(a => a.StartTime <= time && time <= a.EndTime).FirstOrDefault();
            if (fee != null)
                return fee.Fee;

            return 0;
        }
    }
}
