using DBlibrary;
using ModelsClass;
namespace gadiproj
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //TEST CustomerDB Get by id
            //StudentsDB cdb = new StudentsDB();
            //Dictionary<string, string> param = new Dictionary<string, string>();
            //param.Add("idstudents", "josh");
            //List<students> list = (List<students>)cdb.SelectAll(param);
            //if (list != null)
            //{
            //    Console.WriteLine($" idstudents: {list[0].idstudents} school: {list[0].school} age: {list[0].age} gender: {list[0].gender}");
            //}

            //TEST CustomerDB SelectAll
            //list = (List<students>)cdb.SelectAll();
            //for (int i = 0; i < list.Count; i++)
            //{
            //    Console.WriteLine(@$"idstudents: {list[i].idstudents} school: {list[i].school} age: {list[i].age} gender: {list[i].gender}");
            //}
            //Dictionary<string, string> d = new Dictionary<string, string>();
            //d.Add("idstudents", "max");
            //d.Add("age", "23");
            //d.Add("school", "rogozin");
            //d.Add("gender", "male");
            //StudentsDB r = new StudentsDB();
            //r.Insert(d);

            //students c = new students("bitay", "rogozin", 16, "male");

            //StudentsDB d = new StudentsDB();
            //d.Insert(c);

            //authors c = new authors("george", 1,2,1);
            //AuthorsDB cb = new AuthorsDB();
            //cb.Delete(c);

            borrows b = new borrows(1,"josh",2);
            BorrowsDB cb = new BorrowsDB();
            cb.Insert(b);
        }
    }
}