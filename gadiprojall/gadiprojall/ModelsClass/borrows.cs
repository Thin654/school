using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsClass
{
    public class borrows
    {
        public borrows(string idstudents, int idbook)
        {
            this.idstudents = idstudents;
            this.idbook = idbook;
        }
        public borrows() { }
        public string idstudents { get; set; }
        public int idbook { get; set; }
    }
}
