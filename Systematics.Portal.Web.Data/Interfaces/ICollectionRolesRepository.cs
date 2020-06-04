using Systematics.Portal.Web.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Systematics.Portal.Web.Data.Interfaces {
    public interface ICollectionRolesRepository {
        List<CollectionRole> GetByCollection(Guid collectionId);
        List<CollectionRole> GetByCollectionAcronym(string acronym);
    }
}
