using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Systematics.Portal.Web.Model {
    public class CollectionRole {
        public int CollectionRoleId { get; set; }
        public Guid CollectionId { get; set; }
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public int ContactId { get; set; }
        public string ContactName { get; set; }
        public string ContactEmail { get; set; }

        public CollectionRole() {
            CollectionRoleId = -1;
            CollectionId = Guid.Empty;
            RoleId = -1;
            RoleName = string.Empty;
            ContactId = -1;
            ContactName = string.Empty;
            ContactEmail = string.Empty;
        }
    }
}
