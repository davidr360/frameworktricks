using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FrameworkTricks.Web.Controllers
{
    public class RestaurantsController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}