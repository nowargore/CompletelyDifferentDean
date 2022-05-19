using CompletelyDifferentDean.Model.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CompletelyDifferentDean.Model
{
    public class Lecturer
    {
        public int ID { get; set; }

        public string Surname { get; set; }
        public string Name { get; set; }
        public string PatronymicName { get; set; }

        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        [EmailAddress]
        public string EmailAddress { get; set; }

        public Department Department { get; set; }

        public AcademicDegree Degree { get; set; }
        public Rank Rank { get; set; }
        public Position Position { get; set; }
    }
}
