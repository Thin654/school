using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
namespace DBlibrary
{
    public abstract class DB
    {
        private const string connSTR = @"server=localhost;    
                                    user id=root;
                                    password=josh17rog;
                                    persistsecurityinfo=True;
                                    database=projectmax"; //database connection
        protected MySqlConnection conn;  //מחלקה אחראית על החיבור
        protected MySqlCommand cmd;         //כל מה שאחראי על פקודת SQL
        protected MySqlDataReader reader;  //מחזירים בשביל לקרוא את התשובה בדאטא

        protected DB()
        {
            conn = new MySqlConnection(connSTR);
            cmd = new MySqlCommand();
            cmd.Connection = conn;
        }
    }

}