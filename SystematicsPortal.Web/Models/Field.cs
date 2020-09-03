using Microsoft.AspNetCore.Html;
using System.Xml.Linq;

namespace SystematicsPortal.Web.Models
{
    public class Field
    {
        public string Label { get; set; }

        public string ViewComponent { get; set; }

        public XElement Data { get; set; }
    }
}
