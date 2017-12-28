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
            foreach (string item in Enum.GetNames(typeof(Department)))
                this.comboBox2.Items.Add(item);
            foreach (string item in Enum.GetNames(typeof(Role)))
                this.comboBox1.Items.Add(item);
        }

        private void EnableTable(bool state)
        {
            for (int i = 1; i < this.tableLayoutPanel1.RowCount - 1; i++)
            {
                for (int j = 0; j < this.tableLayoutPanel1.ColumnCount; j++)
                {
                    Control control = this.tableLayoutPanel1.GetControlFromPosition(j, i);
                    control.Enabled = state;
                }
            }
        }

        private void HandlePlayerRole()
        {
            Control[] staticUI = {
                this.button3,
                this.textBox1,
                this.textBox2,
                this.comboBox1,
                this.comboBox2,
                this.button2
            };
            if (LocalStore.currentUser.Role != Role.Admin)
            {
                foreach (Control c in staticUI)
                {
                    c.Enabled = false;
                }
                EnableTable(false);
            } else
            {
                foreach (Control c in staticUI)
                {
                    c.Enabled = true;
                }
                EnableTable(true);
            }
                
        }

        public void LoadUsersInForm()
        {
            ClearTable(this.tableLayoutPanel1);
            foreach (User u in LocalStore.users)
            {
                AddUserToTable(u);
            }
            HandlePlayerRole();
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

        private void PopRowFromTable(TableLayoutPanel table)
        {
            // Clear prev last row from table
            for (int i = 0; i < table.ColumnCount; i++)
            {
                Control control = table.GetControlFromPosition(i, table.RowCount - 2);
                if (control != null)
                {
                    table.Controls.Remove(control);
                }
            }

            // Move last row upward
            for (int i = 0; i < table.ColumnCount; i++)
            {
                Control control = table.GetControlFromPosition(i, table.RowCount - 1);
                if (control != null)
                {
                    table.Controls.Remove(control);
                    table.Controls.Add(control, i, table.RowCount - 2);
                }
            }

            table.RowCount -= 1;
        }

        private void ClearTable(TableLayoutPanel table)
        {
            while (table.RowCount > 2)
            {
                PopRowFromTable(table);
            }
        }

        private void AddUserToTable(User user)
        {
            TableLayoutPanel table = this.tableLayoutPanel1;
            table.RowCount += 1;
            table.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            table.Size = new System.Drawing.Size(table.Size.Width, table.Size.Height + 30);            

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
            TextBox username = new TextBox() { Text = user.Username, Width = this.textBox1.Width };            
            TextBox password = new TextBox() { Text = user.Password, Width = this.textBox2.Width };
            ComboBox department = new ComboBox() { Text = user.Department.ToString(), Width = this.comboBox2.Width };
            foreach (string item in Enum.GetNames(typeof(Department)))
                department.Items.Add(item);            
            ComboBox role = new ComboBox() { Text = user.Role.ToString(), Width = this.comboBox1.Width};
            foreach (string item in Enum.GetNames(typeof(Role)))
                role.Items.Add(item);
            CheckBox removeUser = new CheckBox() { CheckState = CheckState.Unchecked };

            int currentRow = table.RowCount - 2;
            removeUser.Click += (sender, e) => DeleteRowEvent(sender, e, currentRow, removeUser.CheckState);

            table.Controls.Add(rowNo, 0, table.RowCount - 2);
            table.Controls.Add(username, 1, table.RowCount - 2);
            table.Controls.Add(password, 2, table.RowCount - 2);
            table.Controls.Add(department, 3, table.RowCount - 2);
            table.Controls.Add(role, 4, table.RowCount - 2);
            table.Controls.Add(removeUser, 5, table.RowCount - 2);            
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            User user = new TicketManager.User();
            user.Username = this.textBox1.Text;
            user.Password = this.textBox2.Text;
            user.Department = (Department)Enum.Parse(typeof(Department), this.comboBox2.Text);
            user.Role = (Role)Enum.Parse(typeof(Role), this.comboBox1.Text);
            Console.Write("Adding user:\n" + user);
            AddUserToTable(user);          
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            // TODO send table to database
            ArrayList gatheredUsers = new ArrayList();
            for (int i = 1; i < this.tableLayoutPanel1.RowCount - 1; i++)
            {
                CheckBox checkBox = (CheckBox)this.tableLayoutPanel1.GetControlFromPosition(this.tableLayoutPanel1.ColumnCount - 1, i);
                if (checkBox.CheckState != CheckState.Checked)
                {
                    User user = new User();
                    user.Username = ((TextBox)this.tableLayoutPanel1.GetControlFromPosition(1, i)).Text;
                    user.Password = ((TextBox)this.tableLayoutPanel1.GetControlFromPosition(2, i)).Text;
                    user.Department = (Department)Enum.Parse(typeof(Department), ((ComboBox)this.tableLayoutPanel1.GetControlFromPosition(3, i)).Text);
                    user.Role = (Role)Enum.Parse(typeof(Role), ((ComboBox)this.tableLayoutPanel1.GetControlFromPosition(4, i)).Text);
                    gatheredUsers.Add(user);
                }               
            }

            LocalStore.UpdateUsers(gatheredUsers);          
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
