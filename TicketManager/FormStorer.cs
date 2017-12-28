using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Windows.Forms;

namespace TicketManager
{
    class FormStorer
    {
        private static Dictionary<string, Form> formDict = new Dictionary<string, Form>();

        private static Stack<Form> formStack = new Stack<Form>();

        public static void Add(string name, Form form)
        {
            if (!formDict.ContainsKey(name))
            {
                formDict.Add(name, form);                
            }
            formStack.Push(formDict[name]);
        }

        public static Form Pop()
        {
            return formStack.Pop();
        }

        public static Form Peek()
        {
            return formStack.Peek();
        }

        public static Form Get(string name)
        {
            return formDict[name];
        }
        
    }
}
