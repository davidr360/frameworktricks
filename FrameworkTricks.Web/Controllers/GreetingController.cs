using FrameworkTricks.Web.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FrameworkTricks.Web.Controllers
{
    public class GreetingController : Controller
    {
        public ActionResult Index()
        {
            var model = new GreetingViewModel { Message = ConfigurationManager.AppSettings["message"] };
            return View(model);
        }
    }
}