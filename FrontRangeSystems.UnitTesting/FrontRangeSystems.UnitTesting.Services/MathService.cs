//--------------------------------------------------------------------------
// <copyright file="MathService.cs" company="Front Range Systems, LLC">
//     Copyright (c) 2017 Front Range Systems, LLC. All rights reserved.
//     You are free to use this source code as you wish. Front Range Systems, LLC is not
//     responsible for any bugs, errors, or resulting damage from problems
//     with this source code. We are, after all, human. This code is meant
//     to be used as a learning tool. 
// </copyright>
// <author>Matt Dixon</author>
//--------------------------------------------------------------------------

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