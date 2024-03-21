using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace DBL
{
    public class transactionDB : BaseDB<transaction>
    {
        protected override string GetTableName()
        {
            return "transaction";
        }
        protected override Models.transaction CreateModel(object[] row)
        {
            transaction c = new transaction();
            c.transactionid = int.Parse(row[0].ToString());
            c.customerid = int.Parse(row[1].ToString());
            c.credit = int.Parse(row[2].ToString());
            c.identification = int.Parse(row[3].ToString());
            c.date = DateTime.Parse(row[4].ToString());
            c.amount = double.Parse(row[5].ToString());
            return c;
        }
        protected override async Task<Models.transaction> CreateModelAsync(object[] row)
        {
            transaction c = new transaction();
            c.transactionid = int.Parse(row[0].ToString());
            c.customerid = int.Parse(row[1].ToString());
            c.credit = int.Parse(row[2].ToString());
            c.identification = int.Parse(row[3].ToString());
            c.date = DateTime.Parse(row[4].ToString());
            c.amount = double.Parse(row[5].ToString());
            return c;
        }
        protected override List<Models.transaction> CreateListModel(List<object[]> rows)
        {
            List<Models.transaction> custList = new List<Models.transaction>();
            foreach (object[] item in rows)
            {
                Models.transaction c;
                c = CreateModel(item);
                custList.Add(c);
            }
            return custList;
        }
        protected override async Task<List<Models.transaction>> CreateListModelAsync(List<object[]> rows)
        {
            List<Models.transaction> custList = new List<Models.transaction>();
            foreach (object[] item in rows)
            {
                Models.transaction c = new Models.transaction();
                c = (Models.transaction)CreateModel(item);
                custList.Add(c);
            }
            return custList;
        }
        protected override async Task<Models.transaction> GetRowByPKAsync(object pk)
        {
            string sql = @"SELECT transaction.* FROM transaction WHERE (transactionid = @id)";
            AddParameterToCommand("@id", int.Parse(pk.ToString()));
            List<Models.transaction> list = (List<Models.transaction>)await SelectAllAsync(sql);
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
        public async Task<List<Models.transaction>> GetAllAsync()
        {
            return ((List<Models.transaction>)await SelectAllAsync());
        }
        public async Task<Models.transaction> SelectByPkAsync(int id)
        {
            string sql = @"SELECT transaction.* FROM transaction WHERE (transactionid = @id)";
            AddParameterToCommand("@id", id);
            List<Models.transaction> list = (List<Models.transaction>)await SelectAllAsync(sql);
            if (list.Count == 1)
                return list[0];
            else
                return null;
        }
        public async Task<List<Models.transaction>> SelectByCustomer(int id)
        {
            string sql = @"SELECT transaction.* FROM transaction WHERE (customerid = @id)";
            AddParameterToCommand("@id", id);
            List<Models.transaction> list = (List<Models.transaction>)await SelectAllAsync(sql);
            return list;
        }
        public async Task<Models.transaction> InsertGetObjAsync(Models.transaction t)
        {
            Dictionary<string, object> fillValues = new Dictionary<string, object>()
            {
                { "customerid", t.customerid.ToString() },
                { "credit", t.credit.ToString() },
                { "identification", t.identification.ToString() },
                {"date", t.date.ToString("yyyy-MM-dd HH:mm:ss.fff") },
                {"amount", t.amount.ToString() }
            };
            return (Models.transaction)await base.InsertGetObjAsync(fillValues);
        }
    }
}
