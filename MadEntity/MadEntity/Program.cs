using MadEntity.Entities;

namespace MadEntity
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new Context())
            {
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
                    Surname = "Birdpirson",
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

                //context.Departments.Add(dep1);
                //context.Departments.Add(dep2);

                context.Persons.Add(person1);
                context.Persons.Add(person2);
                context.Persons.Add(person3);
                context.SaveChanges();
            }
        }
    }
}



