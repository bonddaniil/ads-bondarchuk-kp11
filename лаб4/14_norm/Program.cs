using System;

namespace _14_norm
{
    class Program
    {
        static void Main(string[] args)
        {
            DLList dl = new DLList();
            dl.AddLast(11);
            dl.Print();
            dl.AddLast(12);
            dl.Print();
            dl.AddLast(15);
            dl.AddLast(7);
            dl.AddLast(9);
            dl.Print();
            dl.AddAfterTheSmallest(66);
            dl.Print();
            //dl.Print();
            //dl.DeleteAtPosition(3);
            //dl.Print();
            //dl.DeleteLast();
            //dl.Print();
            //dl.Print();
            //dl.AddAtPosition(66, 5);
           //dl.Print();
            //dl.DeleteFirst();
            //dl.Print();
            //dl.DeleteLast();
            //dl.Print();
            //dl.DeleteFirst();
            //dl.DeleteAtPosition(2);
            //dl.Print();
        }
    }
}
