using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketManager
{
    class DatabaseAPI
    {
        public static void SelectTickets()
        {
            Console.WriteLine("Selecting tickets..");
            string query = "SELECT * from tickets;";
            List<List<string>> ret = Database.Instance().ExecuteQuery(query);
            foreach (List<string> l in ret)
            {
                foreach (string str in l)
                {
                    Console.Write(str + " ");
                }
                Console.WriteLine();
            }
        }

        private static User ConvertUser(List<string> rawUserData)
        {
            return new User()
            {
                Username = rawUserData[0],
                Password = rawUserData[1],
                Role = (Role)Enum.Parse(typeof(Role), rawUserData[2]),
                Department = (Department)Enum.Parse(typeof(Department), rawUserData[3])
            };
        }

        public static User SelectUser(string username)
        {
            string query = "SELECT * from users WHERE Username='" + username + "';";
            List<List<string>> ret = Database.Instance().ExecuteQuery(query);
            
            foreach (List<string> l in ret)
            {
                foreach (string str in l)
                {
                    Console.Write(str + " ");
                }
                Console.WriteLine();
            }
            if (ret.Count == 0)
            {
                return null;
            }
            if (ret.Count > 1)
            {
                throw new Exception("More users with the same username inside database!");
            }

            return ConvertUser(ret[0]);
        }

        public static ArrayList SelectUsers()
        {
            ArrayList users = new ArrayList();
            string query = "SELECT * from users;";
            List<List<string>> rawUsers = Database.Instance().ExecuteQuery(query);

            foreach (List<string> rawUser in rawUsers) {
                users.Add(ConvertUser(rawUser));
            }
            return users;
        }

        public static void UpdateUsers(ArrayList users)
        {
            string query =
                "TRUNCATE TABLE users;";

            foreach (User u in users)
            {
                query += "INSERT INTO users (Username, Password, Role, Department) VALUES (" +
                    "'" + u.Username + "', " +
                    "'" + u.Password + "', " +
                    "'" + u.Role + "', " +
                    "'" + u.Department + "'" +
                    ");";
            }

            Database.Instance().ExecuteQuery(query);
        }
    }
}
