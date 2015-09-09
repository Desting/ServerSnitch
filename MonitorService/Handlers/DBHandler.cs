using DataExtractor.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MonitorService.Handlers
{
    public class DBHandler : DbContext
    {
        public DbSet<MasterEntity> Servers { get; set; }

    }
}