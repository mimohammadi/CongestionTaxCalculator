using CongestionTaxCalculator.Dto;
using CongestionTaxCalculator.Interface;
using CongestionTaxCalculator.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CongestionTaxCalculator.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MaxTaxController : ControllerBase
    {
        private readonly IMaxTaxService _maxTaxService;

        public MaxTaxController(IMaxTaxService maxTaxService)
        {
            _maxTaxService = maxTaxService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(MaxTaxCreateDto dto)
        {
            await _maxTaxService.AddMaxAmount(dto);
            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _maxTaxService.DeleteAmount(id);
            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> Update(MaxTaxDto dto)
        {
            await _maxTaxService.UpdateAmount(dto);
            return NoContent();
        }
    }
}
