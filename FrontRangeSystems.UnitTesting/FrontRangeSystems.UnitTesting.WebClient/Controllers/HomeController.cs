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