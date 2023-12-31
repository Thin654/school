using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace DBL
{
    public class customerDB : BaseDB<customer>
    {
        protected override string GetTableName()
        {
            return "customer";
        }
        protected override customer CreateModel(object[] row)
        {
            customer c = new customer();
            c.id = int.Parse(row[0].ToString());
            c.name = row[1].ToString();
            c.email = row[2].ToString();
            c.password = row[3].ToString();
            return c;
        }
        protected override async Task<customer> CreateModelAsync(object[] row)
        {
            customer c = new customer();
            c.id = int.Parse(row[0].ToString());
            c.name = row[1].ToString();
            c.email = row[2].ToString();
            c.password = row[4].ToString();
            return c;
        }
        protected override List<customer> CreateListModel(List<object[]> rows)
        {
            List<customer> custList = new List<customer>();
            foreach (object[] item in rows)
            {
                customer c;
                c = CreateModel(item);
                custList.Add(c);
            }
            return custList;
        }
        protected override async Task<List<customer>> CreateListModelAsync(List<object[]> rows)
        {
            List<customer> custList = new List<customer>();
            foreach (object[] item in rows)
            {
                customer c = new customer();
                c = (customer)CreateModel(item);
                custList.Add(c);
            }
            return custList;
        }
        protected override async Task<customer> GetRowByPKAsync(object pk)
        {
            string sql = @"SELECT customer.* FROM customer WHERE (idcustomer = @id)";
            AddParameterToCommand("@id", int.Parse(pk.ToString()));
            List<customer> list = (List<customer>)await SelectAllAsync(sql);
            if (list.Count == 1)
                return list[0];
            else
                return null;
        }
        protected override customer GetRowByPK(object pk)
        {
            string sql = @"SELECT customer.* FROM customer WHERE (idcustomer = @id)";
            AddParameterToCommand("@id", int.Parse(pk.ToString()));
            List<customer> list = (List<customer>)SelectAll(sql);
            if (list.Count == 1)
                return list[0];
            else
                return null;
        }
        public async Task<List<customer>> GetAllAsync()
        {
            return ((List<customer>)await SelectAllAsync());
        }
        public async Task<customer> SelectByPkAsync(int id)
        {
            string sql = @"SELECT customer.* FROM customer WHERE (idcustomer = @id)";
            AddParameterToCommand("@id", id);
            List<customer> list = (List<customer>)await SelectAllAsync(sql);
            if (list.Count == 1)
                return list[0];
            else
                return null;
        }
        public async Task<customer> SelectByEmailPassAsync(string email, string password)
        {
            string sql = @$"SELECT customer.* FROM projectmax.customer WHERE email = '{email}' AND password = '{password}';";
            List<customer> list = (List<customer>)await SelectAllAsync(sql);
            if (list.Count == 1)
                return list[0];
            else
                return null;
        }
        public async Task<int> DeleteAsync(customer customer)
        {
            Dictionary<string, string> filterValues = new Dictionary<string, string>
            {
                { "idcustomer", customer.id.ToString() }
            };
            return await base.DeleteAsync(filterValues);
        }
        public async Task<int> UpdateAsync(customer customer)
        {
            Dictionary<string, string> fillValues = new Dictionary<string, string>();
            Dictionary<string, string> filterValues = new Dictionary<string, string>();
            fillValues.Add("name", customer.name);
            fillValues.Add("email", customer.email);
            filterValues.Add("idcustomer", customer.id.ToString());
            return await base.UpdateAsync(fillValues, filterValues);
        }
        public async Task<customer> InsertGetObjAsync(customer customer)
        {
            Dictionary<string, string> fillValues = new Dictionary<string, string>()
            {
                { "name", customer.name },
                { "email", customer.email },
                { "password", customer.password }
            };
            return (customer)await base.InsertGetObjAsync(fillValues);
        }
        
        public async Task<customer> login(string email, string password)
        {
            string sql = @$"SELECT customer.idcustomer FROM projectmax.customer WHERE email='{email}' AND password = '{password}';";
            object res = await ExecNonQueryAsync(sql);
            if (res != null)
            {
                customer customer = (customer)await SelectByEmailPassAsync(email, password);
                return customer;
            }
            else
                return null;
        }

    }
}
