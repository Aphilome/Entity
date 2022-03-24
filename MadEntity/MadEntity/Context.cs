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
            //Database.EnsureDeleted();
            //Database.EnsureCreated();
            Database.Migrate();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(@"host=localhost;port=5432;database=mad-entity-db;username=postgres;password=admin")
                //.LogTo(Console.WriteLine)
                ;
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>()
                .HasOne(p => p.Address)
                .WithOne(a => a.Person)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Person>()
                .HasOne(p => p.Department)
                .WithMany(d => d.Persons);

            modelBuilder.Entity<Person>()
                .HasMany(p => p.Hobbies)
                .WithMany(d => d.Persons)
                .UsingEntity(j => j.ToTable("PersonHobbies"));

        }

        public DbSet<Person> Persons {get;  set; }

        public DbSet<Department> Departments { get;  set; }

        public DbSet<Address> Addresses { get; set; }

        public DbSet<Hobby> Hobbies { get; set; }

    }   
}
