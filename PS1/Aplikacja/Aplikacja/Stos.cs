using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplikacja
{
    class Stos
    {
        private List<int> stack;
        Stos()
        {
            stack = new List<int>();
        }
        public void push(int add)
        {
            stack.Add(add);
        }
        public int top()
        {
            return stack[stack.Count-1];
        }
        public int pop()
        {
            int help = stack[stack.Count-1];
            stack.RemoveAt(stack.Count-1);
            return help;
        }
        public Boolean empty()
        {
            if(stack.Count==0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}