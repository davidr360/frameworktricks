using FrameworkTricks.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FrameworkTricks.Web.Controllers
{
    public class RestaurantsController : Controller
    {
        private readonly IRestaurantData data;

        public RestaurantsController(IRestaurantData data)
        {
            this.data = data;
        }

        public ActionResult Index()
        {
            var model = data.GetAll();
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var model = data.GetBy(id);
            return View(model);
        }
    }
}