using ModelsClass;
using System.Reflection;

namespace DBlibrary
{
    public class StudentsDB : BaseDB<students>
    {
        protected override string GetTableName()
        {
            return "students";
        }
        protected override students CreateModel(object[] row)
        {
            students c = new students();
            c.idstudents = row[0].ToString();
            c.age = int.Parse(row[1].ToString());
            c.school = row[2].ToString();
            c.gender = row[3].ToString();
            return c;
        }
        protected override List<students> CreateListModel(List<object[]> rows)
        {
            List<students> custList = new List<students>();
            foreach (object[] item in rows)
            {
                students c = new students();
                c = (students)CreateModel(item);
                custList.Add(c);
            }
            return custList;
        }
        protected override async Task<List<students>> CreateListModelAsync(List<object[]> rows)
        {
            List<students> student = new List<students>();
            foreach (object[] item in rows)
            {
                students c = new students();
                c = (students)CreateModel(item);
                student.Add(c);
            }
            return student;
        }
        protected override async Task<students> CreateModelAsync(object[] row)
        {
            students c = new students();
            c.idstudents = row[0].ToString();
            c.age = int.Parse(row[1].ToString());
            c.school = row[2].ToString();
            c.gender = row[3].ToString();
            return c;
        }
        // specific queries
        public students SelectByPk(string id)
        {
            string sql = @"SELECT students.* FROM students WHERE (idstudents = @id)";
            cmd.Parameters.AddWithValue("@id", id);
            List<students> list = (List<students>)SelectAll(sql);
            if (list.Count == 1)
                return list[0];
            else
                return null;
        }
        public async Task<students> SelectByPkAsync(string id)
        {
            string sql = @"SELECT students.* FROM students WHERE (idstudents = @id)";
            cmd.Parameters.AddWithValue("@id", id);
            List<students> list = (List<students>)await SelectAllAsync(sql);
            if (list.Count == 1)
                return list[0];
            else
                return null;
        }

        protected override students GetRowByPK(object pk)
        {
            string sql = @"SELECT students.* FROM students WHERE
			 	(idstudents = @id)";
            cmd.Parameters.AddWithValue("@id", int.Parse(pk.ToString()));
            List<students> list = (List<students>)SelectAll(sql);
            if (list.Count == 1)
                return list[0];
            else
                return null;

        }
        protected override async Task<students> GetRowByPKAsync(object pk)
        {
            //For proper code it is necessary to use * to retrieve all columns even if they are not used
            string sql = @"SELECT students.* FROM students WHERE
			 	(idstudents = @id)";
            cmd.Parameters.AddWithValue("@id", int.Parse(pk.ToString()));
            List<students> list = (List<students>)await SelectAllAsync(sql);
            if (list.Count == 1)
                return list[0];
            else
                return null;
        }
        public async Task<List<students>> GetAllAsync()
        {
            return ((List<students>)await SelectAllAsync());
        }

        public async Task<List<students>> GetAllAsync(Dictionary<string, string> parameters)
        {
            return ((List<students>)await SelectAllAsync(parameters));
        }

        public List<students> GetAll()
        {
            return ((List<students>)SelectAll());
        }
        public async Task<int> InsertAsync(students student)
        {
            Dictionary<string, string> val = new Dictionary<string, string>();
            val.Add("idstudents", student.idstudents);
            val.Add("age", student.age.ToString());
            val.Add("school", student.school);
            val.Add("gender", student.gender);
            return (int)await base.InsertAsync(val);
        }
        public bool Insert(students student)
        {
            Dictionary<string, string> val = new Dictionary<string, string>();
            val.Add("idstudents", student.idstudents);
            val.Add("age", student.age.ToString());
            val.Add("school", student.school);
            val.Add("gender", student.gender);
            return base.Insert(val) != -1;
        }
        public async Task<students> login(string idstudents, string school)
        {
            string sql = @$"SELECT idstudents FROM library.students
                            WHERE idstudents='{idstudents}' AND school = '{school}';";
            object res = await ExecNonQueryAsync(sql);
            if (res != null)
            {
                string id = Convert.ToString(res);
                students student = (students)await SelectByPkAsync(idstudents);
                return student;
            }
            else
                return null;
        }
        public int Update(students student)
        {
            Dictionary<string, string> val = new Dictionary<string, string>();
            val.Add("idstudents", student.idstudents);
            val.Add("age", student.age.ToString());
            val.Add("school", student.school);
            val.Add("gender", student.gender);
            Dictionary<string, string> param = new Dictionary<string, string>();
            param.Add("idstudents", student.idstudents);
            return base.Update(val, param);
        }

        public int Delete(students student)
        {
            Dictionary<string, string> param = new Dictionary<string, string>();
            param.Add("idstudents", student.idstudents);
            return base.Delete(param);
        }
        public async Task<int> DeleteAsync(students customer)
        {
            Dictionary<string, string> filterValues = new Dictionary<string, string>
            {
                { "CustomerId", customer.idstudents.ToString() }
            };
            return await base.DeleteAsync(filterValues);
        }
    }
}