using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketManager
{
    class User
    {
        private string username_;
        private string password_;
        private Role role_;
        private Department department_;

        public Role Role {
            get { return role_; }
            set { role_ = value; }            
        }

        public Department Department
        {
            get { return department_; }
            set { department_ = value; }
        }

        public string Username
        {
            get { return username_; }
            set { username_ = value; }
        }

        public string Password
        {
            get { return password_; }
            set { password_ = value; }
        }

        public override string ToString()
        {
            return "username: " + username_ + "\n" +
                   "password: " + password_ + "\n" +
                   "role: " + role_ + "\n";                  
        }
    }
}
