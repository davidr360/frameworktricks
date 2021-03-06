﻿using FrameworkTricks.Web.ActionResults;
using System.Collections;
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

        public XmlResult XmlResult(object data)
        {
            return new XmlResult(data);
        }

        public CsvResult CsvResult(IEnumerable data, string fileDownloadName)
        {
            return new CsvResult(data, fileDownloadName);
        }
    }
}