using System.Web.Http.Results;
using FrontRangeSystems.UnitTesting.Services.Contracts;
using FrontRangeSystems.UnitTesting.TestingFramework;
using FrontRangeSystems.UnitTesting.WebClient.Controllers.WebApi;
using FrontRangeSystems.UnitTesting.WebClient.Models;
using Moq;
using NUnit.Framework;

namespace FrontRangeSystems.UnitTesting.WebClient.NUnitTests.Controller.WebApi
{
    [TestFixture]
    public class MathControllerTest : NUnitTestBase<MathController>
    {
        private Mock<IMathService> MockMathService { get; set; }

        protected override void SetupInternal()
        {
            MockMathService = new Mock<IMathService>();

            ItemUnderTest = new MathController(MockMathService.Object);
        }

        [Test]
        public void MathControllerTest_Add_ValidModel_CallsAddInMathService()
        {
            ItemUnderTest.PostAdd(new MathOperationModel {First = Random.NextDecimal(), Second = Random.NextDecimal()});
            MockMathService.Verify(m => m.Add(It.IsAny<decimal>(), It.IsAny<decimal>()));
        }

        [Test]
        public void MathControllerTest_Add_ValidModel_ReturnsExpectedResults()
        {
            var model = new MathOperationModel {First = 4, Second = 6};
            var expected = model.First + model.Second;

            MockMathService.Setup(m => m.Add(model.First, model.Second)).Returns(expected);

            var result = ItemUnderTest.PostAdd(model) as OkNegotiatedContentResult<ResultModel>;
            Assert.That(result, Is.Not.Null);

            Assert.That(result.Content.Result, Is.EqualTo(expected));
        }

        [Test]
        public void MathControllerTest_Constructor_NotNull()
        {
            Assert.That(ItemUnderTest, Is.Not.Null);
        }
    }
}