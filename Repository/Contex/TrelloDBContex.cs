using Repository.Migrations;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task = Repository.Models.Task;

namespace Repository.Contex
{
    public class TrelloDBContex : DbContext
    {
        public TrelloDBContex() : base("name=TrelloDbConnectionString")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<TrelloDBContex, Configuration>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasMany(x => x.Items).WithOptional().WillCascadeOnDelete();
            modelBuilder.Entity<Item>().HasMany(x => x.Tasks).WithOptional().WillCascadeOnDelete();

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Task> Tasks { get; set; }
    }
}

