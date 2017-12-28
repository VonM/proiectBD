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
    public partial class TicketPanel : Form
    {
        public TicketPanel()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormStorer.Pop();
            FormStorer.Peek().Visible = true;
            this.Visible = false;            
        }
    }
}
