using SystematicsPortal.Web.Models;
using System;
using System.Collections.Generic;

namespace SystematicsPortal.Web.ViewModels.Documents
{
    public class DetailsViewModel
    {
        public List<Field> Fields { get; set; }

        public DetailsViewModel()
        {
            Fields = new List<Field>();
        }
    }
}
