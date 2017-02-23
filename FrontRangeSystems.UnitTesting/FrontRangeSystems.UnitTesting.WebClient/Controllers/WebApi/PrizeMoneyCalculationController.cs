using System.Web.Http;
using FrontRangeSystems.UnitTesting.Services.Contracts;
using FrontRangeSystems.UnitTesting.Services.Models;

namespace FrontRangeSystems.UnitTesting.WebClient.Controllers.WebApi
{
    [RoutePrefix("api/prizemoneycalculation")]
    public class PrizeMoneyCalculationController : ApiControllerBase
    {
        public PrizeMoneyCalculationController(IPrizeMoneyCalculationService prizeMoneyCalculationService)
        {
            PrizeMoneyCalculationService = prizeMoneyCalculationService;
        }

        private IPrizeMoneyCalculationService PrizeMoneyCalculationService { get; }

        [Route("purse")]
        public IHttpActionResult PostPurse(PrizeMoneyCalculationModel model)
        {
            return WrapResult(PrizeMoneyCalculationService.CalculatePurse(model));
        }

        [Route("payout")]
        public IHttpActionResult PostPerPersonPayout(PayoutCalculationModel model)
        {
            return WrapResult(PrizeMoneyCalculationService.CalculatePerPersonPayout(model));
        }
    }
}