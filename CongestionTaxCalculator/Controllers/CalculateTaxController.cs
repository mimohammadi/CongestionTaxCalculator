using CongestionTaxCalculator.Enums;
using CongestionTaxCalculator.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace CongestionTaxCalculator.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CalculateTaxController : ControllerBase
    {
        private readonly ICalculateTaxService _taxService;

        public CalculateTaxController(ICalculateTaxService taxService)
        {
            _taxService = taxService;
        }

        [HttpPost]
        public async Task<ActionResult<int>> CalculateTax(Vehicles vehicle, DateTime[] dates) 
        {
            var result = await _taxService.GetTax(vehicle, dates);
            return Ok(result);
        }
    }
}
