using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Task4;

namespace Test
{
    [TestFixture]
    public class NorthwindDatabaseTests
    {
        [Test]
        public void TestQueryThatHasResult()
        {
            string sql = "Select FirstName, LastName From Employees Where FirstName Like 'A%'";
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Northwind";
            DatabaseService service = new DatabaseService(connectionString);
            service.ShowData(sql);
        }

        [Test]
        public void TestQueryThatHasNotResult()
        {
            string sql = "Select FirstName, LastName From Employees Where City = 'Not existring'";
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Northwind";
            DatabaseService service = new DatabaseService(connectionString);
            service.ShowData(sql);
        }
    }
}
