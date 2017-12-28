//
// DataBase.cs
//

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace TicketManager {
    public class Database
    {
        private SqlConnection conn_;
        private static Database instance_ = null;

        public static Database Instance()
        {
            if (instance_ == null)
                instance_ = new Database();
            return instance_;
        }

        public void SetConnection(string absolutePath)
        {
            conn_ = new SqlConnection();
            if (conn_.State != ConnectionState.Open)
            {
                string connectionString = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = " +
                    absolutePath + "; Integrated Security = True; Connect Timeout = 30";
                Console.WriteLine("Create database at " + absolutePath);
                conn_.ConnectionString = connectionString;

                OpenIfNotOpen();
            }
            else
            {
                Console.WriteLine("Connection is open");
            }
        }   
        
        private Database()
        {
            conn_ = null;
        }    

        private void OpenIfNotOpen()
        {
            if (conn_.State != ConnectionState.Open)
            {
                try { conn_.Open(); }
                catch (Exception e) {
                    Console.Write(e);
                }
            }
        }

        public List<List<string>> ExecuteQueryFromFile(string filepath)
        {
            string query = File.ReadAllText(filepath);
            return ExecuteQuery(query);
        }

        public List<List<string>> ExecuteQuery(string query)
        {
            SqlCommand cmd = new SqlCommand(query, conn_);

            OpenIfNotOpen();

            List<List<string>> ret = new List<List<string>>();

            try
            {
                SqlDataReader sdr = cmd.ExecuteReader();

                while (sdr.Read())
                {
                    ret.Add(new List<string>());
                    for (int i = 0; i < sdr.FieldCount; ++i)
                        ret[ret.Count - 1].Add(sdr[i] + "");
                }

                sdr.Close();
                sdr.Dispose();
                cmd.Dispose();
            }
            catch (Exception e) {
                Console.WriteLine(e);
            }

            return ret;
        }
    }
}