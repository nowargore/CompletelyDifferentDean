using System;
using System.Collections.Generic;
using System.Text;

namespace CompletelyDifferentDean.Model
{
    public class Faculty
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public virtual List<Department> Departments { get; set; }
        public Lecturer Dean { get; set; }
    }
}
