//--------------------------------------------------------------------------
// <copyright file="ShellViewModelTest.cs" company="Front Range Systems, LLC">
//     Copyright (c) 2017 Front Range Systems, LLC. All rights reserved.
//     You are free to use this source code as you wish. Front Range Systems, LLC is not
//     responsible for any bugs, errors, or resulting damage from problems
//     with this source code. We are, after all, human. This code is meant
//     to be used as a learning tool. 
// </copyright>
// <author>Matt Dixon</author>
//--------------------------------------------------------------------------

using FrontRangeSystems.UnitTesting.Services.Contracts;
using FrontRangeSystems.UnitTesting.Services.Models;
using FrontRangeSystems.UnitTesting.TestingFramework;
using FrontRangeSystems.UnitTesting.WindowsClient.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace FrontRangeSystems.UnitTesting.WindowsClient.MsTests.ViewModel
{
    [TestClass]
    public class ShellViewModelTest : MsTestBase<ShellViewModel>
    {
        private Mock<IMathService> MockMathService { get; set; }
        private Mock<IPrizeMoneyCalculationService> MockPrizeMoneyCalculationService { get; set; }

        private string AddOperator => "+";
        private string SubtractOperator => "-";
        private string MultiplyOperator => "*";
        private string DivideOperator => "/";

        protected override void TestInitializeInternal()
        {
            MockMathService = new Mock<IMathService>();
            MockPrizeMoneyCalculationService = new Mock<IPrizeMoneyCalculationService>();

            ItemUnderTest = new ShellViewModel(MockMathService.Object, MockPrizeMoneyCalculationService.Object);
        }

        [TestMethod]
        public void ShellViewModelTest_Add_ValidModel_CallsAddService()
        {
            ItemUnderTest.SelectedOperator = AddOperator;

            // verify with any decimal parameters
            MockMathService.Verify(m => m.Add(It.IsAny<decimal>(), It.IsAny<decimal>()));
        }

        [TestMethod]
        public void ShellViewModelTest_Add_ValidModel_CallsAddServiceWithSpecificValues()
        {
            ItemUnderTest.First = Random.NextDecimal();
            ItemUnderTest.Second = Random.NextDecimal();
            ItemUnderTest.SelectedOperator = AddOperator;

            // verify with specific parameter values
            MockMathService.Verify(m => m.Add(ItemUnderTest.First, ItemUnderTest.Second));
        }

        [TestMethod]
        public void ShellViewModelTest_Add_ValidModel_ReturnsExpectedResults()
        {
            var first = 3;
            var second = 4;
            var expected = first + second;

            MockMathService.Setup(m => m.Add(first, second)).Returns(expected);

            ItemUnderTest.First = first;
            ItemUnderTest.Second = second;
            ItemUnderTest.SelectedOperator = AddOperator;

            Assert.IsNotNull(ItemUnderTest.MathResult);
            Assert.AreEqual(expected, ItemUnderTest.MathResult);
        }

        [TestMethod]
        public void ShellViewModelTest_Constructor_IsNotNull()
        {
            Assert.IsNotNull(ItemUnderTest);
        }

        [TestMethod]
        public void ShellViewModelTest_CalculatePrizeMoney_ValidModel_CallsPrizeMoneyCalculationService_CalculatePurse()
        {
            ItemUnderTest.EntryFee = Random.NextDecimal();
            MockPrizeMoneyCalculationService.Verify(m => m.CalculatePurse(It.IsAny<PrizeMoneyCalculationModel>()));
        }

        [TestMethod]
        public void ShellViewModelTest_CalculatePrizeMoney_ValidModel_CallsPrizeMoneyCalculationService_CalculatePerPersonPayout()
        {
            ItemUnderTest.EntryFee = Random.NextDecimal();
            MockPrizeMoneyCalculationService.Verify(m => m.CalculatePerPersonPayout(It.IsAny<PayoutCalculationModel>()));
        }
    }
}