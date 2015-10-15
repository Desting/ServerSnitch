using DataExtractor.Model;
using DataExtractor.Model.IIS;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Atea.Dbs.ServerMonitor.DataAccess
{
    public class ServerDb : DbContext
    {
        public ServerDb() : base ("ServerDb")
        {

        }

        public DbSet<MasterEntity> Servers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MasterEntity>()
                .HasOptional<IISStringContainer>(s => s.iis);
 
            base.OnModelCreating(modelBuilder);
        }
    }
}