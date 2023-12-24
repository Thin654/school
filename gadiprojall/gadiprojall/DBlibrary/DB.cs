using MySql.Data.MySqlClient;
namespace DBlibrary
{
    public abstract class DB
    {
        private const string connSTR = @"server=localhost;
                                    user id=root;
                                    password=josh17rog;
                                    persistsecurityinfo=True;
                                    database=library";
        protected static MySqlConnection conn;
        protected MySqlCommand cmd;
        
        protected DB()
        {
            conn = new MySqlConnection(connSTR);
            cmd = new MySqlCommand();
            cmd.Connection = conn;
        }
    }

}