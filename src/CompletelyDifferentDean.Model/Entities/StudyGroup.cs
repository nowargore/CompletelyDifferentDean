using CompletelyDifferentDean.Model.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace CompletelyDifferentDean.Model
{
    public class StudyGroup
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public Qualification Qualification { get; set; }
        public DateTime DateOfGraduation { get; set; }

        public Curriculum Curriculum { get; set; }

        public virtual List<Student> Students { get; set; }
        public Student Chief { get; set; }
        public Lecturer Curator { get; set; }
    }
}
