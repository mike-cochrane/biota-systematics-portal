using System.Collections.Generic;
using System.Xml.Linq;

namespace SystematicsPortal.Web.Models
{
    public class Field
    {
        public string Label { get; set; }

        public string ViewComponent { get; set; }

        public FieldData FieldData { get; set; }

        public List<Field> Fields { get; set; }

        public Field()
        {
            Fields = new List<Field>();
        }
    }

    public class FieldData
    {
        public XElement Data { get; set; }

        public Dictionary<string, string> DataLabels { get; set; }

        public FieldData()
        {
            DataLabels = new Dictionary<string, string>();
        }
    }
}
