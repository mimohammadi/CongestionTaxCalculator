using CongestionTaxCalculator.Dto;
using CongestionTaxCalculator.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CongestionTaxCalculator.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TaxFeeController : ControllerBase
    {
        private readonly ITaxFeeService _taxFeeService;

        public TaxFeeController(ITaxFeeService taxFeeService)
        {
            _taxFeeService = taxFeeService;
        }

        /// <summary>
        /// Adding New Fee
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create(TaxFeeCreateDto dto)
        {
            await _taxFeeService.AddFee(dto);
            return NoContent();
        }

        /// <summary>
        /// List Of Fees
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaxFeeDto>>> GetList()
        {
            var result = await _taxFeeService.GetFeeList();
            if (result == null) return NoContent();
            return Ok(result);
        }


        /// <summary>
        /// Delete Fee
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _taxFeeService.DeleteFee(id);
            return NoContent();
        }

        ///// <summary>
        ///// Update Fee
        ///// </summary>
        ///// <param name="dto"></param>
        ///// <returns></returns>
        //[HttpPut]
        //public async Task<IActionResult> Update(TaxFeeDto dto)
        //{
        //    await _taxFeeService.UpdateFee(dto);
        //    return NoContent();
        //}
    }
}
