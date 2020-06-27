using FrameworkTricks.Web.ActionFilters;
using System.Web.Mvc;

namespace FrameworkTricks.Web.Controllers
{
    public class ActionFilterController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}