using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketManager
{
    class Ticket
    {
        private string name_;
        private string fromUser_;      
        private string toUser_;
        private Priority priority_;
        private Department department_;
        private Category category_;
        private string description_;
        private string date_ = "";
        private State state_;

        public string Name
        {
            get { return name_; }
            set { name_ = value; }
        }

        public string ToUser
        {
            get { return toUser_; }
            set { toUser_ = value; }
        }

        public string FromUser
        {
            get { return fromUser_; }
            set { fromUser_ = value; }
        }

        public Priority Priority
        {
            get { return priority_; }
            set { priority_ = value; }
        }

        public Department Department
        {
            get { return department_; }
            set { department_ = value; }
        }

        public Category Category
        {
            get { return category_; }
            set { category_ = value; }
        }

        public State State
        {
            get { return state_; }
            set { state_ = value; }
        }

        public string Description
        {
            get { return description_; }
            set { description_ = value; }
        }

        public string Date
        {
            get { return date_; }
            set { date_ = value; }
        }

        public override string ToString()
        {
            return "Name: " + name_ + "\n" +
                   "From: " + fromUser_ + "\n" +
                   "To: " + toUser_ + "\n" +
                   "Priority: " + priority_ + "\n" +
                   "Department: " + department_ + "\n" +
                   "Category: " + category_ + "\n" +
                   "Date: " + date_ + "\n" +
                   "State: " + state_ + "\n" +
                   "Description: " + description_ + "\n";
        }
    }
}
