//--------------------------------------------------------------------------
// <copyright file="PrizeMoneyCalculationServiceTest.cs" company="Front Range Systems, LLC">
//     Copyright (c) 2017 Front Range Systems, LLC. All rights reserved.
//     You are free to use this source code as you wish. Front Range Systems, LLC is not
//     responsible for any bugs, errors, or resulting damage from problems
//     with this source code. We are, after all, human. This code is meant
//     to be used as a learning tool. 
// </copyright>
// <author>Matt Dixon</author>
//--------------------------------------------------------------------------
using System;
using FrontRangeSystems.UnitTesting.Services.Models;
using FrontRangeSystems.UnitTesting.TestingFramework;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FrontRangeSystems.UnitTesting.Services.MsTests
{
    [TestClass]
    public class PrizeMoneyCalculationServiceTest : MsTestBase<PrizeMoneyCalculationService>
    {
        protected override void TestInitializeInternal()
        {
            ItemUnderTest = new PrizeMoneyCalculationService();
        }

        private void CalculatePurseAndAssert(PrizeMoneyCalculationModel model, decimal expected)
        {
            var actual = ItemUnderTest.CalculatePurse(model);
            Assert.AreEqual(expected, actual, "Calculated purse does not equal expected purse.");
        }

        [TestMethod]
        public void PrizeMoneyCalculationServiceTest_CalculatePerPersonPayout_EmptyModel_ReturnsZero()
        {
            var actual = ItemUnderTest.CalculatePerPersonPayout(new PayoutCalculationModel());
            Assert.AreEqual(0, actual);
        }

        [TestMethod]
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

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void PrizeMoneyCalculationServiceTest_CalculatePerPersonPayout_NullModel_ReturnsZero()
        {
            var actual = ItemUnderTest.CalculatePerPersonPayout(null);
            Assert.AreEqual(0, actual);
        }

        [TestMethod]
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

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
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

        [TestMethod]
        public void PrizeMoneyCalculationServiceTest_CalculatePurse_NewModel_ReturnsZero()
        {
            CalculatePurseAndAssert(new PrizeMoneyCalculationModel(), 0);
        }

        [TestMethod]
        public void PrizeMoneyCalculationServiceTest_CalculatePurse_NullModel_ReturnsZero()
        {
            CalculatePurseAndAssert(null, 0);
        }

        [TestMethod]
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

        [TestMethod]
        public void PrizeMoneyCalculationServiceTest_Constructor_ItemUnderTest_Created()
        {
            Assert.IsNotNull(ItemUnderTest);
        }
    }
}