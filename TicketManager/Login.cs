using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace TicketManager
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            this.label3.Text = "";                    
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private static string sha256(string randomString)
        {
            System.Security.Cryptography.SHA256Managed crypt = new System.Security.Cryptography.SHA256Managed();
            System.Text.StringBuilder hash = new System.Text.StringBuilder();
            byte[] crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(randomString), 0, Encoding.UTF8.GetByteCount(randomString));
            foreach (byte theByte in crypto)
            {
                hash.Append(theByte.ToString("x2"));
            }
            return hash.ToString().ToUpper();
        }

        private void button1_Click(object sender, EventArgs e)
        {            
            Console.WriteLine(this.textBox1.Text);
            Console.WriteLine(this.textBox2.Text);
            
            LocalStore.currentUser = DatabaseAPI.SelectUser(this.textBox1.Text);
            if (LocalStore.currentUser == null)
            {
                Console.WriteLine("Invalid username.");
                label3.Text = "Invalid username!";
                this.textBox1.Text = "";
                this.textBox2.Text = "";
            } else
            {
                label3.Text = "";
                string hashedPassword = sha256(this.textBox2.Text);
                Console.WriteLine("Gen hash: " + hashedPassword);
                if (LocalStore.currentUser.Password == hashedPassword)
                {
                    FormStorer.Add("Dashboard", new Dashboard());
                    FormStorer.Get("Login").Visible = false;
                    ((Dashboard)FormStorer.Get("Dashboard")).SetCurrentUser();
                    FormStorer.Get("Dashboard").Visible = true;
                } else
                {
                    Console.WriteLine("Invalid password.");
                    label3.Text = "Invalid password!";
                    this.textBox1.Text = "";
                    this.textBox2.Text = "";
                }
                
            }

            
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
