using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Systematics.Portal.Web.Model.Helpers {
    [Serializable]
    public class CISWebException: Exception {
        public CISWebException(string message) : base(message) { }

        protected CISWebException(SerializationInfo info, StreamingContext ctxt) : base(info, ctxt) { }
    }
}
