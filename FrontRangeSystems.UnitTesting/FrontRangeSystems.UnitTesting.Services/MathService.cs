using FrontRangeSystems.UnitTesting.Services.Contracts;

namespace FrontRangeSystems.UnitTesting.Services
{
    public class MathService : IMathService
    {
        /// <inheritdoc />
        public decimal Add(decimal first, decimal second)
        {
            return first + second;
        }

        /// <inheritdoc />
        public decimal Subtract(decimal first, decimal second)
        {
            return first - second;
        }

        /// <inheritdoc />
        public decimal Multilpy(decimal first, decimal second)
        {
            return first * second;
        }

        /// <inheritdoc />
        public decimal Divide(decimal dividend, decimal divisor)
        {
            return decimal.Divide(dividend, divisor);
        }
    }
}