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
            Dictionary<ComboBox, Type> cbmapping = new Dictionary<ComboBox, Type>
            {
                { this.comboBox1, typeof(Department) },
                { this.comboBox5, typeof(Category) },
                { this.comboBox3, typeof(Priority) },                
            };

            foreach (KeyValuePair<ComboBox, Type> entry in cbmapping)
            {
                foreach (string item in Enum.GetNames(entry.Value))
                    entry.Key.Items.Add(item);
            }

            foreach (User user in LocalStore.users)
            {
                this.comboBox2.Items.Add(user.Username);
            }
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
                Date = DateTime.Now,
                State = State.Assigned,
                Description = this.richTextBox1.Text
            };

            Console.Write("Created ticket:\n" + ticket);
            DatabaseAPI.AddTicket(ticket);

            this.textBox1.Text = "";
            this.comboBox1.Text = "";
            this.comboBox2.Text = "";
            this.comboBox3.Text = "";
            this.comboBox5.Text = "";
            this.richTextBox1.Text = "";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.comboBox2.Items.Clear();
            foreach (User user in LocalStore.users)
            {
                if (user.Department == (Department)Enum.Parse(typeof(Department), this.comboBox1.Text))
                this.comboBox2.Items.Add(user.Username);
            }
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
