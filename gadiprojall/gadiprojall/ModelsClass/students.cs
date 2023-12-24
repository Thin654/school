using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsClass
{
    public class students
    {
        public students(string idstudents, string school, int age, string gender)
        {
            this.idstudents = idstudents;
            this.school = school;
            this.age = age;
            this.gender = gender;
        }
        public students() { }
        public string idstudents { get; set; }
        public string school { get; set; }
        public int age { get; set; }
        public string gender { get; set; }
    }
}
