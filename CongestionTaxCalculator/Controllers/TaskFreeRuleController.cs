using CongestionTaxCalculator.Dto;
using CongestionTaxCalculator.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CongestionTaxCalculator.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TaskFreeRuleController : ControllerBase
    {
        private readonly ITaxFreeRuleService _taxFreeRuleService;

        public TaskFreeRuleController(ITaxFreeRuleService taxFreeRuleService)
        {
            _taxFreeRuleService = taxFreeRuleService;
        }

        /// <summary>
        /// Adding new rule
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create(TaxFreeRuleCreateDto dto)
        {
            await _taxFreeRuleService.AddTaxFreeRule(dto);
            return NoContent();
        }

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _taxFreeRuleService.DeleteRule(id);
            return NoContent();
        }

        /// <summary>
        /// update rule
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Update(TaxFreeRuleDto dto)
        {
            await _taxFreeRuleService.UpdateRule(dto);
            return NoContent();
        }
    }
}
