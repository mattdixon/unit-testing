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