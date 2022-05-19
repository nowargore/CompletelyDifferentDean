using CompletelyDifferentDean.Model.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace CompletelyDifferentDean.Model
{
    public class CurriculumDisciplineSemester
    {
        public int ID { get; set; }

        public CurriculumDiscipline CurriculumDiscipline { get; set; }

        public int SemesterNumber { get; set; }
        public virtual List<ControlTest> ControlTests { get; set; }

        public int SemesterYear { get; set; }
        public SeasonOfSemester Season { get; set; }

        public Department Department { get; set; }
        public virtual List<Lecturer> Lecturers { get; set; }

        public int LectureHours { get; set; }
        public int LaboratoryHours { get; set; }
        public int SelfStudyHours { get; set; }
    }
}
