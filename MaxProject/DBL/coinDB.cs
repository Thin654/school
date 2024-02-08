using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBL
{
    public class coinDB: BaseDB<coin>
    {
        protected override string GetTableName()
        {
            return "coin";
        }
        protected override coin CreateModel(object[] row)
        {
            coin c = new coin();
            c.coincode = int.Parse(row[0].ToString());
            c.symbol = row[1].ToString();
            c.namecoin = row[2].ToString();
            c.icon = (byte[])(row[3]);
            c.rate = int.Parse(row[4].ToString());
            return c;
        }
        protected override async Task<coin> CreateModelAsync(object[] row)
        {
            coin c = new coin();
            c.coincode = int.Parse(row[0].ToString());
            c.symbol = row[1].ToString();
            c.namecoin = row[2].ToString();
            //c.icon = (byte[])(row[3]);
            c.rate = int.Parse(row[4].ToString());
            return c;
        }
        protected override List<coin> CreateListModel(List<object[]> rows)
        {
            List<coin> custList = new List<coin>();
            foreach (object[] item in rows)
            {
                coin c;
                c = CreateModel(item);
                custList.Add(c);
            }
            return custList;
        }
        protected override async Task<List<coin>> CreateListModelAsync(List<object[]> rows)
        {
            List<coin> custList = new List<coin>();
            foreach (object[] item in rows)
            {
                coin c = new coin();
                c = (coin)CreateModel(item);
                custList.Add(c);
            }
            return custList;
        }
        protected override async Task<coin> GetRowByPKAsync(object pk)
        {
            string sql = @"SELECT coin.* FROM coin WHERE (coincode = @id)";
            AddParameterToCommand("@id", int.Parse(pk.ToString()));
            List<coin> list = (List<coin>)await SelectAllAsync(sql);
            if (list.Count == 1)
                return list[0];
            else
                return null;
        }
        protected override coin GetRowByPK(object pk)
        {
            string sql = @"SELECT coin.* FROM coin WHERE (coincode = @id)";
            AddParameterToCommand("@id", int.Parse(pk.ToString()));
            List<coin> list = (List<coin>)SelectAll(sql);
            if (list.Count == 1)
                return list[0];
            else
                return null;
        }
        public async Task<List<coin>> GetAllAsync()
        {
            return ((List<coin>)await SelectAllAsync());
        }
        public async Task<coin> SelectByPkAsync(int id)
        {
            string sql = @"SELECT coin.* FROM coin WHERE (coincode = @id)";
            AddParameterToCommand("@id", id);
            List<coin> list = (List<coin>)await SelectAllAsync(sql);
            if (list.Count == 1)
                return list[0];
            else
                return null;
        }
        public async Task<int> DeleteAsync(coin coin)
        {
            Dictionary<string, string> filterValues = new Dictionary<string, string>
            {
                { "coincode", coin.coincode.ToString() }
            };
            return await base.DeleteAsync(filterValues);
        }
        //public async Task<coin> InsertGetObjAsync(coin coin)
        //{
        //    Dictionary<string, string> fillValues = new Dictionary<string, string>()
        //    {
        //        { "coincode", coin.coincode.ToString()},
        //        { "symbol", coin.symbol },
        //        { "namecoin", coin.namecoin}
        //        {"icon", coin.icon }
        //    };
        //    return (customer)await base.InsertGetObjAsync(fillValues);
        //}
        public async Task<coin> InsertGetObjAsync(coin coin)
        {
            Dictionary<string, object> fillValues = new Dictionary<string, object>()
            {
                { "coincode", coin.coincode },
                { "symbol", coin.symbol },
                { "namecoin", coin.namecoin },
                { "icon", coin.icon },
                { "rate", coin.rate.ToString() }
            };
            return (coin)await base.InsertGetObjAsync(fillValues);
        }
    }
}
