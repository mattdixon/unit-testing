using System.Web.Http;
using FrontRangeSystems.UnitTesting.WebClient.Models;

namespace FrontRangeSystems.UnitTesting.WebClient.Controllers.WebApi
{
    public abstract class ApiControllerBase : ApiController
    {
        public IHttpActionResult WrapResult(decimal result)
        {
            return Ok(new ResultModel {Result = result});
        }
    }
}