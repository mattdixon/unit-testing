//--------------------------------------------------------------------------
// <copyright file="HomeControllerTest.cs" company="Front Range Systems, LLC">
//     Copyright (c) 2017 Front Range Systems, LLC. All rights reserved.
//     You are free to use this source code as you wish. Front Range Systems, LLC is not
//     responsible for any bugs, errors, or resulting damage from problems
//     with this source code. We are, after all, human. This code is meant
//     to be used as a learning tool. 
// </copyright>
// <author>Matt Dixon</author>
//--------------------------------------------------------------------------
using System.Web.Mvc;
using FrontRangeSystems.UnitTesting.TestingFramework;
using FrontRangeSystems.UnitTesting.WebClient.Controllers;
using FrontRangeSystems.UnitTesting.WebClient.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FrontRangeSystems.UnitTesting.WebClient.MsTests.Controllers
{
    [TestClass]
    public class HomeControllerTest : MsTestBase<HomeController>
    {
        protected override void TestInitializeInternal()
        {
            ItemUnderTest = new HomeController();
        }

        [TestMethod]
        public void HomeControllerTest_Constructor_NotNull()
        {
            Assert.IsNotNull(ItemUnderTest);
        }

        [TestMethod]
        public void HomeControllerTest_Index_SetsViewBagTitle()
        {
            var expected = "Home Page";

            var result = ItemUnderTest.Index() as ViewResult;
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.ViewBag);

            var actual = result.ViewBag.Title;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void HomeControllerTest_Add_RandomDecimals_SetsFirstAndSecondPropertyValues()
        {
            var first = Random.NextDecimal(1000);
            var second = Random.NextDecimal(1000);
            var expected = new MathOperationModel {First = first, Second = second};

            var result = ItemUnderTest.CreateMathModel(first, second) as ViewResult;
            Assert.IsNotNull(result);

            var actual = result.Model as MathOperationModel;
            Assert.IsNotNull(actual);

            Assert.AreEqual(expected.First, actual.First);
            Assert.AreEqual(expected.Second, actual.Second);
        }
    }
}