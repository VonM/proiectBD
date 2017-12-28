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
        
        static void PopulateDatabase()
        {
            Database.Instance().ExecuteQueryFromFile("..\\..\\PopulateUsersTable.sql");
            Database.Instance().ExecuteQueryFromFile("..\\..\\PopulateTicketsTable.sql");
        }

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            FormStorer.Add("Login", new Login());

            Database.Instance().SetConnection("C:\\Madalin\\TicketManager\\database-new.mdf");
            //PopulateDatabase();                       

            DatabaseAPI.SelectUsers();
            DatabaseAPI.SelectTickets();       

            Application.Run(FormStorer.Get("Login"));
        }

        
    }
}
