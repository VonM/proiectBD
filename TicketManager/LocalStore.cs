using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace TicketManager
{
    class LocalStore
    {
        public static User currentUser = new User();
        public static ArrayList users = new ArrayList();
        public static ArrayList tickets = new ArrayList();

        public static void LoadUsersFromDB()
        {
            Console.WriteLine("Loading users from database...");
            users = DatabaseAPI.SelectUsers();
        }    

        public static void LoadTicketsFromDB(string fromUser)
        {
            // TODO
        }

        public static void UpdateUsers(ArrayList userList)
        {
            Console.WriteLine("Updated users: ");
            foreach (User u in userList)
            {
                Console.Write(u);
            }
            users = userList;
            DatabaseAPI.UpdateUsers(userList);
        }
    }
}
