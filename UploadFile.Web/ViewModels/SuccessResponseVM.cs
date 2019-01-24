using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UploadFile.Web.ViewModels
{
    public class SuccessResponseVM
    {
        public long? Size { get; set; }
        public string InitialName { get; set; }
        public string LocalFileName { get; set; }
        public string CustomFileName { get; set; }
    }
}