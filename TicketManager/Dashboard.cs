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
            this.Visible = false;
            FormStorer.Add("CreateTicket", new CreateTicket());
            FormStorer.Get("CreateTicket").Visible = true;    

  
//            LocalStore.LoadTicketsFromDB(LocalStore.currentUser.Username);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            TicketsPanel next = new TicketsPanel();
            FormStorer.Add("TicketsPanel", next);
            next.HandlePlayerRole();
            next.Visible = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            FormStorer.Add("ListTickets", new ListTickets());
            FormStorer.Get("ListTickets").Visible = true;
        }
    }
}
