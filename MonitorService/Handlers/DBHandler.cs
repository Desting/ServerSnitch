using DataExtractor.Model;
using DataExtractor.Model.IIS;
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

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MasterEntity>()
                .HasOptional<IISStringContainer>(s => s.iis);
                //.WithRequired(s => s.master);

            base.OnModelCreating(modelBuilder);
        }
    }
}