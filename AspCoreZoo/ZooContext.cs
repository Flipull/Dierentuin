using ZooLibrary.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspCoreZoo
{
    public class ZooContext : DbContext
    {
        public ZooContext(DbContextOptions<ZooContext> options) : base(options) { }

        public DbSet<Animal> Animals { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Monkey>();
            modelBuilder.Entity<Lion>();
            modelBuilder.Entity<Elephant>();
            
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}
