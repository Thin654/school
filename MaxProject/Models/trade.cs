using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class trade
    {
        public int idtrade { get; set; }
        public int customerid { get; set; }
        public int coinid { get; set; }
        public int transactionid { get; set; }
        public int rate { get; set; }
        public DateTime date { get; set; }
        public bool sl { get; set; }
        public int amount { get; set; }
        public trade() { }
        public trade(int idtrade, int customerid, int coinid, int transactionid, int rate, DateTime date, bool sl, int amount)
        {
            this.idtrade = idtrade;
            this.customerid = customerid;
            this.coinid = coinid;
            this.transactionid = transactionid;
            this.rate = rate;
            this.date = date;
            this.sl = sl;
            this.amount = amount;
        }
    }
}
