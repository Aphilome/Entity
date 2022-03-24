﻿using MadEntity.Entities;
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
            modelBuilder.Entity<Person>()
                .HasOne(p => p.Adress)
                .WithOne(a => a.Person)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Person>()
                .HasMany(p => p.Departments)
                .WithMany(d => d.Persons)
                .UsingEntity(j => j.ToTable("PersonToDepartment"));

        }

        public DbSet<Person> Persons {get;  set; }
        public DbSet<Department> Departments { get;  set; }

        public DbSet<Adress> Adresses { get; set; }

    }   
}
