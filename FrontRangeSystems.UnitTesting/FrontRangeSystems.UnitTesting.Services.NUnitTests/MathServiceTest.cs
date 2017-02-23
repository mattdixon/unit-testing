//--------------------------------------------------------------------------
// <copyright file="MathServiceTest.cs" company="Front Range Systems, LLC">
//     Copyright (c) 2017 Front Range Systems, LLC. All rights reserved.
//     You are free to use this source code as you wish. Front Range Systems, LLC is not
//     responsible for any bugs, errors, or resulting damage from problems
//     with this source code. We are, after all, human. This code is meant
//     to be used as a learning tool. 
// </copyright>
// <author>Matt Dixon</author>
//--------------------------------------------------------------------------

using System;
using FrontRangeSystems.UnitTesting.TestingFramework;
using NUnit.Framework;

namespace FrontRangeSystems.UnitTesting.Services.NUnitTests
{
    [TestFixture]
    public class MathServiceTest : NUnitTestBase<MathService>
    {
        protected override void SetupInternal()
        {
            ItemUnderTest = new MathService();
        }

        private void SubtractAndAssert(decimal first, decimal second, decimal expected)
        {
            var actual = ItemUnderTest.Subtract(first, second);
            Assert.That(actual, Is.EqualTo(expected));
        }

        private void AddAndAssert(decimal first, decimal second, decimal expected)
        {
            var actual = ItemUnderTest.Add(first, second);
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void MathServiceTest_Add_WithBothZero_ReturnsZero()
        {
            AddAndAssert(0, 0, 0);
        }

        [Test]
        public void MathServiceTest_Add_WithMax_ThrowsOverflowException()
        {
            Assert.Throws<OverflowException>(() => AddAndAssert(decimal.MaxValue, 1, 0));
        }

        [Test]
        public void MathServiceTest_Add_WithValidPositiveIntigers_ReturnsSum()
        {
            var first = Random.NextDecimal(1000);
            var second = Random.NextDecimal(1000);
            AddAndAssert(first, second, first + second);
        }

        [Test]
        public void MathServiceTest_Divide_ByZero_OnlyChuckNorrisCan()
        {
            Assert.Throws<DivideByZeroException>(() => ItemUnderTest.Divide(Random.NextDecimal(1000), 0));
        }

        [Test]
        public void MathServiceTest_Divide_RandomNumbers_ReturnsQuotient()
        {
            var first = Random.NextDecimal(1000);
            var second = Random.NextDecimal(1000);
            var expected = decimal.Divide(first, second);

            var actual = ItemUnderTest.Divide(first, second);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void MathServiceTest_Multiply_MaxValue_ThrowsOverflowException()
        {
            Assert.Throws<OverflowException>(() => ItemUnderTest.Multilpy(decimal.MaxValue, decimal.MaxValue));
        }

        [Test]
        public void MathServiceTest_Multiply_NegativeNumbers_ReturnsPositiveNumber()
        {
            var first = Random.NextDecimal(1000) * -1;
            var second = Random.NextDecimal(1000) * -1;

            var actual = ItemUnderTest.Multilpy(first, second);

            Assert.That(actual, Is.Positive);
        }

        [Test]
        public void MathServiceTest_Multiply_OneNegativeNumber_ReturnsNegativeNumber()
        {
            var first = Random.NextDecimal(1000);
            var second = Random.NextDecimal(1000) * -1;

            var actual = ItemUnderTest.Multilpy(first, second);

            Assert.That(actual, Is.Negative);
        }

        [Test]
        public void MathServiceTest_Multiply_RandomValues_ReturnsProduct()
        {
            var first = Random.NextDecimal(1000);
            var second = Random.NextDecimal(1000);
            var expected = first * second;

            var actual = ItemUnderTest.Multilpy(first, second);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void MathServiceTest_Subtract_RandomValues_ReturnsDifference()
        {
            var first = Random.NextDecimal(1000);
            var second = Random.NextDecimal(1000);
            SubtractAndAssert(first, second, first - second);
        }

        [Test]
        public void MathServiceTest_Subtract_WithMin_ThrowsOverflowException()
        {
            Assert.Throws<OverflowException>(() => ItemUnderTest.Subtract(decimal.MinValue, 1));
        }
    }
}