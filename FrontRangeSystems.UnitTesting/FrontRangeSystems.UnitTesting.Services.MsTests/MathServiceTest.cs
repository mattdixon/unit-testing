using System;
using FrontRangeSystems.UnitTesting.TestingFramework;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
// default to NUnit Asserts
using Assert = NUnit.Framework.Assert;

namespace FrontRangeSystems.UnitTesting.Services.MsTests
{
    [TestClass]
    public class MathServiceTest:MsTestBase<MathService>
    {
        protected override void TestInitializeInternal()
        {
            ItemUnderTest = new MathService();
        }

        private void SubtractAndAssert(decimal first, decimal second, decimal expected)
        {
            var actual = ItemUnderTest.Subtract(first, second);
            // MSTest Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(expected, actual);
            // NUnit Assert
            Assert.That(actual, Is.EqualTo(expected));
        }

        private void AddAndAssert(decimal first, decimal second, decimal expected)
        {
            var actual = ItemUnderTest.Add(first, second);
            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestMethod]
        public void MathServiceTest_Add_WithBothZero_ReturnsZero()
        {
            AddAndAssert(0, 0, 0);
        }

        [TestMethod]
        public void MathServiceTest_Add_WithMax_ThrowsOverflowException()
        {
            Assert.Throws<OverflowException>(() => AddAndAssert(decimal.MaxValue, 1, 0));
        }

        [TestMethod]
        public void MathServiceTest_Add_WithValidPositiveIntigers_ReturnsSum()
        {
            var first = Random.NextDecimal(1000);
            var second = Random.NextDecimal(1000);
            AddAndAssert(first, second, first + second);
        }

        [TestMethod]
        public void MathServiceTest_Divide_ByZero_OnlyChuckNorrisCan()
        {
            Assert.Throws<DivideByZeroException>(() => ItemUnderTest.Divide(Random.NextDecimal(1000), 0));
        }

        [TestMethod]
        public void MathServiceTest_Divide_RandomNumbers_ReturnsQuotient()
        {
            var first = Random.NextDecimal(1000);
            var second = Random.NextDecimal(1000);
            var expected = decimal.Divide(first, second);

            var actual = ItemUnderTest.Divide(first, second);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestMethod]
        public void MathServiceTest_Multiply_MaxValue_ThrowsOverflowException()
        {
            Assert.Throws<OverflowException>(() => ItemUnderTest.Multilpy(decimal.MaxValue, decimal.MaxValue));
        }

        [TestMethod]
        public void MathServiceTest_Multiply_NegativeNumbers_ReturnsPositiveNumber()
        {
            var first = Random.NextDecimal(1000) * -1;
            var second = Random.NextDecimal(1000) * -1;

            var actual = ItemUnderTest.Multilpy(first, second);

            Assert.That(actual, Is.Positive);
        }

        [TestMethod]
        public void MathServiceTest_Multiply_OneNegativeNumber_ReturnsNegativeNumber()
        {
            var first = Random.NextDecimal(1000);
            var second = Random.NextDecimal(1000) * -1;

            var actual = ItemUnderTest.Multilpy(first, second);

            Assert.That(actual, Is.Negative);
        }

        [TestMethod]
        public void MathServiceTest_Multiply_RandomValues_ReturnsProduct()
        {
            var first = Random.NextDecimal(1000);
            var second = Random.NextDecimal(1000);
            var expected = first * second;

            var actual = ItemUnderTest.Multilpy(first, second);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestMethod]
        public void MathServiceTest_Subtract_RandomValues_ReturnsDifference()
        {
            var first = Random.NextDecimal(1000);
            var second = Random.NextDecimal(1000);
            SubtractAndAssert(first, second, first - second);
        }

        [TestMethod]
        public void MathServiceTest_Subtract_WithMin_ThrowsOverflowException()
        {
            Assert.Throws<OverflowException>(() => ItemUnderTest.Subtract(decimal.MinValue, 1));
        }
    }
}