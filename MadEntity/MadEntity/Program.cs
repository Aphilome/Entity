using MadEntity.Entities;
using Microsoft.EntityFrameworkCore;

namespace MadEntity
{
    class Program
    {
        static void SeedData()
        {
            using (var context = new Context())
            {
                //context.Database.EnsureDeleted();
                // context.Database.EnsureCreated();

                var dep1 = new Department()
                {
                    Name = "Dep1"
                };

                var dep2 = new Department()
                {
                    Name = "Dep2"
                };

                var hobby1 = new Hobby()
                {
                    Name = "Cars"
                };

                var hobby2 = new Hobby()
                {
                    Name = "Programming"
                };

                var hobby3 = new Hobby()
                {
                    Name = "Singing"
                };

                var hobby4 = new Hobby()
                {
                    Name = "Swimming"
                };

                var address1 = new Address()
                {
                    Street = "M prospect"
                };

                var address2 = new Address()
                {
                    Street = "N prospect"
                };

                var address3 = new Address()
                {
                    Street = "O prospect"
                };

                var person1 = new Person()
                {
                    Name = "Aura",
                    Surname = "Philomena",
                    Department = dep1,

                    Hobbies = new List<Hobby>() { hobby1, hobby2 },
                    Address = address1
                };

                var person2 = new Person()
                {
                    Name = "Tion",
                    Surname = "Birdperson",
                    Department = dep1,
                    Hobbies = new List<Hobby>() { hobby3, hobby4 },
                    Address = address2
                };

                var person3 = new Person()
                {
                    Name = "Aura2",
                    Surname = "Philomena2",
                    Department = dep2,

                    Hobbies = new List<Hobby>() { hobby1 },
                    Address = address3
                };

                context.Persons.Add(person1);
                context.Persons.Add(person2);
                context.Persons.Add(person3);
                context.SaveChanges();
            }
        }

        static void Main(string[] args)
        {
            //SeedData();
            //return ;
            
            using (var context = new Context())
            {
                var persons = context.Persons
                    .Include(p => p.Address)
                    .Include(p => p.Hobbies)
                    .Include(p => p.Department);

                //var person = context.Persons.Where(p => p.Name.Contains("Tion")).FirstOrDefault();
                //if (person != null)
                //{
                //    context.Persons.Remove(person);
                //}
                //context.SaveChanges();
            }

            using (var context = new Context())
            {
                var persons = context.Persons
                    .Join(context.Departments,
                    p => p.Department.Id,
                    d => d.Id,
                    (person, department) =>
                    new {
                        PersonId= person.Id,
                        Department = department.Name
                    });
                foreach (var person in persons)
                {
                    Console.WriteLine(person.PersonId);
                    Console.WriteLine(person.Department);
                }
            }
            
            using (var context = new Context())
            {
                var persons = from p in context.Persons
                              join d in context.Departments
                              on p.Department.Id equals d.Id
                              where d.Name.Contains("1")
                              select new
                              {
                                  PersonId = p.Id,
                                  DepName = d.Name,
                                  PersonName = $"{p.Name} {p.Surname}"
                              };

                foreach (var person in persons)
                {
                    Console.WriteLine(person.PersonId);
                    Console.WriteLine(person.DepName);
                    Console.WriteLine(person.PersonName);
                }
                Console.WriteLine("-------------------------------");

            }
        }
    }
}



