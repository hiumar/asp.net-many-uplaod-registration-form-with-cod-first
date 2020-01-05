using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MultipleFileUpload.Models
{
    public class Mfiles
    {
        public Guid Id { get; set; }
        public string FileName { get; set; }
        public string Extension { get; set; }
        public int SupportId { get; set; }
        public virtual VisaApplication Support { get; set; }

    }
}