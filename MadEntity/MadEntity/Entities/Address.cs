using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MadEntity.Entities
{
    internal class Address
    {
        [Key]
        //[ForeignKey(nameof(Person))]
        public int? PersonId { get; set; }

        public string? Street { get; set; }

        public Person? Person { get; set; }  // optional
    }
}
