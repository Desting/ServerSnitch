using DataExtractor.Model;
using DataExtractor.Model.IIS;
using ServerModel.Model;
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
        public DbSet<ServerModel.Owner> Owners { get; set; }
        public DbSet<ServerModel.Tag> Tags { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MasterEntity>()
                .HasOptional<IISStringContainer>(s => s.iis);

            modelBuilder.Entity<MasterEntity>()
                .HasKey(m => m.Id);

            modelBuilder.Entity<Website>()
                .HasKey(m => m.siteName);

            modelBuilder.Entity<IISStringContainer>()
                .HasMany(i => i.websites)
                .WithRequired();

            //modelBuilder.Entity<Dependency>()
            //    .HasRequired(m => m.application)
            //    .WithMany(m => m.dependencies)
            //    .HasForeignKey(m => new {m.masterId, m.applicationId});

            base.OnModelCreating(modelBuilder);
        }
    }
}