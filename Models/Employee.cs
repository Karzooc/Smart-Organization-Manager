using System;
using System.Collections.Generic;
using System.Text;

namespace ORG.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Salary { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }

}

