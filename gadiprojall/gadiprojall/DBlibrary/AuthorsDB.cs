using ModelsClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelsClass;
using System.Net.Http.Headers;

namespace DBlibrary
{
    public class AuthorsDB : BaseDB<authors>
    {
        protected override string GetTableName()
        {
            return "authors";
        }
        protected override authors CreateModel(object[] row)
        {
            authors c = new authors();
            c.idauthors = row[0].ToString();
            c.age = int.Parse(row[1].ToString());
            c.yearsofwriting = int.Parse(row[2].ToString());
            c.IQ = int.Parse(row[3].ToString());
            return c;
        }
        protected override List<authors> CreateListModel(List<object[]> rows)
        {
            List<authors> custList = new List<authors>();
            foreach (object[] item in rows)
            {
                authors c = new authors();
                c = (authors)CreateModel(item);
                custList.Add(c);
            }
            return custList;
        }
        protected override async Task<List<authors>> CreateListModelAsync(List<object[]> rows)
        {
            List<authors> todoList = new List<authors>();
            foreach (object[] item in rows)
            {
                authors c = new authors();
                c = (authors)CreateModel(item);
                todoList.Add(c);
            }
            return todoList;
        }
        protected override async Task<authors> CreateModelAsync(object[] row)
        {
            authors c = new authors();
            c.idauthors = row[0].ToString();
            c.age = int.Parse(row[1].ToString());
            c.yearsofwriting = int.Parse(row[2].ToString());
            c.IQ = int.Parse(row[3].ToString());
            return c;
        }
        // specific queries
        public authors SelectByPk(int id)
        {
            string sql = @"SELECT authors.* FROM authors WHERE (idauthors = @id)";
            cmd.Parameters.AddWithValue("@id", id);
            List<authors> list = (List<authors>)SelectAll(sql);
            if (list.Count == 1)
                return list[0];
            else
                return null;
        }

        protected override authors GetRowByPK(object pk)
        {
            string sql = @"SELECT authors.* FROM authors WHERE
			 	(idauthors = @id)";
            cmd.Parameters.AddWithValue("@id", int.Parse(pk.ToString()));
            List<authors> list = (List<authors>)SelectAll(sql);
            if (list.Count == 1)
                return list[0];
            else
                return null;
        }
        protected override async Task<authors> GetRowByPKAsync(object pk)
        {
            //For proper code it is necessary to use * to retrieve all columns even if they are not used
            string sql = @"SELECT authors.* FROM authors WHERE
			 	(idauthors = @id)";
            cmd.Parameters.AddWithValue("@id", int.Parse(pk.ToString()));
            List<authors> list = (List<authors>)await SelectAllAsync(sql);
            if (list.Count == 1)
                return list[0];
            else
                return null;
        }
        public bool Insert(authors author)
        {
            Dictionary<string, string> val = new Dictionary<string, string>();
            val.Add("idauthors", author.idauthors);
            val.Add("age", author.age.ToString());
            val.Add("yearsofwriting", author.yearsofwriting.ToString());
            val.Add("IQ", author.IQ.ToString());
            return base.Insert(val) != -1;
        }
        public async Task<int> InsertAsync(authors author)
        {
            Dictionary<string, string> val = new Dictionary<string, string>();
            val.Add("idauthors", author.idauthors);
            val.Add("age", author.age.ToString());
            val.Add("yearsofwriting", author.yearsofwriting.ToString());
            val.Add("IQ", author.IQ.ToString());
            return (int)await base.InsertAsync(val);
        }
        public int Update(authors author)
        {
            Dictionary<string, string> val = new Dictionary<string, string>();
            val.Add("idauthors", author.idauthors);
            val.Add("age", author.age.ToString());
            val.Add("yearsofwriting", author.yearsofwriting.ToString());
            val.Add("IQ", author.IQ.ToString());
            Dictionary<string, string> param = new Dictionary<string, string>();
            param.Add("idauthors", author.idauthors);
            return base.Update(val, param);
        }

        public int Delete(authors author)
        {
            Dictionary<string, string> param = new Dictionary<string, string>();
            param.Add("idauthors", author.idauthors);
            return base.Delete(param);
        }
    }
}
