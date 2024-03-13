using System.ComponentModel.DataAnnotations;
using Models;
using DBL;
using System.Text.RegularExpressions;
using System;

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
            //coinDB cd = new coinDB();
            //string sql = "SELECT * FROM projectmax.coin;";
            //List<coin> l = (List<coin>)await cd.SelectAllAsync(sql);
            //foreach(coin coin in l)
            //{
            //    Console.WriteLine(coin.coincode);
            //}
            //coinDB cdb = new coinDB();
            //coin c = (coin)await cdb.SelectByPkAsync(1);
            //await Console.Out.WriteLineAsync(c.namecoin);


            //static async Task<double> ExtractNumberAsync(string input)
            //{
            //    string pattern = @"\d+(\.\d+)?";
            //    Match match = await Task.Run(() => Regex.Match(input, pattern));

            //    if (match.Success)
            //    {
            //        string numberString = match.Value;
            //        return double.Parse(numberString);
            //    }
            //    else
            //    {
            //        throw new Exception("No number found in the input string.");
            //    }
            //}
            //string str = "{\"bitcoin\":{\"usd\":57211.433}}";
            //await Console.Out.WriteLineAsync(str);
            //double number = await ExtractNumberAsync(str);
            //await Console.Out.WriteLineAsync(number.ToString());
            //string u = "bitcoin";
            //string uri = $"https://api.coingecko.com/api/v3/simple/price?ids=" + u + "&vs_currencies=usd";
            //await Console.Out.WriteLineAsync(uri);

            //transaction t = new transaction();
            //transactionDB td = new transactionDB();
            //t.customerid = 4;
            //t.date = DateTime.Now;
            //await td.InsertGetObjAsync(t);

            await EmailService.SendEmailAsync("maxmaxsht@gmail.com", "reciept", "10000");

        }
    }
    
}
