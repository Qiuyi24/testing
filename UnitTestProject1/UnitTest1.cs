using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using DoublyLinkedListWithErrors;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
         //因为node里面有3条方式，所以我就测试3条， cover每一种可能性。if else if
         //测dllnode里从21行开始的3中可能性
        [TestMethod]
        public void Test11_isPrime_1()
        {
            DLLNode p = new DLLNode(6);
            Assert.AreEqual(p.isPrime(1), false);//if (n < 2)因为要测dllnode小于2
        }

        [TestMethod]
        public void Test2_isPrime_3()
        {
            DLLNode p = new DLLNode(15);
            Assert.AreEqual(p.isPrime(3), true);
        }

        [TestMethod]
        public void Test3_isPrime_12()
        {
            DLLNode p = new DLLNode(110);
            Assert.AreEqual(p.isPrime(12), false);
        }
        //测的是构造，测node的代码 
        [TestMethod]
        public void Test4_DLLNode_constructor()
        {
            DLLNode p = new DLLNode(0);
            Assert.AreEqual(p.num, 0);//在node里面第14行，先设定p的数字为0，p.next和p.previous还没有连接其他前后node两个数字,所以是null
            Assert.AreEqual(p.next, null);
            Assert.AreEqual(p.previous, null);
        }

        [TestMethod]
        public void Test5_addToHead_empty()//在CFG中，（0，1，2，4）的顺序
        {
            //查看在dlllist中的if部分
            DLLNode p = new DLLNode(-1);
            DLList ddl = new DLList();
            Assert.AreEqual(ddl.head, null);
            Assert.AreEqual(ddl.tail, null);//先没有加p他肯定是空的
            ddl.addToHead(p);//加上了p
            Assert.AreNotEqual(ddl.head, null);
            Assert.AreNotEqual(ddl.tail, null);
            Assert.AreEqual(ddl.head, p);//这里的值就不是空的
            Assert.AreEqual(ddl.tail, p);
        }

        [TestMethod]
        public void Test6_addToHead_non_empty()//在CFG中，（0，1，3，4）的顺序
        {
            //查看在dlllist中的else部分
            DLLNode p1 = new DLLNode(12); 
            DLList ddl = new DLList();
            ddl.addToHead(p1);            
            Assert.AreEqual(ddl.tail, p1);               
            Assert.AreEqual(p1.next, null);
           
        }
        [TestMethod]
        public void Test7_search_contain()
        {
            //搜链表中已经包含存在的数字
            DLLNode p1 = new DLLNode(34);
            DLLNode p2 = new DLLNode(2);
            DLLNode p3 = new DLLNode(-13);
            DLList ddl = new DLList();
            ddl.addToHead(p1);
            ddl.addToHead(p2);
            ddl.addToHead(p3);//往前加head所以顺序是4.3.2.1.
            DLLNode p = ddl.search(2);//在表格中
            Assert.AreEqual(p.num,2);
            p = ddl.search(34);
            Assert.AreEqual(p.num,34);
            p = ddl.search(-13);
            Assert.AreEqual(p.num,-13);
        }

        [TestMethod]
        public void Test8_search_not_contain()
        {
            //搜链表中不包含存在的数字
            DLLNode p1 = new DLLNode(34);
            DLLNode p2 = new DLLNode(2);
            DLLNode p3 = new DLLNode(-13);
            DLList ddl = new DLList();
            ddl.addToHead(p1);
            ddl.addToHead(p2);
            ddl.addToHead(p3);
            DLLNode p = ddl.search(1);
            Assert.AreEqual(p, null);//数字1并不在我的链表当中
        }
        [TestMethod]
        public void Test9_total()
        {
            DLLNode p1 = new DLLNode(1);
            DLLNode p2 = new DLLNode(2);
            DLLNode p3 = new DLLNode(3);
            DLList ddl = new DLList();
            ddl.addToHead(p1);
            ddl.addToHead(p2);
            ddl.addToHead(p3);
            int total = ddl.total();//输出一个总和1+2+3判断p是否等于下行的total
            Assert.AreEqual(total, (p1.num) + (p2.num) + (p3.num));
        }

        [TestMethod]
        public void Test10_removeHead_empty_list()
        {
            DLList ddl = new DLList();
            ddl.removeHead();
            Assert.AreEqual(ddl.head, null);
            Assert.AreEqual(ddl.tail, null);
        }//当list是空的没有加node，那remove也会是空的,那头和尾也是空的

        [TestMethod]
        public void Test11_removeHead_one_node_list()
        {
            DLList ddl = new DLList();
            DLLNode p = new DLLNode(3);
            ddl.addToHead(p);
            ddl.removeHead();
            Assert.AreEqual(ddl.head, null);
            Assert.AreEqual(ddl.tail, null);
        }
        //加上一个ddllist,给head加一个p值，如果移除head那头尾还是空的

        [TestMethod]
        public void Test12_removeHead_multiple_node_list()
        {
            DLList ddl = new DLList();
            DLLNode p1 = new DLLNode(34);
            DLLNode p2 = new DLLNode(2);
            DLLNode p3 = new DLLNode(12);

            ddl.addToTail(p1);
            ddl.addToTail(p2);
            ddl.addToTail(p3);
            //加在尾巴上，那顺序是p123
            ddl.removeHead();
            Assert.AreEqual(ddl.head, p2);
            Assert.AreEqual(p2.previous, null);
        }
        //谁是头，那前面就是空的

        //removeNode
        [TestMethod]//移除一个p, 首先p需要在这个list当中
                    //如果这个p不在list当中，那就会显示原本的顺便，就好像之前加的顺序p123
        public void Test13_removeNode_p_not_in_list()
        {
            DLLNode p1 = new DLLNode(1);
            DLLNode p2 = new DLLNode(2);
            DLLNode p3 = new DLLNode(3);

            DLLNode p = new DLLNode(122);

            DLList ddl = new DLList();
            ddl.addToTail(p1);
            ddl.addToTail(p2);
            ddl.addToTail(p3);
            ddl.removeNode(p);

            Assert.AreEqual(p1.next, p2);
            Assert.AreEqual(p2.next, p3);
            Assert.AreEqual(p3.previous, p2);
            Assert.AreEqual(p2.previous, p1);
        }

        //removeNode
        [TestMethod]
        public void Test14_removeNode_p_in_middle()
        {
            DLLNode p1 = new DLLNode(1);
            DLLNode p2 = new DLLNode(2);
            DLLNode p3 = new DLLNode(3);
            DLList ddl = new DLList();
            ddl.addToTail(p1);
            ddl.addToTail(p2);
            ddl.addToTail(p3);
            //
            ddl.removeNode(p2);

            Assert.AreNotEqual(p1.next, p2);
            Assert.AreEqual(p1.next, p3);
            Assert.AreNotEqual(p3.previous, p2);
            Assert.AreEqual(p3.previous, p1);
        }

        //removeNode
        [TestMethod]
        public void Test15_removeNode_p_in_head()
        {
            DLLNode p1 = new DLLNode(1);
            DLLNode p2 = new DLLNode(2);
            DLLNode p3 = new DLLNode(3);
            DLList ddl = new DLList();
            ddl.addToTail(p1);
            ddl.addToTail(p2);
            ddl.addToTail(p3);

            ddl.removeNode(p1);

            Assert.AreNotEqual(p2.previous, p1);
            Assert.AreEqual(p2.previous, null);
            Assert.AreEqual(p2.next, p3);
            Assert.AreEqual(p3.previous, p2);
        }

        //removeNode
        [TestMethod]
        public void Test16_removeNode_p_in_tail()
        {
            DLLNode p1 = new DLLNode(1);
            DLLNode p2 = new DLLNode(2);
            DLLNode p3 = new DLLNode(3);
            DLList ddl = new DLList();
            ddl.addToTail(p1);
            ddl.addToTail(p2);
            ddl.addToTail(p3);

            ddl.removeNode(p3);

            Assert.AreNotEqual(p2.next, p3);
            Assert.AreEqual(p2.next, null);
            Assert.AreEqual(p1.next, p2);
            Assert.AreEqual(p2.previous, p1);
        }
        [TestMethod]
        public void Test17_removeTail_empty_list()
        {
            DLList ddl = new DLList();
            ddl.removeTail();
            Assert.AreEqual(ddl.head, null);
            Assert.AreEqual(ddl.tail, null);
        }
        //删的是尾巴,其他的都是空的

        [TestMethod]
        public void Test18_removeTail_one_node_list()
        {
            DLList ddl = new DLList();
            DLLNode p = new DLLNode(3);
            ddl.addToHead(p);
            ddl.removeTail();
            Assert.AreEqual(ddl.head, null);
            Assert.AreEqual(ddl.tail, null);
        }
        //目前数值只有一个p,把p删除了，那这个list还是空的
        [TestMethod]
        public void Test19_removeTail_multiple_node_list()
        {
            DLList ddl = new DLList();
            DLLNode p1 = new DLLNode(34);
            DLLNode p2 = new DLLNode(2);
            DLLNode p3 = new DLLNode(12);

            ddl.addToTail(p1);
            ddl.addToTail(p2);
            ddl.addToTail(p3);

            ddl.removeTail();
            Assert.AreEqual(ddl.tail, p2);
            Assert.AreEqual(p2.next, null);
        }
        //把最后一个删除，p2后面是空的，p2变成了尾巴
    }
}
  