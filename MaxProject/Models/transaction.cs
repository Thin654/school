using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class transaction
    {
        public int transactionid { get; set; }
        public int customerid { get; set; }
        public int credit { get; set; }
        public int identification { get; set; }
        public DateTime date { get; set; }
        public int amount{ get; set; }
        public int bankid { get; set; }
        public transaction() { }
        public transaction(int transactionid, int customerid, int credit, int identification, DateTime datetime, int amount, int bankid)
        {
            this.transactionid = transactionid;
            this.customerid = customerid;
            this.credit = credit;
            this.identification = identification;
            this.date = datetime;
            this.amount = amount;
            this.bankid = bankid;
        }
    }
}
