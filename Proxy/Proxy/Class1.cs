using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy
{
    internal class Class1
    {
        public interface IDatabase
        {
            List<string> GetData();
            void SaveData(string data);
        }

        // реальна база даних
        public class Database : IDatabase
        {
            public List<string> GetData()
            {
                // отримуємо дані з бази даних
                return new List<string> { "data1", "data2", "data3" };
            }

            public void SaveData(string data)
            {
                // зберігаємо дані у базу даних
            }
        }

        // проксі для бази даних
        public class DatabaseProxy : IDatabase
        {
            private Database _database;
            private User _user;

            public DatabaseProxy(User user)
            {
                _user = user;
                _database = new Database();
            }

            public List<string> GetData()
            {
                if (_user.HasAccessToDatabase)
                {
                    return _database.GetData();
                }
                else
                {
                    throw new Exception("User does not have access to the database.");
                }
            }

            public void SaveData(string data)
            {
                if (_user.HasAccessToDatabase)
                {
                    _database.SaveData(data);
                }
                else
                {
                    throw new Exception("User does not have access to the database.");
                }
            }
        }

        // користувач
        public class User
        {
            public string Username { get; set; }
            public string Password { get; set; }
            public bool HasAccessToDatabase { get; set; }

            public User(string username, string password)
            {
                Username = username;
                Password = password;
                // перевірка доступу користувача до бази даних
                HasAccessToDatabase = CheckAccessToDatabase();
            }

            private bool CheckAccessToDatabase()
            {
                // перевірка доступу до бази даних
                // повертає true, якщо доступ дозволений
                // повертає false, якщо доступ заборонений
                return true;
            }
        }
    }
}
