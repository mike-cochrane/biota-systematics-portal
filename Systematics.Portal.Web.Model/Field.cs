using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Systematics.Portal.Web.Model {
    public class Field {
        public int FieldId { get; set; }
        public string LoweredFieldName { get; set; }
        public string SolrFieldName { get; set; }
    }
}
