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

            AddData(modelBuilder);
        }

        private void AddData(ModelBuilder modelBuilder)
        {
            var dep1 = new Department
            {
                Id = 1,
                Name = "Dep1"
            };
            var dep2 = new Department
            {
                Id = 2,
                Name = "Dep2"
            };
            modelBuilder.Entity<Department>().HasData(dep1);
            modelBuilder.Entity<Department>().HasData(dep2);

            var hobby1 = new Hobby
            {
                Id = 1,
                Name = "Cars"
            };
            var hobby2 = new Hobby
            {
                Id = 2,
                Name = "Programming"
            };
            var hobby3 = new Hobby
            {
                Id = 3,
                Name = "Singing"
            };
            var hobby4 = new Hobby
            {
                Id = 4,
                Name = "Swimming"
            };
            modelBuilder.Entity<Hobby>().HasData(hobby1);
            modelBuilder.Entity<Hobby>().HasData(hobby2);
            modelBuilder.Entity<Hobby>().HasData(hobby3);
            modelBuilder.Entity<Hobby>().HasData(hobby4);


            var address1 = new Address
            {
                Id = 1,
                Street = "M prospect"
            };
            var address2 = new Address
            {
                Id = 2,
                Street = "N prospect"
            };
            var address3 = new Address
            {
                Id = 3,
                Street = "O prospect"
            };
            modelBuilder.Entity<Address>().HasData(address1);
            modelBuilder.Entity<Address>().HasData(address2);
            modelBuilder.Entity<Address>().HasData(address3);

            //var person1 = new Person
            //{
            //    Id = 1,
            //    Name = "Aura",
            //    Surname = "Philomena",
            //    Department = dep1,
            //    Hobbies = new List<Hobby>() { hobby1, hobby2 },
            //    Address = address1
            //};

            //var person2 = new Person
            //{
            //    Id = 2,
            //    Name = "Tion",
            //    Surname = "Birdperson",
            //    Department = dep1,
            //    Hobbies = new List<Hobby>() { hobby3, hobby4 },
            //    Address = address2
            //};
            //modelBuilder.Entity<Person>().HasData(person1);
            //modelBuilder.Entity<Person>().HasData(person2);
        }

        public DbSet<Person> Persons {get;  set; }

        public DbSet<Department> Departments { get;  set; }

        public DbSet<Address> Addresses { get; set; }

        public DbSet<Hobby> Hobbies { get; set; }

    }   
}
