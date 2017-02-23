//--------------------------------------------------------------------------
// <copyright file="PrizeMoneyCalculationService.cs" company="Front Range Systems, LLC">
//     Copyright (c) 2017 Front Range Systems, LLC. All rights reserved.
//     You are free to use this source code as you wish. Front Range Systems, LLC is not
//     responsible for any bugs, errors, or resulting damage from problems
//     with this source code. We are, after all, human. This code is meant
//     to be used as a learning tool. 
// </copyright>
// <author>Matt Dixon</author>
//--------------------------------------------------------------------------

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