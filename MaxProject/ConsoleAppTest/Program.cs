using System.ComponentModel.DataAnnotations;
using Models;
using DBL;

namespace ConsoleAppTest
{
    internal class Program
    {
        public static async Task Main(string[] args)
        {

            string email = "john.doe@example.com";
            string name = "John Do";
            string password = "newpassword";
            customer c = new customer(1, name, email,password);
            customerDB cb = new customerDB();
            //int u = await cb.UpdateAsync(c);
            //await cb.DeleteAsync(c);
            await cb.InsertGetObjAsync(c);
        }
    }
    
}
