using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Systematics.Portal.Web.Model
{
    public class DownloadPurpose
    {
        public int DownloadPurposeId { get; set; }
        public string Purpose { get; set; }
        public int DisplayOrder { get; set; }

        public DownloadPurpose()
        {
            DownloadPurposeId = -1;
            Purpose = string.Empty;
            DisplayOrder = int.MaxValue;
        }
    }
}
