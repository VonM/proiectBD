using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace TicketManager
{
    static class Program
    {        
        
        static void PopulateDatabase()
        {
           
        }

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            FormStorer.Add("Login", new Login());

            Database.Instance().SetConnection("C:\\Madalin\\TicketManager\\database-new.mdf");
            Database.Instance().ExecuteQueryFromFile("..\\..\\PopulateUsersTable.sql");
            Database.Instance().ExecuteQueryFromFile("..\\..\\PopulateTicketsTable.sql");

            ArrayList users = DatabaseAPI.SelectUsers();
            foreach (User u in users)
                Console.Write(u);
            DatabaseAPI.SelectTickets();       

            Application.Run(FormStorer.Get("Login"));
        }

        
    }
}
