//--------------------------------------------------------------------------
// <copyright file="PrizeMoneyCalculationController.cs" company="Front Range Systems, LLC">
//     Copyright (c) 2017 Front Range Systems, LLC. All rights reserved.
//     You are free to use this source code as you wish. Front Range Systems, LLC is not
//     responsible for any bugs, errors, or resulting damage from problems
//     with this source code. We are, after all, human. This code is meant
//     to be used as a learning tool. 
// </copyright>
// <author>Matt Dixon</author>
//--------------------------------------------------------------------------

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