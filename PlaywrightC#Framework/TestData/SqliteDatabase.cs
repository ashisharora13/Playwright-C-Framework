using System.Collections.Generic;
using System.Data.SQLite;

namespace SauceDemo.TestData
{
    public static class SqliteDatabase
    {
        private const string ConnectionString = @"Data Source=TestData/testdata.db;";

        public static IEnumerable<User> GetTestUsers()
        {
            var users = new List<User>();
            using var connection = new SQLiteConnection(ConnectionString);
            connection.Open();
            var command = new SQLiteCommand("SELECT Username, Password FROM Users", connection);
            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                users.Add(new User
                {
                    Username = reader.GetString(0),
                    Password = reader.GetString(1)
                });
            }
            return users;
        }

        public static IEnumerable<CustomerInfo> GetCustomerInfo()
        {
            var customerInfo = new List<CustomerInfo>();
            using var connection = new SQLiteConnection(ConnectionString);
            connection.Open();
            var command = new SQLiteCommand("SELECT FirstName, LastName, ZipCode FROM CustomerInfo", connection);
            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                customerInfo.Add(new CustomerInfo
                {
                    FirstName = reader.GetString(0),
                    LastName = reader.GetString(1),
                    ZipCode = reader.GetString(2)
                });
            }
            return customerInfo;
        }

        public class User
        {
            public required string Username { get; set; }
            public required string Password { get; set; }
        }

        public class CustomerInfo
        {
            public required string FirstName { get; set; }
            public required string LastName { get; set; }
            public required string ZipCode { get; set; }
        }
    }
}
