using System;
using System.Collections.Generic;
using System.Text;

namespace StepClass.Models
{
    public class CreateStudentDto
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }

        public string Phone { get; set; }

        public string GroupName { get; set; }
    }
}
