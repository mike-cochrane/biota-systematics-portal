using Systematics.Portal.Web.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Systematics.Portal.Web.Data.Interfaces {
    public interface ISpecimensRepository {
        DisplaySpecimen Get(string accessionNumber, int securityLevel);
        string GetSpecimenCollection(string accessionNumber);
        string GetAccessionNumber(Guid specimenId);
    }
}
