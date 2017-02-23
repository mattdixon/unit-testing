using System;
using FrontRangeSystems.UnitTesting.Services.Contracts;
using FrontRangeSystems.UnitTesting.Services.Models;

namespace FrontRangeSystems.UnitTesting.Services
{
    public class PrizeMoneyCalculationService : IPrizeMoneyCalculationService
    {
        /// <inheritdoc />
        public decimal CalculatePurse(PrizeMoneyCalculationModel model)
        {
            var purse = 0M;

            if (model != null)
            {
                purse += model.Entrants * model.EntryFee;
                var deuction = model.Deduction * purse;
                purse -= deuction;
                purse += model.SponsorMoney;
            }

            return purse;
        }

        /// <inheritdoc />
        public decimal CalculatePerPersonPayout(PayoutCalculationModel model)
        {
            if (model == null || model.PayoutPlaces <= 0)
            {
                return 0;
            }

            var purse = CalculatePurse(model);
            var payout = purse / model.PayoutPlaces;
            // remove trailing decimal places - extra pennies go away
            payout = Math.Floor(payout * 100) / 100;
            return payout;
        }
    }
}