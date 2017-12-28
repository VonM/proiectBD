using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicketManager
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();         
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

        private void button1_Click(object sender, EventArgs e)
        {            
            Console.WriteLine(this.textBox1.Text);
            Console.WriteLine(this.textBox2.Text);

            //TODO load user from database
            LocalStore.currentUser = new TicketManager.User();
            LocalStore.currentUser.Username = this.textBox1.Text;
            LocalStore.currentUser.Password = this.textBox2.Text;
            LocalStore.currentUser.Role = Role.Admin;

            

            FormStorer.Add("Dashboard", new Dashboard());
            FormStorer.Get("Login").Visible = false;
            ((Dashboard)FormStorer.Get("Dashboard")).SetCurrentUser();                  
            FormStorer.Get("Dashboard").Visible = true;
        }
    }
}
