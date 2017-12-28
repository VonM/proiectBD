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
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();                        
        }

        public void SetCurrentUser()
        {
            this.label2.Text = LocalStore.currentUser.Username;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {            
            FormStorer.Pop().Visible = false;
            FormStorer.Peek().Visible = true;            
        }

        private void button2_Click(object sender, EventArgs e)
        {            
            LocalStore.LoadUsersFromDB();

            this.Visible = false;
            FormStorer.Add("UserPanel", new UserPanel());

            ((UserPanel)FormStorer.Get("UserPanel")).LoadUsersInForm();

            FormStorer.Get("UserPanel").Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {            
            LocalStore.LoadUsersFromDB();

            // LOAD ticket history for current user
            LocalStore.LoadTicketsFromDB(LocalStore.currentUser.Username);

            this.Visible = false;
            FormStorer.Add("TicketPanel", new TicketPanel());
            FormStorer.Get("TicketPanel").Visible = true;


        }
    }
}
