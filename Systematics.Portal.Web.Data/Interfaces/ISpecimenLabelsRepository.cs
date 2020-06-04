﻿using Systematics.Portal.Web.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Systematics.Portal.Web.Data.Interfaces {
    public interface ISpecimenLabelsRepository {
        Dictionary<string, string> Get(string collection);
    }
}
