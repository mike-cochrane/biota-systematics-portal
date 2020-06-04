using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Systematics.Portal.Web.Model {
    public class DataRight {
        public string Role { get; set; }
        public string Collection { get; set; }
        public Guid CollectionId { get; set; }
        public int SecurityLevel { get; set; }

        public DataRight() {
            Role = string.Empty;
            Collection = string.Empty;
            CollectionId = Guid.Empty;
            SecurityLevel = int.MaxValue;
        }
    }
}
