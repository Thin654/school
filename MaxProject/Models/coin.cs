using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class coin
    {
        public int coincode { get; set; }
        public string symbol { get; set; }
        public string namecoin { get; set; }
        public byte[] icon { get; set; }
        public int rate { get; set; }
        public coin() { }
        public coin(int coincode, string symbol, string namecoin, byte[] icon, int rate)
        {
            this.coincode = coincode;
            this.symbol = symbol;
            this.namecoin = namecoin;
            this.icon = icon;
            this.rate = rate;
        }
    }
}
