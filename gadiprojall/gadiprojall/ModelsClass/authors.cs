using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsClass
{
    public class authors
    {

        public string idauthors { get; set; }
        public int age { get; set; }
        public int yearsofwriting { get; set; }
        public int IQ { get; set; }
        public authors() { }
        public authors(string idauthors, int age, int yearsofwriting, int IQ)
        {
            this.idauthors = idauthors;
            this.age = age;
            this.yearsofwriting = yearsofwriting;
            this.IQ = IQ;
        }
    }
}
