using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CoffeeShop.WebUI.Controllers
{
    public class VisualizationsController : Controller
    {
        // GET: Visualizations
        public ActionResult ShowCoffeeType(string coffeetype)
        {
            var cf = coffeetype.ToLower();
            return PartialView("ShowCoffeeType", cf);
        }

        public ActionResult ShowCoffeeSize(string coffeesize, string coffeetype)
        {
            var zt = coffeesize.ToLower();
            var cf = coffeetype.ToLower();
            string[] param = { zt, cf };
            return PartialView("ShowCoffeeSize", param);
        }

        public ActionResult ShowCondiment(string condiment)
        {
            var con = condiment.ToLower();
            return PartialView("ShowCondiment", con);
        }

    }
}