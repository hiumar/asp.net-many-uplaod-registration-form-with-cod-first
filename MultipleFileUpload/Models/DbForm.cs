using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MultipleFileUpload.Models
{
    public class DbForm : DbContext
    {
        public DbForm()
            : base("name=jardon")
        {
        }
        public DbSet<VisaApplication> VisaApplications { get; set; }
        public DbSet<Mfiles> Mfiles { get; set; }
    }
}