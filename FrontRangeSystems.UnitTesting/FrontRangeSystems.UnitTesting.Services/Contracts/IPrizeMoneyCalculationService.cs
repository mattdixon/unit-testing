using FrontRangeSystems.UnitTesting.Services.Models;

namespace FrontRangeSystems.UnitTesting.Services.Contracts
{
    public interface IPrizeMoneyCalculationService
    {
        /// <summary>
        ///     Calculates the purse.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        decimal CalculatePurse(PrizeMoneyCalculationModel model);

        /// <summary>
        ///     Calculates the per person payout amount.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        decimal CalculatePerPersonPayout(PayoutCalculationModel model);
    }
}