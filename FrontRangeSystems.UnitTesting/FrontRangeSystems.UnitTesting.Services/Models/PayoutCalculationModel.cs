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