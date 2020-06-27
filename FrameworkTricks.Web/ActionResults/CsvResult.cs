using System.Collections;
using System.IO;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace FrameworkTricks.Web.ActionResults
{
    public class CsvResult : FileResult
    {
        private readonly IEnumerable data;

        public CsvResult(IEnumerable data, string fileDownloadName) : base("text/csv")
        {
            this.data = data;
            FileDownloadName = fileDownloadName;
        }

        protected override void WriteFile(HttpResponseBase response)
        {
            var builder = new StringBuilder();
            var writer = new StringWriter(builder);

            foreach (var item in data)
            {
                var properties = item.GetType().GetProperties();

                foreach (var property in properties)
                {
                    writer.Write(GetValue(item, property.Name));
                    writer.Write(",");
                }

                writer.WriteLine();
            }

            response.Write(builder);
        }

        private string GetValue(dynamic item, string propertyName)
        {
            return item.GetType().GetProperty(propertyName).GetValue(item, null).ToString() ?? "";
        }
    }
}