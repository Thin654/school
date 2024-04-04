using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace DBL
{
    public class DoubleDB : BaseDB<double>
    {
        protected override double CreateModel(object[] row)
        {
            double d = double.Parse(row[0].ToString());
            return d;
        }
        protected override async Task<double> CreateModelAsync(object[] row)
        {
            double d = double.Parse(row[0].ToString());
            return d;
        }
        protected override string GetTableName()
        {
            return null;
        }

        //protected abstract T GetRowByPK(object pk);
        protected override Task<double> GetRowByPKAsync(object pk)
        {
            return null;
        }
        protected override async Task<List<double>> CreateListModelAsync(List<object[]> rows)
        {
            List<double> custList = new List<double>();
            foreach (object[] item in rows)
            {
                double c;
                c = CreateModel(item);
                custList.Add(c);
            }
            return custList;
        }
        protected override List<double> CreateListModel(List<object[]> rows)
        {
            List<double> custList = new List<double>();
            foreach (object[] item in rows)
            {
                double c;
                c = CreateModel(item);
                custList.Add(c);
            }
            return custList;
        }
        public async Task<List<double>> GetSUMByCoinAndCustomer(object pk, object coincode)
        {
            string sql = @"SELECT SUM(amount) AS total_amount
                            FROM projectmax.trade
                                Where customerid = @customerid and coinid = @coincode;";
            AddParameterToCommand("@customerid", int.Parse(pk.ToString()));
            AddParameterToCommand("@coincode", int.Parse(coincode.ToString()));
            List<double> list = (List<double>)await SelectAllAsync(sql);
            if (list.Count == 1)
                return list;
            return null;
        }
    }
}
