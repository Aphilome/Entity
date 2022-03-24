using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MadEntity.Entities
{
    internal class Hobby
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<Person> Persons { get; set; }
    }
}
