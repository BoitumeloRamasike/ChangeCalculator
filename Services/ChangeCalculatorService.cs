using ChangeCalculator.API.Models;

namespace ChangeCalculator.API.Services
{
    public class ChangeCalculatorService : IChangeCalculatorService
    {
        private readonly decimal[] denominations = {
            200m, 100m, 50m, 20m, 10m,  // Banknotes
            5m, 2m, 1m, 0.5m, 0.2m, 0.1m  // Coins
        };

        public ChangeResponse CalculateChange(decimal amount)
        {
            if (amount < 0)
                throw new ArgumentException("Amount cannot be negative. Please enter a positive amount.", nameof(amount));

            var response = new ChangeResponse();
            var remainingAmount = amount;

            foreach (var denomination in denominations)
            {
                var count = (int)(remainingAmount / denomination);
                remainingAmount %= denomination;
                remainingAmount = Math.Round(remainingAmount, 2); 

                SetDenominationCount(response, denomination, count);
            }

            return response;
        }

        private void SetDenominationCount(ChangeResponse response, decimal denomination, int count)
        {
            switch (denomination)
            {
                case 200m: response.R200 = count; break;
                case 100m: response.R100 = count; break;
                case 50m: response.R50 = count; break;
                case 20m: response.R20 = count; break;
                case 10m: response.R10 = count; break;
                case 5m: response.R5 = count; break;
                case 2m: response.R2 = count; break;
                case 1m: response.R1 = count; break;
                case 0.5m: response.FiftyC = count; break;
                case 0.2m: response.TwentyC = count; break;
                case 0.1m: response.TenC = count; break;
            }
        }
    }
}