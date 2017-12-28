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
        static void SelectUsers(DataBase db)
        {
            Console.WriteLine("Selecting users..");
            string query = "SELECT * from users;";
            List<List<string>> ret = db.Execute(new SqlCommand(query, db.conn));
            foreach (List<string> l in ret)
            {
                foreach (string str in l)
                {
                    Console.Write(str + " ");
                }
                Console.WriteLine();
            }
        }

        static void SelectTickets(DataBase db)
        {
            Console.WriteLine("Selecting tickets..");
            string query = "SELECT * from tickets;";
            List<List<string>> ret = db.Execute(new SqlCommand(query, db.conn));
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
            DataBase db = new DataBase("C:\\Madalin\\TicketManager\\database.mdf");
            db.Execute("..\\..\\PopulateUsersTable.sql");
            db.Execute("..\\..\\PopulateTicketsTable.sql");
            SelectUsers(db);
            SelectTickets(db);       
            Application.Run(FormStorer.Get("Login"));
        }

        
    }
}
