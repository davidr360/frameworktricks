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

        public ActionResult Details(int id)
        {
            var model = db.GetBy(id);

            if (model is null)
                return HttpNotFound();

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
            if (ModelState.IsValid)
            {
                db.Add(restaurant);
                return RedirectToAction(nameof(Details), new { restaurant.Id });
            }                
                
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var model = db.GetBy(id);

            if (model is null)
                return HttpNotFound();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Restaurant restaurant)
        {
            // TODO: Create a filter to remove the need for the repeated ModelState.IsValid block

            if (ModelState.IsValid)
            {
                db.Update(restaurant);
                return RedirectToAction(nameof(Details), new { restaurant.Id });
            }

            return View(restaurant);
        }
    }
}