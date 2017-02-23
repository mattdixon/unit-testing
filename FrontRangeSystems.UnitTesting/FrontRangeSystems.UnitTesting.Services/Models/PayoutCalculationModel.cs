//--------------------------------------------------------------------------
// <copyright file="PayoutCalculationModel.cs" company="Front Range Systems, LLC">
//     Copyright (c) 2017 Front Range Systems, LLC. All rights reserved.
//     You are free to use this source code as you wish. Front Range Systems, LLC is not
//     responsible for any bugs, errors, or resulting damage from problems
//     with this source code. We are, after all, human. This code is meant
//     to be used as a learning tool. 
// </copyright>
// <author>Matt Dixon</author>
//--------------------------------------------------------------------------

namespace FrontRangeSystems.UnitTesting.Services.Models
{
    public class PayoutCalculationModel : PrizeMoneyCalculationModel
    {
        /// <summary>
        ///     Gets or sets the number of places for the payout.
        /// </summary>
        /// <value>
        ///     The payout places.
        /// </value>
        public int PayoutPlaces { get; set; }
    }
}