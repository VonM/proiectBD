using System;
using System.Globalization;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketManager
{
    class DatabaseAPI
    {
        public static string dbDateFormatIn = "yyyyMMdd hh:mm:ss tt";
        public static string dbDateFormatOut = "M/d/yyyy hh:mm:ss tt";

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

        public static DateTime ParseDateFromDB(string date)
        {
            return DateTime.ParseExact(date, dbDateFormatOut, CultureInfo.InvariantCulture);
        }

        public static string ConvertDateToDB(DateTime date)
        {
            return date.ToString(dbDateFormatIn);
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

        private static Ticket ConvertTicket(List<string> rawTicketData)
        {          
            return new Ticket()
            {
                Name = rawTicketData[0],
                FromUser = rawTicketData[1],
                ToUser = rawTicketData[2],
                Priority = (Priority)int.Parse(rawTicketData[3]),
                Department = (Department)Enum.Parse(typeof(Department), rawTicketData[4]),
                Category = (Category)Enum.Parse(typeof(Category), rawTicketData[5]),
                Date = ParseDateFromDB(rawTicketData[6]),
                State = (State)Enum.Parse(typeof(State), rawTicketData[7]),
                Description = rawTicketData[8]
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

        private static string GetAddTicketQuery(Ticket ticket)
        {
            return "INSERT INTO tickets(Name, FromUser, ToUser, Priority, Department, Category, Date, State, Description) VALUES (" +
                "'" + ticket.Name + "', " +
                "'" + ticket.FromUser + "', " +
                "'" + ticket.ToUser + "', " +
                "'" + (int)ticket.Priority + "', " +
                "'" + ticket.Department + "', " +
                "'" + ticket.Category + "', " +
                "'" + ConvertDateToDB(ticket.Date) + "', " +
                "'" + ticket.State + "', " +
                "'" + ticket.Description + "'" +
                ");\n";            
        }

        private static string GetDeleteTicketQuery(Ticket ticket)
        {
            return "DELETE FROM tickets WHERE " +
                   "Name='" + ticket.Name + "' AND " +
                   "FromUser='" + ticket.FromUser + "' AND " +
                   "ToUser='" + ticket.ToUser + "' AND " +
                   "Priority='" + (int)ticket.Priority + "' AND " +
                   "Department='" + ticket.Department + "' AND " +
                   "Category='" + ticket.Category + "' AND " +
                   "Date='" + ConvertDateToDB(ticket.Date) + "' AND " +
                   "State='" + ticket.State + "' AND " +
                   "Description='" + ticket.Description + "'" +
                   ";\n";

        }

        public static void AddTicket(Ticket ticket)
        {
            string query = GetAddTicketQuery(ticket);
            Console.WriteLine(query);
            Database.Instance().ExecuteQuery(query);                
        }

        public static void ReplaceTickets(ArrayList oldTickets, ArrayList newTickets)
        {
            string query = "";
            for (int i = 0; i < oldTickets.Count; i++)
            {
                query += GetDeleteTicketQuery((Ticket)oldTickets[i]);
                query += GetAddTicketQuery((Ticket)newTickets[i]);
            }
           
            Console.Write(query);
            Database.Instance().ExecuteQuery(query);
        }

        private static string GetFilterTicketQuery(
            string department,
            string category,
            string priority,
            string state)
        {
            string query = "SELECT * from tickets";
            int clauses = 0;

            if (department != "" || category != "" || priority != "" || state != "")
                query += " WHERE ";

            if (department != "")
            {
                if (clauses > 0)
                {
                    query += " AND ";
                }
                query += "Department=" + "'" + department + "'";
                clauses++;
            }

            if (category != "")
            {
                if (clauses > 0)
                {
                    query += " AND ";
                }
                query += "Category=" + "'" + category + "'";
                clauses++;
            }

            if (priority != "")
            {
                if (clauses > 0)
                {
                    query += " AND ";
                }
                query += "Priority=" + "'" + priority + "'";
                clauses++;
            }


            if (state != "")
            {
                if (clauses > 0)
                {
                    query += " AND ";
                }
                clauses++;
                query += "State=" + "'" + state + "'";
            }

            return query;
        }
            

        public static ArrayList SelectTicketsToUser(
            string department,
            string category,
            string priority,
            string state,
            string sortCategory,
            string toUser)
        {
            string query = GetFilterTicketQuery(department, category, priority, state);
            if (department != "" || category != "" || priority != "" || state != "")
                query += " AND ToUser=" + "'" + toUser + "'";
            else
                query += " WHERE ToUser=" + "'" + toUser + "'";

            if (sortCategory == SortCategory.Date.ToString())
                query += " ORDER BY Date";
            else if (sortCategory == SortCategory.Priority.ToString())
                query += " ORDER BY Priority";

            query += ";";

            Console.WriteLine(query);
            List<List<string>> res = Database.Instance().ExecuteQuery(query);

            ArrayList tickets = new ArrayList();
            foreach (List<string> t in res)
            {
                tickets.Add(ConvertTicket(t));
            }
            return tickets;
        }

        public static ArrayList SelectTicketsFromUser(
            string department,
            string category,
            string priority,
            string state,
            string sortCategory,
            string fromUser)
        {
            string query = GetFilterTicketQuery(department, category, priority, state);
            if (department != "" || category != "" || priority != "" || state != "")
                query += " AND FromUser=" + "'" + fromUser + "'";
            else
                query += " WHERE FromUser=" + "'" + fromUser + "'";

            if (sortCategory == SortCategory.Date.ToString())
                query += " ORDER BY Date";
            else if (sortCategory == SortCategory.Priority.ToString())
                query += " ORDER BY Priority";

            query += ";";

            Console.WriteLine(query);
            List<List<string>> res = Database.Instance().ExecuteQuery(query);

            ArrayList tickets = new ArrayList();
            foreach (List<string> t in res)
            {
                tickets.Add(ConvertTicket(t));
            }
            return tickets;
        }

        public static ArrayList SelectTickets(
            string department,
            string category,
            string priority,
            string state,
            string sortCategory)
        {
            string query = GetFilterTicketQuery(department, category, priority, state);

            if (sortCategory == SortCategory.Date.ToString())
                query += " ORDER BY Date";
            else if (sortCategory == SortCategory.Priority.ToString())
                query += " ORDER BY Priority";
                        
            query += ";";

            Console.WriteLine(query);
            List<List<string>> res = Database.Instance().ExecuteQuery(query);

            ArrayList tickets = new ArrayList();
            foreach (List<string> t in res)
            {   
                tickets.Add(ConvertTicket(t));
            }
            return tickets;            
        }
    }
}
