using System;
using FrontRangeSystems.UnitTesting.Services.Models;
using FrontRangeSystems.UnitTesting.TestingFramework;
using NUnit.Framework;

namespace FrontRangeSystems.UnitTesting.Services.NUnitTests
{
    [TestFixture]
    public class PrizeMoneyCalculationServiceTest : NUnitTestBase<PrizeMoneyCalculationService>
    {
        protected override void SetupInternal()
        {
            ItemUnderTest = new PrizeMoneyCalculationService();
        }

        private void CalculatePurseAndAssert(PrizeMoneyCalculationModel model, decimal expected)
        {
            var actual = ItemUnderTest.CalculatePurse(model);
            Assert.That(actual, Is.EqualTo(expected), "Calculated purse does not equal expected purse.");
        }

        [Test]
        public void PrizeMoneyCalculationServiceTest_CalculatePerPersonPayout_EmptyModel_ReturnsZero()
        {
            var actual = ItemUnderTest.CalculatePerPersonPayout(new PayoutCalculationModel());
            Assert.That(actual, Is.EqualTo(0));
        }

        [Test]
        public void PrizeMoneyCalculationServiceTest_CalculatePerPersonPayout_KnownValues_ReturnsExpected()
        {
            var model = new PayoutCalculationModel
            {
                Deduction = .06M,
                Entrants = 50,
                EntryFee = 100,
                SponsorMoney = 200,
                PayoutPlaces = 5
            };

            // 50 * 100 - 300 + 200 = 4900 split 5 ways = 980
            var expected = 980;

            var actual = ItemUnderTest.CalculatePerPersonPayout(model);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void PrizeMoneyCalculationServiceTest_CalculatePerPersonPayout_NullModel_ReturnsZero()
        {
            var actual = ItemUnderTest.CalculatePerPersonPayout(null);
            Assert.That(actual, Is.EqualTo(0));
        }

        [Test]
        public void PrizeMoneyCalculationServiceTest_CalculatePerPersonPayout_RandomValues_ReturnsExpectedCalculation()
        {
            var model = new PayoutCalculationModel
            {
                Deduction = Random.NextDecimal(),
                Entrants = Random.Next(100),
                EntryFee = Random.NextDecimal(1000),
                SponsorMoney = Random.NextDecimal(500),
                PayoutPlaces = Random.Next(10)
            };

            var expected = model.Entrants * model.EntryFee;
            var deduction = expected * model.Deduction;
            expected -= deduction;
            expected += model.SponsorMoney;
            expected /= model.PayoutPlaces;
            // remove any leftover pennies
            expected = Math.Floor(expected * 100) / 100;

            var actual = ItemUnderTest.CalculatePerPersonPayout(model);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void PrizeMoneyCalculationServiceTest_CalculatePurse_KnownValues_KnownResult()
        {
            var model = new PrizeMoneyCalculationModel
            {
                Entrants = 10,
                EntryFee = 100,
                Deduction = .04M,
                SponsorMoney = 500
            };

            // 10 * 100 - 4% fee + sponsor money
            // 1000     - 40     + 500  = 1460
            var expected = 1460M;
            CalculatePurseAndAssert(model, expected);
        }

        [Test]
        public void PrizeMoneyCalculationServiceTest_CalculatePurse_NewModel_ReturnsZero()
        {
            CalculatePurseAndAssert(new PrizeMoneyCalculationModel(), 0);
        }

        [Test]
        public void PrizeMoneyCalculationServiceTest_CalculatePurse_NullModel_ReturnsZero()
        {
            CalculatePurseAndAssert(null, 0);
        }

        [Test]
        public void PrizeMoneyCalculationServiceTest_CalculatePurse_ValidRandomValues_CalculatesSuccessfully()
        {
            var model = new PrizeMoneyCalculationModel
            {
                Entrants = Random.Next<int>(),
                EntryFee = Random.Next<decimal>(),
                Deduction = Random.NextDecimal(),
                SponsorMoney = Random.Next<decimal>()
            };

            var expected = model.Entrants * model.EntryFee;
            expected = expected - expected * model.Deduction;
            expected += model.SponsorMoney;

            CalculatePurseAndAssert(model, expected);
        }

        [Test]
        public void PrizeMoneyCalculationServiceTest_Constructor_ItemUnderTest_Created()
        {
            Assert.That(ItemUnderTest, Is.Not.Null);
        }
    }
}