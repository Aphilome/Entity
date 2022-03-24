using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MadEntity.Entities
{
    internal class Department
    {
        public int DepartmentId { get; set; }

        public string Name { get; set; }

        public ICollection<Person>? Persons { get; set; } //optional

    }
}
