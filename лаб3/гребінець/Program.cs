using System;
using static System.Console;

namespace гребінець
{
    class Program
    {
        static Random rnd = new Random();
        static void Main(string[] args)
        {
            int[] arr;
            int[] sortArr;

            //arr = GenerateArray(10);
            arr = new int[] { 1000, 11, 5, 20, 3, 21, -7, 40, 31, -100 };
            PrintArr(arr);
            WriteLine(" ");
            SeparateArrays(arr);
            /*arr = Comb(arr);
            PrintArr(arr);
            sortArr = Comb(arr);
            WriteLine(" ");
            PrintArr(sortArr);
            WriteLine(" ");
            SeparateArrays(arr);*/
        }

        static int[] GenerateArray(int length)
        {
            int[] arr = new int[length];
            for (int i = 0; i < length; i++)
            {
                arr[i] = rnd.Next(-100, 100);
            }
            return arr;
        }
        static void PrintArr(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] % 2 == 0 && arr[i] % arr.Length == 0)
                {
                    BackgroundColor = ConsoleColor.Green;
                    Write(arr[i] + " ");
                }
                else if (arr[i] % 2 == 1 && arr[i] % arr.Length == 1)
                {
                    BackgroundColor = ConsoleColor.Yellow;
                    Write(arr[i] + " ");
                }
                else
                {
                    BackgroundColor = ConsoleColor.Red;
                    Write(arr[i] + " ");
                }
                BackgroundColor = ConsoleColor.Black;
            }
        }
        static int[] Comb(int [] arr)
        {
            bool sorted = false;
            int gap = arr.Length;
            int buf;
            while (gap !=1 || sorted == false)
            {
                sorted = true;
                gap = (int)(gap / 1.3);
                buf = 0;
                if (gap < 1) gap = 1;
                for (int i = 0; i < arr.Length-gap; i++)
                {
                    if(arr[i] < arr[i + gap])
                    {
                        buf = arr[i];
                        arr[i] = arr[i + gap];
                        arr[i + gap] = buf; 
                    }
                }
            }
            return arr;
        }
        static void SeparateArrays(int [] arr)
        {
            int[] pairedUnpaired, unsorted;
            int sortLen =0, unsortLen = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if ((arr[i] % 2 == 0 && arr[i] % arr.Length == 0)|| (arr[i] % 2 == 1 && arr[i] % arr.Length == 1)) sortLen++;
                else unsortLen++;
            }
            pairedUnpaired = new int[sortLen];
            unsorted = new int[unsortLen];
            int countSorted = 0, countUnsorted =0; 
            for (int i = 0; i < arr.Length; i++)
            {
                if ((arr[i] % 2 == 0 && arr[i] % arr.Length == 0) || (arr[i] % 2 == 1 && arr[i] % arr.Length == 1))
                {
                    pairedUnpaired[countSorted] = arr[i];
                    countSorted++;
                }
                else
                {
                    unsorted[countUnsorted] = arr[i];
                    countUnsorted++;
                }
            }
            pairedUnpaired = Comb(pairedUnpaired);
            
            WriteLine(" ");
            foreach (var item in pairedUnpaired)
            {
                BackgroundColor = ConsoleColor.Green;
                Write(item + " ");
            }
            foreach (var item in unsorted)
            {
                BackgroundColor = ConsoleColor.Red;
                Write(item + " ");
            }
            BackgroundColor = ConsoleColor.Black;
        }
        
    }
    
}
