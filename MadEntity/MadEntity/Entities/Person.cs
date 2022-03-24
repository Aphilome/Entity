﻿using System;
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
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Surname { get; set; }

        public int? Age { get; set; }

        public ICollection<Department> Departments { get; set; }

        public Department? Department { get; set; }

        public int? CurrentDepartmentId { get; set; }

        public Adress? Adress { get; set; }

    }
}
