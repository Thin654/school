using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelsClass;

namespace DBlibrary
{
    public class BooksDB: BaseDB<books>
    {
        protected override string GetTableName()
        {
            return "books";
        }
        protected override books CreateModel(object[] row)
        {
            books c = new books();
            c.idbook = int.Parse(row[0].ToString());
            c.author = row[1].ToString();
            c.pages = row[2].ToString();
            c.lang = row[3].ToString();
            return c;
        }
        protected override async Task<books> CreateModelAsync(object[] row)
        {
            books c = new books();
            c.idbook = int.Parse(row[0].ToString());
            c.author = row[1].ToString();
            c.pages = row[2].ToString();
            c.lang = row[3].ToString();
            return c;
        }
        protected override List<books> CreateListModel(List<object[]> rows)
        {
            List<books> custList = new List<books>();
            foreach (object[] item in rows)
            {
                books c = new books();
                c = (books)CreateModel(item);
                custList.Add(c);
            }
            return custList;
        }
        protected override async Task<List<books>> CreateListModelAsync(List<object[]> rows)
        {
            List<books> todoList = new List<books>();
            foreach (object[] item in rows)
            {
                books c = new books();
                c = (books)CreateModel(item);
                todoList.Add(c);
            }
            return todoList;
        }
        // specific queries
        public books SelectByPk(int id)
        {
            string sql = @"SELECT books.* FROM books WHERE (idbook = @id)";
            cmd.Parameters.AddWithValue("@id", id);
            List<books> list = (List<books>)SelectAll(sql);
            if (list.Count == 1)
                return list[0];
            else
                return null;
        }
        public async Task<books> SelectByPkAsync(int id)
        {
            string sql = @"SELECT books.* FROM books WHERE (idbooks = @id)";
            cmd.Parameters.AddWithValue("@id", id);
            List<books> list = (List<books>)await SelectAllAsync(sql);
            if (list.Count == 1)
                return list[0];
            else
                return null;
        }
        protected override books GetRowByPK(object pk)
        {
            string sql = @"SELECT books.* FROM books WHERE
			 	(idbook = @id)";
            cmd.Parameters.AddWithValue("@id", int.Parse(pk.ToString()));
            List<books> list = (List<books>)SelectAll(sql);
            if (list.Count == 1)
                return list[0];
            else
                return null;
        }
        protected override async Task<books> GetRowByPKAsync(object pk)
        {
            //For proper code it is necessary to use * to retrieve all columns even if they are not used
            string sql = @"SELECT books.* FROM books WHERE
			 	(idbook = @id)";
            cmd.Parameters.AddWithValue("@id", int.Parse(pk.ToString()));
            List<books> list = (List<books>)await SelectAllAsync(sql);
            if (list.Count == 1)
                return list[0];
            else
                return null;
        }
        public bool Insert(books book)
        {
            Dictionary<string, string> val = new Dictionary<string, string>();
            val.Add("idbooks", book.idbook.ToString());
            val.Add("author", book.author);
            val.Add("pages", book.pages);
            val.Add("lang", book.lang);
            return base.Insert(val) != -1;
        }
        public async Task<int> InsertAsync(books book)
        {
            Dictionary<string, string> val = new Dictionary<string, string>();
            val.Add("idbooks", book.idbook.ToString());
            val.Add("author", book.author);
            val.Add("pages", book.pages);
            val.Add("lang", book.lang);
            return (int)await base.InsertAsync(val);
        }
        public int Update(books book)
        {
            Dictionary<string, string> val = new Dictionary<string, string>();
            val.Add("idbooks", book.idbook.ToString());
            val.Add("author", book.author);
            val.Add("pages", book.pages);
            val.Add("lang", book.lang);
            Dictionary<string, string> param = new Dictionary<string, string>();
            param.Add("pokemon_id", book.idbook.ToString());
            return base.Update(val, param);
        }

        public int Delete(books book)
        {
            Dictionary<string, string> param = new Dictionary<string, string>();
            param.Add("idbooks", book.idbook.ToString());
            return base.Delete(param);
        }
    }
}
