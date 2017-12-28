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
    public class DataBase
    {
        public SqlConnection conn;

        public DataBase(string absolutePath)
        {            
            conn = new SqlConnection();
            if (conn.State != ConnectionState.Open)
            {                                
                string connectionString = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = " +
                    absolutePath + "; Integrated Security = True; Connect Timeout = 30";
                Console.WriteLine("Create database at " + absolutePath);
                conn.ConnectionString = connectionString;

                OpenIfNotOpen();
            } else
            {
                Console.WriteLine("Connection is open");
            }
        }

        private void OpenIfNotOpen()
        {
            if (conn.State != ConnectionState.Open)
            {
                try { conn.Open(); }
                catch (Exception e) {
                    Console.Write(e);
                }
            }
        }

        public List<List<string>> Execute(string filepath)
        {
            string query = File.ReadAllText(filepath);
            return Execute(new SqlCommand(query, conn));
        }

        public List<List<string>> Execute(SqlCommand cmd)
        {
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