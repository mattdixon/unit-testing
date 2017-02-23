namespace FrontRangeSystems.UnitTesting.Services.Contracts
{
    public interface IMathService
    {
        /// <summary>
        ///     Adds two numbers.
        /// </summary>
        /// <param name="first">The first number to add.</param>
        /// <param name="second">The second number to add.</param>
        /// <returns></returns>
        decimal Add(decimal first, decimal second);

        /// <summary>
        ///     Subtracts the second number from the first number.
        /// </summary>
        /// <param name="first">The first number.</param>
        /// <param name="second">The second number.</param>
        /// <returns></returns>
        decimal Subtract(decimal first, decimal second);

        /// <summary>
        ///     Multiplies the specified numbers.
        /// </summary>
        /// <param name="first">The first number.</param>
        /// <param name="second">The second number.</param>
        /// <returns></returns>
        decimal Multilpy(decimal first, decimal second);

        /// <summary>
        ///     Divides the specified dividend by the specified divisor.
        /// </summary>
        /// <param name="dividend">The dividend.</param>
        /// <param name="divisor">The divisor.</param>
        /// <returns></returns>
        decimal Divide(decimal dividend, decimal divisor);
    }
}