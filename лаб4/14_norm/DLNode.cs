using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14_norm
{
    class DLNode
    {
        public int data;
        public DLNode prev;
        public DLNode next;
        public DLNode(int data)
        {
            this.data = data;
        }
        public DLNode(int data, DLNode prev, DLNode next)
        {
            this.data = data;
            this.prev = prev;
            this.next = next;
        }
    }
}
