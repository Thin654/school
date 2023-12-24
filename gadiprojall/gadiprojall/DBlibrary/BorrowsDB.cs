using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelsClass;
namespace DBlibrary
{
    public class BorrowsDB : BaseDB<borrows>
    {
        protected override string GetTableName()
        {
            return "borrows";
        }
        protected override borrows CreateModel(object[] row)
        {
            borrows c = new borrows();
            c.idstudents = row[0].ToString();
            c.idbook = int.Parse(row[1].ToString());
            return c;
        }
        protected override List<borrows> CreateListModel(List<object[]> rows)
        {
            List<borrows> custList = new List<borrows>();
            foreach (object[] item in rows)
            {
                borrows c = new borrows();
                c = (borrows)CreateModel(item);
                custList.Add(c);
            }
            return custList;
        }
        protected override async Task<borrows> CreateModelAsync(object[] row)
        {
            borrows c = new borrows();
            c.idstudents = row[0].ToString();
            c.idbook = int.Parse(row[1].ToString());
            return c;
        }
        protected override async Task<List<borrows>> CreateListModelAsync(List<object[]> rows)
        {
            List<borrows> custList = new List<borrows>();
            foreach (object[] item in rows)
            {
                borrows c = new borrows();
                c = (borrows)CreateModel(item);
                custList.Add(c);
            }
            return custList;
        }
        // specific queries
        public borrows SelectByPk(int id)
        {
            string sql = @"SELECT borrows.* FROM borrows WHERE (idborrows = @id)";
            cmd.Parameters.AddWithValue("@id", id);
            List<borrows> list = (List<borrows>)SelectAll(sql);
            if (list.Count == 1)
                return list[0];
            else
                return null;
        }

        protected override borrows GetRowByPK(object pk)
        {
            string sql = @"SELECT borrows.* FROM borrows WHERE
			 	(idborrows = @id)";
            cmd.Parameters.AddWithValue("@id", int.Parse(pk.ToString()));
            List<borrows> list = (List<borrows>)SelectAll(sql);
            if (list.Count == 1)
                return list[0];
            else
                return null;
        }
        protected override async Task<borrows> GetRowByPKAsync(object pk)
        {
            //For proper code it is necessary to use * to retrieve all columns even if they are not used
            string sql = @"SELECT borrows.* FROM borrows WHERE
			 	(idstudents = @id)";
            cmd.Parameters.AddWithValue("@id", int.Parse(pk.ToString()));
            List<borrows> list = (List<borrows>)await SelectAllAsync(sql);
            if (list.Count == 1)
                return list[0];
            else
                return null;
        }
        public bool Insert(borrows borrow)
        {
            Dictionary<string, string> val = new Dictionary<string, string>();
            val.Add("idstudents", borrow.idstudents);
            val.Add("idbook", borrow.idbook.ToString());
            return base.Insert(val) != -1;
        }
        public async Task<int> InsertAsync(borrows borrow)
        {
            Dictionary<string, string> val = new Dictionary<string, string>();
            val.Add("idstudents", borrow.idstudents);
            val.Add("idbook", borrow.idbook.ToString());
            return (int)await base.InsertAsync(val);
        }
        public int Update(borrows borrow)
        {
            Dictionary<string, string> val = new Dictionary<string, string>();
            val.Add("idstudents", borrow.idstudents);
            val.Add("idbook", borrow.idbook.ToString());
            Dictionary<string, string> param = new Dictionary<string, string>();
            param.Add("idstudents", borrow.idstudents.ToString());
            param.Add("idbook", borrow.idbook.ToString());
            return base.Update(val, param);
        }

        public int Delete(borrows borrow)
        {
            Dictionary<string, string> param = new Dictionary<string, string>();
            param.Add("idstudents", borrow.idstudents.ToString());
            param.Add("idbook", borrow.idbook.ToString());
            return base.Delete(param);
        }
    }
}
