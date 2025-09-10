using ChangeCalculator.API.Models;

namespace ChangeCalculator.API.Services
{
    public interface IChangeCalculatorService
    {
        ChangeResponse CalculateChange(decimal amount);
    }
}