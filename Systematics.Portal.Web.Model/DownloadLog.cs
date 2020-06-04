using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Systematics.Portal.Web.Model
{
    public class DownloadLog
    {
        public Guid DownloadId { get; set; }
        public Guid UserId { get; set; }
        public string UserOrganisation { get; set; }
        public int DownloadPurposeId { get; set; }
        public string DownloadPurpose { get; set; }
        public string OtherPurposeText { get; set; }
        public DateTime RequestDate { get; set; }
        public int CHRRecordCount { get; set; }
        public int ICMPRecordCount { get; set; }
        public int FLAXRecordCount { get; set; }
        public int NZACRecordCount { get; set; }
        public int PDDRecordCount { get; set; }
        public string RequestedSpecimens { get; set; }
        public string FailedToRetrieveSpecimens { get; set; }
        public bool Success { get; set; }

        public DownloadLog()
        {
            DownloadId = Guid.NewGuid();
            UserId = Guid.Empty;
            UserOrganisation = string.Empty;
            DownloadPurposeId = -1;
            DownloadPurpose = string.Empty;
            OtherPurposeText = string.Empty;
            RequestDate = DateTime.Now;
            CHRRecordCount = 0;
            ICMPRecordCount = 0;
            FLAXRecordCount = 0;
            NZACRecordCount = 0;
            PDDRecordCount = 0;
            RequestedSpecimens = string.Empty;
            FailedToRetrieveSpecimens = string.Empty;
            Success = false;
        }
    }
}
