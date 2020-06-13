using FrameworkTricks.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FrameworkTricks.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRestaurantData data;

        public HomeController(IRestaurantData data)
        {
            this.data = data;
        }

        public ActionResult Index()
        {
            var model = data.GetAll();
            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}