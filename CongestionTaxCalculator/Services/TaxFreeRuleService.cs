using CongestionTaxCalculator.Dto;
using CongestionTaxCalculator.Enums;
using CongestionTaxCalculator.Interface;
using CongestionTaxCalculator.Models.TaxFreeRules;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CongestionTaxCalculator.Services
{
    public class TaxFreeRuleService : ITaxFreeRuleService
    {
        private readonly ITaxFreeRuleRepository _taxFreeRuleRepository;

        public TaxFreeRuleService(ITaxFreeRuleRepository taxFreeRuleRepository)
        {
            _taxFreeRuleRepository = taxFreeRuleRepository;
        }

        public async Task AddTaxFreeRule(TaxFreeRuleCreateDto taxFreeRule)
        {
            switch (taxFreeRule.Category)
            {
                case Enums.RuleCategory.Date:
                    if(taxFreeRule.Date == null)
                        throw new ArgumentNullException(nameof(taxFreeRule.Date));
                    await _taxFreeRuleRepository.Add(new TaxFreeDate(taxFreeRule.Date.Value));
                    break;

                case Enums.RuleCategory.Day_Of_Week:
                    if (taxFreeRule.Day == null)
                        throw new ArgumentNullException(nameof(taxFreeRule.Day));
                    await _taxFreeRuleRepository.Add(new TaxFreeDayOfWeek(taxFreeRule.Day.Value));
                    break;

                case Enums.RuleCategory.Month:
                    if (taxFreeRule.Month == null)
                        throw new ArgumentNullException(nameof(taxFreeRule.Month));
                    await _taxFreeRuleRepository.Add(new TaxFreeMonth(taxFreeRule.Month.Value));
                    break;

                case Enums.RuleCategory.Vehicle:
                    if (taxFreeRule.Vehicle == null)
                        throw new ArgumentNullException(nameof(taxFreeRule.Vehicle));
                    await _taxFreeRuleRepository.Add(new TaxFreeVehicle(taxFreeRule.Vehicle.Value));

                    break;
                default:
                    
                    break;
            }
        }

        public async Task DeleteRule(int id)
        {
            var rule = await _taxFreeRuleRepository.GetQuerable()
                .AsTracking()
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();

            if (rule == null) throw new ArgumentNullException("Rule Not Found");
            rule.Delete();
            await _taxFreeRuleRepository.Update(rule);
        }

        /// <summary>
        /// به دلیل اینکه قوانین اگر قبلا استفاده شده به معنای اینکه تکس با آن قانون محاسبه شده باشد نباید آپدیت شه و اینجا ما رکورد تکس ها را ذخیره نمی کنیم 
        /// اگر ویرایشی در قوانین بود رکورد قبلی حذف و رکورد جدید ایجاد کردم.
        /// </summary>
        /// <param name="taxFreeRule"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task UpdateRule(TaxFreeRuleDto taxFreeRule)
        {
            var rule = await _taxFreeRuleRepository.GetQuerable()
                .AsTracking()
                .Where(x => x.Id == taxFreeRule.Id)
                .FirstOrDefaultAsync();

            if (rule == null) throw new ArgumentNullException("Rule Not Found");

            rule.Delete();
            await _taxFreeRuleRepository.Update(rule);

            await AddTaxFreeRule(new TaxFreeRuleCreateDto
            {
                Category = taxFreeRule.Category,
                Date = taxFreeRule.Date,
                Day = taxFreeRule.Day,
                Month = taxFreeRule.Month,
                Vehicle = taxFreeRule.Vehicle,
            });
        }

        public async Task<bool> IsTaxFreeVehicle(Vehicles vehicle)
        {
            return await _taxFreeRuleRepository.GetQuerable()
                .AsNoTracking()
                .OfType<TaxFreeVehicle>()
                .AnyAsync(x => x.Vehicle == vehicle);
        }

        public async Task<bool> IsFreeDate(DateTime date)
        {
            int month = date.Month;

            var rules = await _taxFreeRuleRepository.GetQuerable()
                .ToListAsync();

            if(rules == null || rules.Count == 0) return false;

            if(rules.OfType<TaxFreeDayOfWeek>().Any(a=>a.Day == date.DayOfWeek))
                return true;

            if(rules.OfType<TaxFreeMonth>().Any(a=>a.Month == month))
                return true;

            if(rules.OfType<TaxFreeDate>().Any(a=>a.Date.Date == date.Date))
                return true;

            return false;
        }
    }
}
