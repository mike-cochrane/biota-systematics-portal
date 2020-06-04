using System.Collections.Generic;

namespace Systematics.Portal.Web.Search.Tools.Facet
{
    public class Facet
    {
        public string Name { get; set; }
        public List<KeyValuePair<string, int>> Values { get; set; }

        public Facet()
        {
            Values = new List<KeyValuePair<string, int>>();
        }
    }
}