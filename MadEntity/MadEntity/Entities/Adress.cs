using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MadEntity.Entities
{
    internal class Adress
    {
        public int Id { get; set; }

        public string Street { get; set; }

        public int PersonId { get; set; }

        public Person? Person { get; set; } // optional
    }
}
