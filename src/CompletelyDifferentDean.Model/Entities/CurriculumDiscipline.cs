using System;
using System.Collections.Generic;
using System.Text;

namespace CompletelyDifferentDean.Model
{
    public class CurriculumDiscipline
    {
        public int ID { get; set; }

        public Discipline Discipline { get; set; }

        public virtual List<CurriculumDisciplineSemester> Semesters { get; set; }
    }
}
