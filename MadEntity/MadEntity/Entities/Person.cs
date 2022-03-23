using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MadEntity.Entities
{
    internal class Person
    {
        [Key]
        public int Id2 { get; set; }
        public string? Name { get; set; }
        [Column("LastName")]
        public string? Surname { get; set; }
        [NotMapped]
        public int Age { get; set; }
    }
}
