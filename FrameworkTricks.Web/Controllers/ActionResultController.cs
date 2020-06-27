using System.Collections.Generic;
using System.Web.Mvc;

namespace FrameworkTricks.Web.Controllers
{
    public class ActionResultController : FrameworkTricksBaseController
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Xml()
        {
            var cats = GetCats();
            return XmlResult(cats);
        }

        public ActionResult Csv()
        {
            var cats = GetCats();
            return CsvResult(cats, "FavouriteCats.csv");
        }

        private IEnumerable<Cat> GetCats()
        {
            return new List<Cat>
            {
                new Cat { Id = 1, Name = "Tilly" },
                new Cat { Id = 2, Name = "Rosie" },
                new Cat { Id = 3, Name = "Fido" }
            };
        }
    }

    public class Cat
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}