using CompletelyDifferentDean.Model.Enums;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace CompletelyDifferentDean.Model
{
    public class Student
    {
        public int ID { get; set; }

        public string Surname { get; set; }
        public string Name { get; set; }
        public string PatronymicName { get; set; }

        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }

        public DateTime DateOfEntrance { get; set; }
        public StudyGroup Group { get; set; }

        public string Nationality { get; set; }
        public FormOfLearning FormOfLearning { get; set; }
        public TypeOfTuitionFee TypeOfTuitionFee { get; set; }
        public SocialBenefit SocialBenefit { get; set; }

        public virtual List<ControlTestResult> PerformanceResults { get; set; }
        public string TopicOfThesis { get; set; }
    }
}
