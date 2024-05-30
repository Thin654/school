using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class customer
    {
        public int id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public bool admin { get; set; }
        public customer() { }
        public customer(int id, string name, string email, string password, bool admin)
        {
            this.id = id;
            this.name = name;
            this.email = email;
            this.password = password;
            this.admin = admin;
        }
        public customer(string name, string email, string password, bool admin)
        {
            this.name = name;
            this.email = email;
            this.password = password;
            this.id = 0;
            this.admin = admin;
        }
    }
}
