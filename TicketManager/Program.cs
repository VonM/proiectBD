using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace TicketManager
{
    static class Program
    {        
        static void SelectUsers()
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

        static void SelectTickets()
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

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            FormStorer.Add("Login", new Login());

            Database.Instance().SetConnection("C:\\Madalin\\TicketManager\\database.mdf");
                       
            Database.Instance().ExecuteQueryFromFile("..\\..\\PopulateUsersTable.sql");
            Database.Instance().ExecuteQueryFromFile("..\\..\\PopulateTicketsTable.sql");
            SelectUsers();
            SelectTickets();       
            Application.Run(FormStorer.Get("Login"));
        }

        
    }
}
