﻿using System;
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
            }
            else
            {
                tail.next = p;
                //tail = p;      // bug2: first p.previous = tail and then tail = p
                //p.previous = tail;
                p.previous = tail;
                tail = p;
            }
        } // end of addToTail


        /*-------------------------------------------------
         * Return null if the string does not exist.
         * ----------------------------------------------*/
        public DLLNode search(int num)
        {
            DLLNode p = head;
            while (p != null)
            {
                //p = p.next;  // bug3: if (p.num == num) break first and then if (p.num == num) break;
                //if (p.num == num) break;
                if (p.num == num) break;
                p = p.next;
            }
            return (p);
        } // end of search (return pointer to the node);



        public int total()
        {
            DLLNode p = head;
            int tot = 0;
            while (p != null)
            {
                //tot += p.num; // bug4: p = p.next.next should be p = p.next
                //p = p.next.next;
                tot += p.num;
                p = p.next;
            }
            return (tot);
        } // end of total


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


        public void removeNode(DLLNode p)
        { // removing the node p.

            // bug5: need to look for the position of p in the list first
            // ==========================================================
            DLLNode searchP = this.head;
            while (searchP != null)
            {
                if (searchP == p) break;
                searchP = searchP.next;
            }
            if (searchP == null) return;
            // ==========================================================

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



        public void removeHead()
        {
            // bug6: only applied for two nodes and more in the list
            //if (this.head == null) return;
            //this.head = this.head.next;
            //this.head.previous = null;
            if (head == null)
                throw new InvalidOperationException("Cannot remove head from an empty list.");
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
            if (this.tail == null) throw new InvalidOperationException("Cannot remove tail from an empty list."); 
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
    } // end of DLList class
}
