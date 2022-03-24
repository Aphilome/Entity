using MadEntity.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MadEntity
{
    internal class Context : DbContext
    {
        public Context()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(@"host=localhost;port=5432;database=mad-entity-db;username=postgres;password=admin");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Person>().Property(p => p.Name).IsRequired();


            modelBuilder.Entity<Person>()
                .HasOne<Department>(d => d.Department)
                .WithMany(p => p.Persons)
                .HasForeignKey(p => p.CurrentDepartmentId);
        }

        public DbSet<Person> Persons {get;  set; }
        public DbSet<Department> Departments { get;  set; }

        public DbSet<Adress> Adresses { get; set; }

    }   
}
