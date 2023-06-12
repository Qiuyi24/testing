using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoublyLinkedListWithErrors
{
   public class DLList
    {
        public DLLNode head; // pointer to the head of the list
        public DLLNode tail; // pointer to the tail of the list
       public DLList() { head = null;  tail = null; } // constructor
        /*-------------------------------------------------------------------
        * The methods below includes several errors. Your  task is to write
        * unit test to discover these errors. During delivery the tutor may
        * add or remove errors to adjust the scale of the effort required by
        */
        public void addToTail(DLLNode p)
        {

            if (head == null)
            {
                head = p;
                tail = p;
                return;

            }
            else
            {
                tail.next = p;
                tail = p;
                p.previous = tail;
                return;
            }
        } // end of addToTail

        public void addToHead(DLLNode p)
        {
            if (head == null)
            {
                head = p;
                tail = p;
            }
            else
            {
                p.next = this.head;
                this.head.previous = p;
                head = p;
            }
        } // end of addToHead

        public void removeHead()//bug,少了一个e,only applied for two nodes and more in the list
                                //没有考虑只有node的时候
                                //if (this.head == null) return;
                                //this.head = this.head.next;
                                //this.head.previous = null;
        {
            if (head == null)
                return;
            if (head.next == null) // this.head == this.tail
            {

                // list only has one node
                head = tail = null;
            }
            else
            {
                head = head.next;
                head.previous = null;
            }
        } // removeHead

        public void removeTail()
        {
            // bug7: only applied for one node and non-node in the list
            //if (this.tail == null) return;
            //if (this.head == this.tail)
            //{
            //    this.head = null;
            //    this.tail = null;
            //    return;
            //}
            if (this.tail == null) return;
            if (this.head == this.tail)
            {
                this.head = null;
                this.tail = null;
                return;
            }
            else
            {
                tail = tail.previous;
                tail.next = null;
            }

        } // remove tail

        /*-------------------------------------------------
         * Return null if the string does not exist.
         * ----------------------------------------------*/
        public DLLNode search(int num)
        {
            DLLNode p = head;
            while (p != null)
            {
               
                if (p.num == num) break;//如果在链表中找到了这一个数字，那我就跳出这个链表，表示我已经找到了这个数字
                p = p.next;             //bug 测试后发现p 的顺序和if互换一下
            }
            return (p);
        } // end of search (return pionter to the node);在双向链表中寻找有没有这个数字

        public void removeNode(DLLNode p)
        { // removing the node p.

            if (p.next == null)
            {
                this.tail = this.tail.previous;
                this.tail.next = null;
                p.previous = null;
                return;
            }
            if (p.previous == null)
            {
                this.head = this.head.next;
                p.next = null;
                this.head.previous = null;
                return;
            }
            p.next.previous = p.previous;
            p.previous.next = p.next;
            p.next = null;
            p.previous = null;
            return;
        } // end of remove a node

        public int total()
        {
            DLLNode p = head;
            int tot = 0;
            while (p != null)
            {
                //tot += p.num; // bug4: p = p.next.next should be p = p.next
                //p = p.next.next;
                tot += p.num;
                p = p.next;//不可以逐个加，需要按照顺序，不可以跳顺序
            }
            return (tot);
        } // end of total
    } // end of DLList class
}
