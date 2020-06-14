using FrameworkTricks.Application.Models;
using FrameworkTricks.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Results;
using System.Web.Mvc;

namespace FrameworkTricks.Web.Controllers
{
    public class RestaurantsController : Controller
    {
        private readonly IRestaurantData db;

        public RestaurantsController(IRestaurantData data)
        {
            this.db = data;
        }

        public ActionResult Index()
        {
            var model = db.GetAll();
            return View(model);
        }

        // TODO: Implement an error page here for when model is null
        public ActionResult Details(int id)
        {
            var model = db.GetBy(id);
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Restaurant restaurant)
        {
            db.Add(restaurant);
            return View();
        }
    }
}