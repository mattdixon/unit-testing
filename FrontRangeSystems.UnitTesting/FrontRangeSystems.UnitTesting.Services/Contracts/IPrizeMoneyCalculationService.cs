//--------------------------------------------------------------------------
// <copyright file="IPrizeMoneyCalculationService.cs" company="Front Range Systems, LLC">
//     Copyright (c) 2017 Front Range Systems, LLC. All rights reserved.
//     You are free to use this source code as you wish. Front Range Systems, LLC is not
//     responsible for any bugs, errors, or resulting damage from problems
//     with this source code. We are, after all, human. This code is meant
//     to be used as a learning tool. 
// </copyright>
// <author>Matt Dixon</author>
//--------------------------------------------------------------------------

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