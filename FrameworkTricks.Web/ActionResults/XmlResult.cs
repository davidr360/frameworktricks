using System.Web.Mvc;
using System.Xml.Serialization;

namespace FrameworkTricks.Web.ActionResults
{
    // HACK: Custom Action Result which inherits from the ActionResult base class

    public class XmlResult : ActionResult
    {
        private readonly object data;

        public XmlResult(object data)
        {
            this.data = data;
        }

        public override void ExecuteResult(ControllerContext context)
        {
            var response = context.HttpContext.Response;
            response.ContentType = "text/xml";

            var serialiser = new XmlSerializer(data.GetType());
            serialiser.Serialize(response.Output, data);
        }
    }
}