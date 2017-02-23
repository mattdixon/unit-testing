using System.Web.Mvc;
using FrontRangeSystems.UnitTesting.TestingFramework;
using FrontRangeSystems.UnitTesting.WebClient.Controllers;
using FrontRangeSystems.UnitTesting.WebClient.Models;
using NUnit.Framework;

namespace FrontRangeSystems.UnitTesting.WebClient.NUnitTests.Controller
{
    [TestFixture]
    public class HomeControllerTest : NUnitTestBase<HomeController>
    {
        protected override void SetupInternal()
        {
            ItemUnderTest = new HomeController();
        }

        [Test]
        public void HomeControllerTest_Add_RandomDecimals_SetsFirstAndSecondPropertyValues()
        {
            var first = Random.NextDecimal(1000);
            var second = Random.NextDecimal(1000);
            var expected = new MathOperationModel {First = first, Second = second};

            var result = ItemUnderTest.CreateMathModel(first, second) as ViewResult;
            Assert.That(result, Is.Not.Null);

            var actual = result.Model as MathOperationModel;
            Assert.That(actual, Is.Not.Null);

            Assert.That(actual.Second, Is.EqualTo(expected.Second));
            Assert.That(actual.Second, Is.EqualTo(expected.Second));
        }

        [Test]
        public void HomeControllerTest_Constructor_NotNull()
        {
            Assert.IsNotNull(ItemUnderTest);
        }

        [Test]
        public void HomeControllerTest_Index_SetsViewBagTitle()
        {
            var expected = "Home Page";

            var result = ItemUnderTest.Index() as ViewResult;
            Assert.That(result, Is.Not.Null);
            Assert.That(result.ViewBag, Is.Not.Null);

            var actual = result.ViewBag.Title;
            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}