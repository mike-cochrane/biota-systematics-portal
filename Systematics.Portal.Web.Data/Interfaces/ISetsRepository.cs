using Systematics.Portal.Web.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Systematics.Portal.Web.Data.Interfaces {
    public interface ISetsRepository {
        Set Get(int setId, Guid ownerId);
        List<Set> GetAll(Guid ownerId);
        void Add(Set set);
        void Update(int setId, Guid ownerId, string displayName, string description);
        void Delete(int setId, Guid ownerId);

        void AddSpecimen(int setId, Guid specimenId, Guid ownerId);
        void AddSpecimens(int setId, List<string> specimenIds, Guid ownerId);
        void RemoveSpecimen(int setId, Guid specimenId, Guid ownerId);
    }
}
