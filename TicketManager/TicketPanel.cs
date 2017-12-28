﻿using System;
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
    public partial class TicketPanel : Form
    {
        public TicketPanel()
        {
            InitializeComponent();            
            foreach (string item in Enum.GetNames(typeof(Category)))
                this.comboBox5.Items.Add(item);
            foreach (string item in Enum.GetNames(typeof(Department)))
                this.comboBox1.Items.Add(item);
            foreach (string item in Enum.GetNames(typeof(Priority)))
                this.comboBox3.Items.Add(item);    
            foreach (User user in LocalStore.users)
                this.comboBox2.Items.Add(user.Username);
            foreach (string item in Enum.GetNames(typeof(Department)))
                this.comboBox4.Items.Add(item);
            foreach (string item in Enum.GetNames(typeof(Category)))
                this.comboBox6.Items.Add(item);
            foreach (string item in Enum.GetNames(typeof(Priority)))
                this.comboBox7.Items.Add(item);
            foreach (string item in Enum.GetNames(typeof(State)))
                this.comboBox8.Items.Add(item);
            foreach (string item in Enum.GetNames(typeof(SortCategory)))
                this.comboBox9.Items.Add(item);
            foreach (string item in Enum.GetNames(typeof(ExportFormat)))
                this.comboBox10.Items.Add(item);
            
            foreach (Ticket ticket in LocalStore.tickets) {
                this.richTextBox2.Text += ticket;
            }
        }

        
        private void button1_Click(object sender, EventArgs e)
        {
            FormStorer.Pop();
            FormStorer.Peek().Visible = true;
            this.Visible = false;            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

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

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Ticket ticket =  new TicketManager.Ticket()
            {
                Name = this.textBox1.Text,
                Department = (Department)Enum.Parse(typeof(Department), this.comboBox1.Text),
                Category = (Category)Enum.Parse(typeof(Category), this.comboBox5.Text),
                Priority = (Priority)Enum.Parse(typeof(Priority), this.comboBox3.Text),
                ToUser = this.comboBox2.Text,
                FromUser = LocalStore.currentUser.Username,
                Description = this.richTextBox1.Text
            };

            Console.Write("Created ticket:\n" + ticket);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // TODO list tickets
        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
