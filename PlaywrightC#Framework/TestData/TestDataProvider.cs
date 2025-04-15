using System.Collections.Generic;
using System.Linq;

namespace SauceDemo.TestData
{
    public class TestDataProvider
    {
        private readonly string _dbPath;

        public TestDataProvider(string dbPath)
        {
            _dbPath = dbPath;
        }

        public IEnumerable<SqliteDatabase.User> GetTestUsers()
        {
            return SqliteDatabase.GetTestUsers();
        }

        public IEnumerable<SqliteDatabase.CustomerInfo> GetCustomerInfo()
        {
            return SqliteDatabase.GetCustomerInfo();
        }
    }
}
