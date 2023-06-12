using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoublyLinkedListWithErrors
{
   public class DLLNode
    {
        public int num;   // field of the node
        public DLLNode next; // pointer to the next node
        public DLLNode previous; // pointer to the previous node
        public DLLNode (int num)
        {
            this.num = num;
            next = null;
            previous = null;
        } // end of constructor

        public Boolean isPrime(int n)//你给我一个数字我需要判断是不是质数，
        {
            Boolean b = true;

            if (n < 2)
            {
                return (false);
            }
            else
            {
                for (int i = 2; i <= Math.Sqrt(n); i++)//bug需要加了一个<=然后method3可以运行,3不是质数所以进入不了else,25是质数可以进入if,25,49,都可以进入if
                {
                    if ((n % i) == 0)
                    {
                        b = false;
                        break;
                    }
                }
            }
            return (b);
        } // end of isPrime

    } // end of class DLLNode
}
