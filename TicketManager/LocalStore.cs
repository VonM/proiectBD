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
            // TODO
        }    

        public static void LoadTicketsFromDB(string fromUser)
        {
            // TODO
        }
    }
}
