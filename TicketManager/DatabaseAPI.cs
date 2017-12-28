using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketManager
{
    class DatabaseAPI
    {
        public static void SelectUsers()
        {
            Console.WriteLine("Selecting users..");
            string query = "SELECT * from users;";
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

            List<string> first = ret[0];
            return new User()
            {
                Username = first[0],
                Password = first[1],
                Role = (Role)Enum.Parse(typeof(Role), first[2]),
                Department = (Department)Enum.Parse(typeof(Department), first[3])
            };
        }
    }
}
