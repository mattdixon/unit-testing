//--------------------------------------------------------------------------
// <copyright file="HomeController.cs" company="Front Range Systems, LLC">
//     Copyright (c) 2017 Front Range Systems, LLC. All rights reserved.
//     You are free to use this source code as you wish. Front Range Systems, LLC is not
//     responsible for any bugs, errors, or resulting damage from problems
//     with this source code. We are, after all, human. This code is meant
//     to be used as a learning tool. 
// </copyright>
// <author>Matt Dixon</author>
//--------------------------------------------------------------------------

using System.Web.Mvc;
using FrontRangeSystems.UnitTesting.WebClient.Models;

namespace FrontRangeSystems.UnitTesting.WebClient.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        public ActionResult CreateMathModel(decimal first, decimal second)
        {
            var model = new MathOperationModel {First = first, Second = second};

            return View(model);
        }
    }
}