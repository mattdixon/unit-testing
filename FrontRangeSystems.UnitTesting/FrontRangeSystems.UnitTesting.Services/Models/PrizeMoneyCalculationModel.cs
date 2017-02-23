//--------------------------------------------------------------------------
// <copyright file="PrizeMoneyCalculationModel.cs" company="Front Range Systems, LLC">
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
    public class PrizeMoneyCalculationModel
    {
        /// <summary>
        ///     Gets or sets the entry fee per contestant.
        /// </summary>
        /// <value>
        ///     The entry fee.
        /// </value>
        public decimal EntryFee { get; set; }

        /// <summary>
        ///     Gets or sets the number of entrants (contestants).
        /// </summary>
        /// <value>
        ///     The entrants.
        /// </value>
        public int Entrants { get; set; }

        /// <summary>
        ///     Gets or sets the deduction percentage.
        /// </summary>
        /// <value>
        ///     The deduction.
        /// </value>
        public decimal Deduction { get; set; }

        /// <summary>
        ///     Gets or sets the sponsor money.
        /// </summary>
        /// <value>
        ///     The sponsor money.
        /// </value>
        public decimal SponsorMoney { get; set; }
    }
}