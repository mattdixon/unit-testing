using System.Web.Http.Results;
using FrontRangeSystems.UnitTesting.Services.Contracts;
using FrontRangeSystems.UnitTesting.TestingFramework;
using FrontRangeSystems.UnitTesting.WebClient.Controllers.WebApi;
using FrontRangeSystems.UnitTesting.WebClient.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace FrontRangeSystems.UnitTesting.WebClient.MsTests.Controllers.WebApi
{
    [TestClass]
    public class MathControllerTest : MsTestBase<MathController>
    {
        private Mock<IMathService> MockMathService { get; set; }

        protected override void TestInitializeInternal()
        {
            MockMathService = new Mock<IMathService>();

            ItemUnderTest = new MathController(MockMathService.Object);
        }

        [TestMethod]
        public void MathControllerTest_Constructor_NotNull()
        {
            Assert.IsNotNull(ItemUnderTest);
        }

        [TestMethod]
        public void MathControllerTest_Add_ValidModel_CallsAddInMathService()
        {
            ItemUnderTest.PostAdd(new MathOperationModel {First = Random.NextDecimal(), Second = Random.NextDecimal()});
            MockMathService.Verify(m => m.Add(It.IsAny<decimal>(), It.IsAny<decimal>()));
        }

        [TestMethod]
        public void MathControllerTest_Add_ValidModel_ReturnsExpectedResults()
        {
            var model = new MathOperationModel {First = 4, Second = 6};
            var expected = model.First + model.Second;

            MockMathService.Setup(m => m.Add(model.First, model.Second)).Returns(expected);

            var result = ItemUnderTest.PostAdd(model) as OkNegotiatedContentResult<ResultModel>;
            Assert.IsNotNull(result);

            Assert.AreEqual(expected, result.Content.Result);
        }
    }
}