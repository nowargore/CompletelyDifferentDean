using System;
using System.Collections.Generic;
using System.Text;

namespace CompletelyDifferentDean.Model
{
    public class Department
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public virtual List<Lecturer> Lecturers { get; set; }
        public Lecturer Head { get; set; }
    }
}
