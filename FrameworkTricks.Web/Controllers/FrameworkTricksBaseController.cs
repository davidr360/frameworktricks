using System.Web.Mvc;

namespace FrameworkTricks.Web.Controllers
{
    // HACK: Add a Base Controller class to give your controller classes additional functionality
    public abstract class FrameworkTricksBaseController : Controller
    {
        public void AddAlertMessage(string message)
        {
            TempData["Message"] = message;
        }
    }
}