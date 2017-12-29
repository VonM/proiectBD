using System;
using System.Collections;
using System.IO;
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
    public partial class ListTickets : Form
    {
        private ArrayList listedTickets_;

        public ListTickets()
        {
            InitializeComponent();
            Dictionary<ComboBox, Type> cbmapping = new Dictionary<ComboBox, Type>
            {
                { this.comboBox4, typeof(Department) },
                { this.comboBox6, typeof(Category) },
                { this.comboBox7, typeof(Priority) },
                { this.comboBox8, typeof(State) },
                { this.comboBox9, typeof(SortCategory) },
                { this.comboBox10, typeof(ExportFormat) }
            };

            foreach (KeyValuePair<ComboBox, Type> entry in cbmapping)
            {
                foreach (string item in Enum.GetNames(entry.Value))
                    entry.Key.Items.Add(item);
            }            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            FormStorer.Pop();
            FormStorer.Peek().Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string priority;
            if (this.comboBox7.Text == "")
                priority = "";
            else
            {
                priority = ((int)(Priority)Enum.Parse(typeof(Priority), this.comboBox7.Text)).ToString();
            }

            listedTickets_ = DatabaseAPI.SelectTickets(
                this.comboBox4.Text,
                this.comboBox6.Text,
                priority,
                this.comboBox8.Text,
                this.comboBox9.Text);
            this.richTextBox3.Text = "";
            foreach (Ticket t in listedTickets_)
            {
                Console.Write(t);
                this.richTextBox3.Text += t + "\n";                
            }
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox8_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox9_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox10_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void richTextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {   
            if (this.comboBox10.Text == ExportFormat.CSV.ToString())
            {
                string csv = "Name,FromUser,ToUser,Priority,Department,Category,Date,State,Description\n";
                foreach (Ticket t in listedTickets_)
                {
                    csv += t.ToCSV();
                }
                if (textBox1.Text != "")
                {
                    File.WriteAllText(textBox1.Text + ".csv", csv);
                    textBox1.Text = "";
                    this.comboBox10.Text = "";
                }
            }
            else if (this.comboBox10.Text == ExportFormat.Excel.ToString())
            {
                string csv = "Name,FromUser,ToUser,Priority,Department,Category,Date,State,Description\n";
                foreach (Ticket t in listedTickets_)
                {
                    csv += t.ToCSV();
                }
                if (textBox1.Text != "")
                {
                    File.WriteAllText(textBox1.Text + ".xls", csv);
                    textBox1.Text = "";
                    this.comboBox10.Text = "";
                }
            }
        }
    }
}
