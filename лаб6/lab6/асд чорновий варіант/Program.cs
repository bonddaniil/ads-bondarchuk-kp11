using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace асд_чорновий_варіант
{
    internal class Program
    {
        static string[] arr;
        static int head;
        static int tail;
        static int prevtail;
        static void Main(string[] args)
        {
            Console.WriteLine("Enter !Demo to show demontration example");
            Console.WriteLine("Enter !OwnArray to create own array");
            Console.WriteLine("Enter out to delete head of  own array");
            Console.WriteLine("Enter quit to finish the program");
            while (true)
            {
                switch (Console.ReadLine())
                {
                    case "!Demo":
                        Demo();
                        break;
                    case "!OwnArray":
                        CreateNewQue();
                        WriteArray();
                        while (true)
                        {
                            AddNew();
                            WriteArray();
                        }
                }
                if (Console.ReadLine() == "quit") break;
            }
            //Demo();
            //Console.ReadLine();
            /*CreateNewQue();
            WriteArray();
            while (true)
            {
                AddNew();
                WriteArray();
            }*/
        }
        public static void CreateNewQue()
        {
            Console.Write("Input the length of Queue: ");
            int QueLength = int.Parse(Console.ReadLine());
            arr = new string[QueLength];
            head = QueLength / 2+1;
            Console.Write("Input the first line: ");
            string NewString = Console.ReadLine();
            arr[head] = NewString;
            tail = head+1;
        }
        public static void AddNew()
        {
            if (head == tail)
            {
                tail = prevtail;
                ExpancionOfTheArray();
            }
            else
            {
                Console.Write("Input new line: ");
                string NewString = Console.ReadLine();
                if (NewString == "out") DeleteHead();
                else
                {
                    arr[tail] = NewString;
                    prevtail = tail;
                    tail = (tail + 1) % arr.Length;
                }
            }
        }
        public static void ExpancionOfTheArray()
        {
            Console.WriteLine("Queue is owerflowed!");
            int NewLength = arr.Length * 2;
            string[] NewArr = new string[NewLength];
            if (head == 0)
            {
                for (int i = 0; i <arr.Length; i++)
                {
                    NewArr[i] = arr[i];
                }
            }
            else
            {
                for (int i = 0; i <= tail; i++)
                {
                    NewArr[i] = arr[i];
                }
                int counter = head;
                head = head + arr.Length;
                for (int i = head; i < NewArr.Length; i++)
                {
                    NewArr[i] = arr[counter];
                    counter++;
                }
            }
            arr = NewArr;
        }
        public static void WriteArray()
        {
            Console.WriteLine();
            foreach (var item in arr)
            {
                if(item != null) Console.WriteLine(item);
                else Console.WriteLine("empty");
            }
            Console.WriteLine();
        }
        public static void DeleteHead()
        {
            arr[head] = null;
            head = (head + 1) % arr.Length;
        }
        public static void Demo()
        {
            CreateNewQueDemonstration(6);
            WriteArray();
            AddNewDemonstration("Lovin' free");
            WriteArray();
            AddNewDemonstration("Season ticket on a one way ride");
            WriteArray();
            AddNewDemonstration("Askin' nothin'");
            WriteArray();
            AddNewDemonstration("Leave me be");
            WriteArray();
            AddNewDemonstration("Takin' everythin' in my stride");
            WriteArray();
            AddNewDemonstration("Don't need reason");
            WriteArray();
            AddNewDemonstration("Don't need rhyme");
            WriteArray();
            AddNewDemonstration("Ain't nothin' that I'd rather do");
            WriteArray();
            AddNewDemonstration("Goin' down Party time");
            WriteArray();
            AddNewDemonstration("Goin' down Party time");
            WriteArray();
            AddNewDemonstration("My friends are gonna be there too");
            WriteArray();
            AddNewDemonstration("out");
            WriteArray();
            AddNewDemonstration("out");
        }
        public static void AddNewDemonstration(string NewString)
        {
            if (head == tail)
            {
                tail = prevtail;
                ExpancionOfTheArray();
            }
            else
            {
                if (NewString == "out") DeleteHead();
                else
                {
                    arr[tail] = NewString;
                    prevtail = tail;
                    tail = (tail + 1) % arr.Length;
                }
            }
        }
        public static void CreateNewQueDemonstration(int QueLength)
        {
            arr = new string[QueLength];
            head = QueLength / 2 + 1;
            string NewString = "Living easy";
            arr[head] = NewString;
            tail = head + 1;
        }
    }
}
