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
    public partial class CreateTicket : Form
    {
        public CreateTicket()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            FormStorer.Pop();
            FormStorer.Peek().Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Ticket ticket = new TicketManager.Ticket()
            {
                Name = this.textBox1.Text,
                Department = (Department)Enum.Parse(typeof(Department), this.comboBox1.Text),
                ToUser = this.comboBox2.Text,
                Priority = (Priority)Enum.Parse(typeof(Priority), this.comboBox3.Text),
                Category = (Category)Enum.Parse(typeof(Category), this.comboBox5.Text),
                FromUser = LocalStore.currentUser.Username,
                Description = this.richTextBox1.Text
            };

            Console.Write("Created ticket:\n" + ticket);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
