using Microsoft.AspNetCore.Mvc;
using ChangeCalculator.API.Models;
using ChangeCalculator.API.Services;

namespace ChangeCalculator.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChangeController : ControllerBase
    {
        private readonly IChangeCalculatorService ChangeCalculatorService;

        public ChangeController(IChangeCalculatorService changeCalculatorService)
        {
            ChangeCalculatorService = changeCalculatorService;
        }

        // Calculates the minimum number of banknotes and coins required for a given amount in South African Rands.
        [HttpPost("calculate")]
        [ProducesResponseType(typeof(ChangeResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult CalculateChange([FromBody] ChangeRequest request)
        {
            try
            {
                if (request.Amount < 0)
                    return BadRequest("Amount cannot be negative. Please enter a positive amount.");

                var result = ChangeCalculatorService.CalculateChange(request.Amount);
                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An unexpected error occurred. Please try again later.");
            }
        }
    }
}