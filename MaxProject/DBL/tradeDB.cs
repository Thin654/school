using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;


namespace DBL
{
    public class tradeDB : BaseDB<trade>
    {
        protected override string GetTableName()
        {
            return "trade";
        }
        protected override trade CreateModel(object[] row)
        {
            trade c = new trade();
            c.idtrade = int.Parse(row[0].ToString());
            c.customerid = int.Parse(row[1].ToString());
            c.coinid = int.Parse(row[2].ToString());
            c.transactionid = int.Parse(row[3].ToString());
            c.rate = int.Parse(row[4].ToString());
            c.date = DateTime.Parse(row[5].ToString());
            c.sl = Convert.ToBoolean(row[6]);
            c.amount = int.Parse(row[7].ToString());
            return c;
        }
        protected override async Task<trade> CreateModelAsync(object[] row)
        {
            trade c = new trade();
            c.idtrade = int.Parse(row[0].ToString());
            c.customerid = int.Parse(row[1].ToString());
            c.coinid = int.Parse(row[2].ToString());
            c.transactionid = int.Parse(row[3].ToString());
            c.rate = int.Parse(row[4].ToString());
            c.date = DateTime.Parse(row[5].ToString());
            c.sl = Convert.ToBoolean(row[6]);
            c.amount = int.Parse(row[7].ToString());
            return c;
        }
        protected override List<trade> CreateListModel(List<object[]> rows)
        {
            List<trade> custList = new List<trade>();
            foreach (object[] item in rows)
            {
                trade c;
                c = CreateModel(item);
                custList.Add(c);
            }
            return custList;
        }
        protected override async Task<List<trade>> CreateListModelAsync(List<object[]> rows)
        {
            List<trade> custList = new List<trade>();
            foreach (object[] item in rows)
            {
                trade c = new trade();
                c = (trade)CreateModel(item);
                custList.Add(c);
            }
            return custList;
        }
        protected override async Task<trade> GetRowByPKAsync(object pk)
        {
            string sql = @"SELECT trade.* FROM trade WHERE (idtrade = @id)";
            AddParameterToCommand("@id", int.Parse(pk.ToString()));
            List<trade> list = (List<trade>)await SelectAllAsync(sql);
            if (list.Count == 1)
                return list[0];
            else
                return null;
        }
        //protected override trade GetRowByPK(object pk)
        //{
        //    string sql = @"SELECT trade.* FROM trade WHERE (idtrade = @id)";
        //    AddParameterToCommand("@id", int.Parse(pk.ToString()));
        //    List<trade> list = (List<trade>)SelectAll(sql);
        //    if (list.Count == 1)
        //        return list[0];
        //    else
        //        return null;
        //}
        public async Task<List<trade>> GetAllAsync()
        {
            return ((List<trade>)await SelectAllAsync());
        }
        public async Task<trade> SelectByPkAsync(int id)
        {
            string sql = @"SELECT trade.* FROM trade WHERE (idtrade = @id)";
            AddParameterToCommand("@id", id);
            List<trade> list = (List<trade>)await SelectAllAsync(sql);
            if (list.Count == 1)
                return list[0];
            else
                return null;
        }
        public async Task<trade> InsertGetObjAsync(trade t)
        {
            Dictionary<string, object> fillValues = new Dictionary<string, object>()
            {
                { "customerid", t.customerid.ToString() },
                { "coinid", t.coinid.ToString() },
                { "transactionid", t.transactionid.ToString() },
                {"rate", t.rate.ToString() },
                {"date", t.date.ToString("yyyy-MM-dd HH:mm:ss.fff") },
                {"sl", Convert.ToInt32(t.sl).ToString() },
                {"amount", t.amount.ToString() }
            };
            return (trade)await base.InsertGetObjAsync(fillValues);
        }
    }
}
