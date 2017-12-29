using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using iTextSharp.text.pdf;
using iTextSharp.text;

namespace TicketManager
{
    public partial class TicketsPanel : Form
    {
        private ArrayList filteredTickets_;
        
        public TicketsPanel()
        {
            InitializeComponent();
            Dictionary<ComboBox, Type> cbmapping = new Dictionary<ComboBox, Type>
            {
                { this.comboBox4, typeof(Priority) },
                { this.comboBox6, typeof(Department) },
                { this.comboBox7, typeof(Category) },
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

        public void HandlePlayerRole()
        {
            ClearTable(this.tableLayoutPanel1);
            if (LocalStore.currentUser.Role != Role.Admin && LocalStore.currentUser.Role != Role.Ticket_Editor)
            {
                this.button4.Enabled = false;
            } else
            {
                this.button4.Enabled = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string priority;
            if (this.comboBox4.Text == "")
                priority = "";
            else
            {
                priority = ((int)(Priority)Enum.Parse(typeof(Priority), this.comboBox4.Text)).ToString();
            }
            if (LocalStore.currentUser.Role == Role.Admin)
            {
                filteredTickets_ = DatabaseAPI.SelectTickets(
                this.comboBox6.Text,
                this.comboBox7.Text,
                priority,
                this.comboBox8.Text,
                this.comboBox9.Text);
            } 
            else if (LocalStore.currentUser.Role == Role.Ticket_Editor)
            {
                filteredTickets_ = DatabaseAPI.SelectTicketsToUser(
                this.comboBox6.Text,
                this.comboBox7.Text,
                priority,
                this.comboBox8.Text,
                this.comboBox9.Text,
                LocalStore.currentUser.Username);
            }
            else if (LocalStore.currentUser.Role == Role.Employee)
            {
                filteredTickets_ = DatabaseAPI.SelectTicketsFromUser(
                this.comboBox6.Text,
                this.comboBox7.Text,
                priority,
                this.comboBox8.Text,
                this.comboBox9.Text,
                LocalStore.currentUser.Username);
            }            

            ClearTable(tableLayoutPanel1);
            foreach (Ticket t in filteredTickets_)
            {
                AddTicketToTable(t, tableLayoutPanel1);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            FormStorer.Pop();
            FormStorer.Peek().Visible = true;
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

        private void ClearTable(TableLayoutPanel table)
        {
            for (int i = 1; i < table.RowCount; i++)
            {
                for (int j = 0; j < table.ColumnCount; j++)
                {
                    Control control = table.GetControlFromPosition(j, i);
                    if (control != null)
                    {
                        table.Controls.Remove(control);
                    }
                }
            }

            table.RowCount = 1;
        }

        private static void AddTicketToTable(Ticket t, TableLayoutPanel table)
        {
            table.RowCount += 1;
            table.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            table.Size = new System.Drawing.Size(table.Size.Width, table.Size.Height + 50);

            ArrayList rowControls = new ArrayList
            {
                new Label() { Text = (table.RowCount - 1).ToString() },
                new Label() { Text = t.Name },
                new Label() { Text = t.FromUser },
                new Label() { Text = t.ToUser },
                new Label() { Text = t.Priority.ToString() },
                new Label() { Text = t.Department.ToString() },
                new Label() { Text = t.Category.ToString() },
                new Label() { Text = t.Date.ToString() },
                new ComboBox() { Text = t.State.ToString() },
                new RichTextBox() { Text = t.Description, Width = (int)table.ColumnStyles[table.ColumnCount - 1].Width }
            };
            foreach (string item in Enum.GetNames(typeof(State)))
                ((ComboBox)rowControls[8]).Items.Add(item);

            // Handle player role
            if (LocalStore.currentUser.Role != Role.Admin && LocalStore.currentUser.Role != Role.Ticket_Editor)
            {
                ((ComboBox)rowControls[8]).Enabled = false;

            }
            else
            {
                ((ComboBox)rowControls[8]).Enabled = true;
            }

            // Add controls to table row
            for (int i = 0; i < rowControls.Count; i++)
            {
                table.Controls.Add((Control)rowControls[i], i, table.RowCount - 1);
            }           
        }

        

        private void TicketsPanel_Load(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            // gather tickets from table
            ArrayList gatheredTickets = new ArrayList();
            for (int i = 1; i <  tableLayoutPanel1.RowCount; i++)
            {
                Ticket t = new Ticket();
                t.Name = tableLayoutPanel1.GetControlFromPosition(1, i).Text;
                t.FromUser = tableLayoutPanel1.GetControlFromPosition(2, i).Text;
                t.ToUser = tableLayoutPanel1.GetControlFromPosition(3, i).Text;
                t.Priority = (Priority)Enum.Parse(typeof(Priority), tableLayoutPanel1.GetControlFromPosition(4, i).Text);
                t.Department = (Department)Enum.Parse(typeof(Department), tableLayoutPanel1.GetControlFromPosition(5, i).Text);
                t.Category = (Category)Enum.Parse(typeof(Category), tableLayoutPanel1.GetControlFromPosition(6, i).Text);
                t.Date = DatabaseAPI.ParseDateFromDB(tableLayoutPanel1.GetControlFromPosition(7, i).Text);
                t.State = (State)Enum.Parse(typeof(State), tableLayoutPanel1.GetControlFromPosition(8, i).Text);
                t.Description = tableLayoutPanel1.GetControlFromPosition(9, i).Text;
                                
                gatheredTickets.Add(t);
            }

            // update database with tickets  
            DatabaseAPI.ReplaceTickets(filteredTickets_, gatheredTickets);         
        }

        private void WriteToPdf(string filename, string text)
        {
            FileStream fs = new FileStream(filename, FileMode.Create, FileAccess.Write, FileShare.None);
            Document doc = new Document();
            PdfWriter writer = PdfWriter.GetInstance(doc, fs);
            doc.Open();
            doc.Add(new Paragraph(text));
            doc.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (this.comboBox10.Text == ExportFormat.CSV.ToString())
            {
                string csv = "Name,FromUser,ToUser,Priority,Department,Category,Date,State,Description\n";
                foreach (Ticket t in filteredTickets_)
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
                foreach (Ticket t in filteredTickets_)
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
            else if (this.comboBox10.Text == ExportFormat.PDF.ToString())
            {
                string text = "";
                foreach (Ticket t in filteredTickets_)
                {
                    text += t + "\n";
                }
                WriteToPdf(textBox1.Text + ".pdf", text);
                this.textBox1.Text = "";
                this.comboBox10.Text = "";
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
    
}
