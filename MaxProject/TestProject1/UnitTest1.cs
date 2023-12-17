using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;
using DBL;
using Models;

namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void StringLengthTest()
        {
            string str = "Hello, MSTest!";

            Assert.AreEqual(14, str.Length);
        }
        [TestMethod]
        public async Task Test2Update()
        {
            customer cs = new customer(1, "John Do", "testemail@.com", "newpassword");
            customerDB cb = new customerDB();

            
            
        }

        
    }
}