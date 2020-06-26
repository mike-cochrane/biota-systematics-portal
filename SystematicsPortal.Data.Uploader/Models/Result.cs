using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystematicsPortal.Data.Uploader.Models
{
    public class Result
    {
        public string FileName { get; set; }
        public bool UploadResult { get; set; }
        public string Message { get; set; }
    }
}
