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
    public partial class ListTickets : Form
    {
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
            DatabaseAPI.SelectTickets(
                this.comboBox4.Text,
                this.comboBox6.Text,
                this.comboBox7.Text,
                this.comboBox8.Text,
                this.comboBox9.Text);
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
    }
}
