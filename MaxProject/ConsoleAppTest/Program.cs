using System.ComponentModel.DataAnnotations;
using Models;
using DBL;

namespace ConsoleAppTest
{
    public class Program
    {
        public static async Task Main(string[] args)
        {

            //string email = "do@example.com";
            //string name = "John Do";
            //string password = "newpassword";
            //customer c = new customer(2, name, email, password);
            //customerDB cb = new customerDB();
            ////int u = await cb.UpdateAsync(c);
            ////await cb.DeleteAsync(c);
            //await cb.InsertGetObjAsync(c);

            //int customerid = 1;
            //int coidid = 1;
            //int transactionid = 1;
            //int rate = 233;
            //DateTime dateTime = new DateTime(2015, 11, 11);
            //bool sl = false;
            //int amount = 3;
            //trade t = new trade(213, customerid, coidid, transactionid, rate, dateTime, sl, amount);
            //tradeDB td = new tradeDB();
            //await td.InsertGetObjAsync(t);
            coinDB cd = new coinDB();
            string sql = "SELECT* FROM projectmax.coin;";
            List<coin> l = (List<coin>)await cd.SelectAllAsync(sql);
            foreach(coin coin in l)
            {
                Console.WriteLine(coin.coincode);
            }
        }
    }
    
}
