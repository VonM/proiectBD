using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace TicketManager
{
    public partial class UserPanel : Form
    {
        public UserPanel()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormStorer.Pop();
            FormStorer.Peek().Visible = true;
            this.Visible = false;           
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
           
           
        }

        private void AddUser_Load(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
           
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
            

        }

        private void tableLayoutPanel1_PaintCell(object sender, TableLayoutCellPaintEventArgs e)
        {
           
        }

        private void label3_Click_1(object sender, EventArgs e)
        {

        }

        private void ColorRow(int rowIndex, Color color)
        {
            for (int i = 0; i < tableLayoutPanel1.ColumnCount; i++)
            {
                tableLayoutPanel1.GetControlFromPosition(i, rowIndex).BackColor = color;
            }

        }

        private void DeleteRowEvent(object sender, EventArgs e, int rowIndex, CheckState state)
        {
            if (state == CheckState.Checked)
            {
                Console.WriteLine("Deleting row " + rowIndex + ".");
                ColorRow(rowIndex, Color.Red);               

            } else
            {
                Console.WriteLine("Restoring row " + rowIndex + ".");
                ColorRow(rowIndex, Color.White);
            }           

        }

        private void AddUserToTable(User user, TableLayoutPanel table)
        {
            table.RowCount += 1;
            table.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            table.Size = new System.Drawing.Size(table.Size.Width, table.Size.Height + 30);

            Console.WriteLine("Now table has " + table.RowCount + " rows.");

            //Move last row downward                  
            for (int i = 0; i < table.ColumnCount; i++)
            {
                Control control = table.GetControlFromPosition(i, table.RowCount - 2);
                if (control != null)
                {
                    table.Controls.Remove(control);
                    table.Controls.Add(control, i, table.RowCount - 1);
                }
            }

            Label rowNo = new Label { Text = (table.RowCount - 2).ToString() };
            TextBox username = new TextBox() { Text = user.Username };            
            TextBox password = new TextBox() { Text = user.Password };
            RoleComboBox role = new RoleComboBox() { Text = user.Role.ToString() };
            CheckBox removeUser = new CheckBox() { CheckState = CheckState.Unchecked };

            int currentRow = table.RowCount - 2;
            removeUser.Click += (sender, e) => DeleteRowEvent(sender, e, currentRow, removeUser.CheckState);

            table.Controls.Add(rowNo, 0, table.RowCount - 2);
            table.Controls.Add(username, 1, table.RowCount - 2);
            table.Controls.Add(password, 2, table.RowCount - 2);
            table.Controls.Add(role, 3, table.RowCount - 2);
            table.Controls.Add(removeUser, 4, table.RowCount - 2);            
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            User user = new TicketManager.User();
            user.Username = this.textBox1.Text;
            user.Password = this.textBox2.Text;
            try
            {
                user.Role = (Role)Enum.Parse(typeof(Role), this.comboBox1.Text);
                Console.Write("Adding user:\n" + user);
                AddUserToTable(user, this.tableLayoutPanel1);
            } catch (Exception except)
            {
                Console.Write(except.StackTrace);
            }            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            // TODO send table to database
            // clear UI table
        }
    }
}
