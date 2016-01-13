using DataExtractor.Model;
using DataExtractor.Model.IIS;
using ServerModel;
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
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Tag> Tags { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // You use the modelBuilder to map relations between objects in the DB
            modelBuilder.Entity<MasterEntity>()
                .HasOptional<IISStringContainer>(s => s.iis);

            modelBuilder.Entity<MasterEntity>()
                .HasKey(m => m.Id);

            modelBuilder.Entity<Website>()
                .HasKey(m => m.siteName);

            modelBuilder.Entity<IISStringContainer>()
                .HasMany(i => i.websites)
                .WithRequired()
                .WillCascadeOnDelete(true);



            modelBuilder.Entity<Tag>()
                .HasKey(m => m.title)
                .HasOptional(t => t.servers)
                .WithMany();

            modelBuilder.Entity<Owner>()
                .HasKey(m => m.Id)
                .HasOptional(t => t.servers)
                .WithMany();


            base.OnModelCreating(modelBuilder);
        }
    }
}