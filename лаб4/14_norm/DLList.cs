using System;
using System.Collections.Generic;
using System.Text;

namespace _14_norm
{
    class DLList
    {
        public DLNode tail;
        public void AddFirst(int data)
        {
            if (tail == null)
            {
                tail = new DLNode(data);
                tail.next = tail;
                tail.prev = tail;
            }
            else
            {
                DLNode node = new DLNode(data);
                tail.next.prev = node;
                node.next = tail.next;
                tail.next = node;
                node.prev = tail;
            }
        }
        public void AddLast(int data)
        {
            if (tail == null)
            {
                tail = new DLNode(data);
                tail.next = tail;
                tail.prev = tail;
            }
            else
            {
                DLNode node = new DLNode(data);
                node.next = tail.next;
                node.prev = tail;
                tail.next.prev = node;
                tail.next = node;
                tail = node;
            }
        }
        public void AddAtPosition(int data, int pos)
        {
            DLNode node = new DLNode(data);
            DLNode current = tail.next;

            int counter = 1;
            while (current.next != tail.next)
            {
                current = current.next;
                counter++;
            }
            if (pos > counter)
            {
                AddFirst(data);
            }
            else if (pos == counter) AddLast(data);
            else
            {
                counter = 1;
                current = tail.next;
                while (counter != pos)
                {
                    current = current.next;
                    counter++;
                }
                node.prev = current.prev;
                node.next = current;
                current.prev.next = node;
                current.prev = node;
            }
            
        }
        public void DeleteFirst()
        {
            if(tail.next == tail && tail.prev == tail)
            {
                tail.next = tail;
                tail.prev = tail;
            }
            else
            {
                tail.next.next.prev = tail;
                tail.next = tail.next.next;
            }
            
        }
        public void DeleteLast()
        {
            if (tail.next == tail && tail.prev == tail)
            {
                tail.next = tail;
                tail.prev = tail;
            }
            else
            {
                tail.prev.next = tail.next;
                tail.next.prev = tail.prev;
                tail = tail.prev;
            }
        }
        public void DeleteAtPosition(int pos)
        {
            DLNode current = tail.next;
            int counter = 1;
            while (current.next != tail.next)
            {
                current = current.next;
                counter++;
            }
            if (pos > counter)
            {
                Console.WriteLine("Incorrect position!");
            }
            if (pos == 1)
            {
                DeleteFirst();
            }
            else if(pos == counter)
            {
                DeleteLast();
            }
            else
            {
                int count = 1;
                current = tail.next;
                while (count != pos)
                {
                    current = current.next;
                    count++;
                }
                current.prev.next = current.next;
                current.next.prev = current.prev;
            }
            
        }
        public void AddAfterTheSmallest(int data)
        {
            DLNode current = tail.next;
            int counter = 1;
            while (current.next != tail.next)
            {
                current = current.next;
                counter++;
            }
            //Console.WriteLine(counter);
            int half = counter / 2;
            counter = 1;
            current = tail.next;
            int min = 99999;
            int buf = 0;
            int index = 0;
            while (current.next != tail.next)
            {
                buf = current.data;
                if(counter > half)
                {
                    if (buf <= min)
                    {
                        min = buf;
                        index = counter;
                        buf = 0;
                    }
                }
                current = current.next;
                counter++;
            }

            AddAtPosition(data, index+1);

        }
        public void Print()
        {
            if (tail == null)
            {
                Console.WriteLine("Empty");
            }
            else
            {
                DLNode current = tail.next;
                int counter = 1;
                while (current.next != tail.next)
                {
                    Console.WriteLine($"{counter}-{current.data}");
                    current = current.next;
                    counter++;
                }
                Console.WriteLine($"{counter}-{current.data}");
                Console.WriteLine(new string('-',50));
            }
        }
    }
}
