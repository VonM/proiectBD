using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicketManager
{
    class RoleComboBox : ComboBox
    {
        public RoleComboBox() : base()
        {
            string[] items = Enum.GetNames(typeof(Role));
            foreach (string item in items) 
            {
                this.Items.Add(item);
            }
        }
    }
}
