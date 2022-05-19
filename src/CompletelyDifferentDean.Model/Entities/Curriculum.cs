using System;
using System.Collections.Generic;
using System.Text;

namespace CompletelyDifferentDean.Model
{
    public class Curriculum
    {
        public int ID { get; set; }

        public string SpecialtyName { get; set; }
        public int YearOfRevision { get; set; }

        public virtual List<CurriculumDiscipline> Disciplines { get; set; }
    }
}
