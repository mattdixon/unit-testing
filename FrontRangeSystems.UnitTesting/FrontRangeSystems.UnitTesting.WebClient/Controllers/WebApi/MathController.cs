using System.Web.Http;
using FrontRangeSystems.UnitTesting.Services.Contracts;
using FrontRangeSystems.UnitTesting.WebClient.Models;

namespace FrontRangeSystems.UnitTesting.WebClient.Controllers.WebApi
{
    [RoutePrefix("api/math")]
    public class MathController : ApiControllerBase
    {
        public MathController(IMathService mathService)
        {
            MathService = mathService;
        }

        private IMathService MathService { get; }

        [Route("add")]
        public IHttpActionResult PostAdd(MathOperationModel model)
        {
            return WrapResult(MathService.Add(model.First, model.Second));
        }

        [Route("subtract")]
        public IHttpActionResult PostSubtract(MathOperationModel model)
        {
            return WrapResult(MathService.Subtract(model.First, model.Second));
        }

        [Route("multiply")]
        public IHttpActionResult PostMultiply(MathOperationModel model)
        {
            return WrapResult(MathService.Multilpy(model.First, model.Second));
        }

        [Route("divide")]
        public IHttpActionResult PostDivide(MathOperationModel model)
        {
            return WrapResult(MathService.Divide(model.First, model.Second));
        }
    }
}