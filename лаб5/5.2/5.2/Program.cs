using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5._2
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            Console.WriteLine("If you want to create your own array write CustomExample");
            Console.WriteLine("If you want to use prepared array write TestCase");
            Console.WriteLine("If you want to leave the programm write Quit");
            Console.WriteLine();
            Console.Write("Numbers, which are in the diapason are ");
            Console.BackgroundColor = ConsoleColor.Green;
            Console.Write("green");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write(" ");
            Console.Write("else the number is ");
            Console.BackgroundColor = ConsoleColor.Red;
            Console.Write("red");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine(" ");
            while (true)
            {
                string command = Console.ReadLine();
                if(command == "CustomExample")
                {
                    CustomExample();
                    
                }
                if(command == "TestCase")
                {
                    TestCase();
                    Console.WriteLine();
                }
                if(command == "Quit")
                {
                    Console.ReadKey();
                    break;
                }
                else
                {
                    Console.WriteLine("Incorrect data, try again");
                }
            }
            Console.ReadKey();
        }
        static void TestCase()
        {
            int[] num = new int[] { 4, 6, 400, 231, 22, 13, 214, 314, 12242, 1 };
            int n = num.Length;
            int check = 0;
            int counterRight = 0;
            int counterWrong = 0;
            for (int i = 0; i < num.Length; i++)
            {
                check = ConvertToTen(num[i]);
                if (check >= (n / 2) && (check <= (n * n))) counterRight++;
                else counterWrong++;
            }
            int[] fifth = new int[counterRight];
            int[] wrong = new int[counterWrong];
            counterRight = 0;
            counterWrong = 0;
            SortAndPaint(counterRight, counterWrong, num, check, n, fifth, wrong);
            Console.WriteLine();
            int[,] final = AddZeroesRight(fifth);
            final = SortRight(final);
            int[] sorted = Return(final);
            Array.Reverse(wrong);

            int counter = 0;

            for (int i = 0; i < num.Length; i++)
            {
                if (i < sorted.Length)
                {
                    num[i] = sorted[i];
                }
                else
                {
                    num[i] = wrong[counter];
                    counter++;
                }
            }

            counterRight = 0;
            counterWrong = 0;
            SortAndPaint(counterRight, counterWrong, num, check, n, fifth, wrong);

            Console.BackgroundColor = ConsoleColor.Black;

            Console.ReadKey();

        }
        static void CustomExample()
        {
            Console.WriteLine("Input the length of the array");
            int n = 0;
            while (true)
            {
                try
                {
                    n = Convert.ToInt32(Console.ReadLine());
                    break;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Incorrect data, try again");
                }
            }
            Console.WriteLine();
            int[] num = new int[n];
            int number =0;
            int[] checkDig;
            bool allRight = true;
            for (int i = 0; i < num.Length; i++)
            {
                Console.WriteLine("Input "+i+ " number");
                
                try
                {
                    number = Convert.ToInt32(Console.ReadLine());
                    allRight = true;
                }
                catch(Exception e)
                {
                    Console.WriteLine("Incorrect data, try again");
                    allRight = false;
                    if (i == 0) i = -1;
                    else i--;
                }
                if (allRight)
                {
                    //number = Convert.ToInt32(Console.ReadLine());
                    checkDig = Split(number);
                    for (int j = 0; j < checkDig.Length; j++)
                    {
                        if ((checkDig[j] > 4) || (checkDig[j] < 0))
                        {
                            Console.WriteLine("Incorrect data, try again");
                            i--;
                            break;
                        }
                        else
                        {
                            num[i] = number;
                        }
                    }
                }
            }
            n = num.Length;
            int check = 0;
            int counterRight = 0;
            int counterWrong = 0;
            for (int i = 0; i < num.Length; i++)
            {
                check = ConvertToTen(num[i]);
                if (check >= (n / 2) && (check <= (n * n))) counterRight++;
                else counterWrong++;
            }
            int[] fifth = new int[counterRight];
            int[] wrong = new int[counterWrong];
            counterRight = 0;
            counterWrong = 0;
            SortAndPaint(counterRight, counterWrong, num, check, n, fifth, wrong);
            Console.WriteLine();
            int[,] final = AddZeroesRight(fifth);
            final = SortRight(final);
            int[] sorted = Return(final);
            Array.Reverse(wrong);

            int counter = 0;

            for (int i = 0; i < num.Length; i++)
            {
                if (i < sorted.Length)
                {
                    num[i] = sorted[i];
                }
                else
                {
                    num[i] = wrong[counter];
                    counter++;
                }
            }

            counterRight = 0;
            counterWrong = 0;
            SortAndPaint(counterRight, counterWrong, num, check, n, fifth, wrong);

            Console.BackgroundColor = ConsoleColor.Black;

            Console.ReadKey();



        }
        static void SortAndPaint( int counterRight, int counterWrong, int[] num, int check, int n, int[] fifth, int[] wrong )
        {
            counterRight = 0;
            counterWrong = 0;
            for (int i = 0; i < num.Length; i++)
            {
                check = ConvertToTen(num[i]);
                if (check >= (n / 2) && (check <= (n * n)))
                {
                    Console.BackgroundColor = ConsoleColor.Green;
                    fifth[counterRight] = num[i];
                    Console.Write(fifth[counterRight]);
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.Write(" ");
                    counterRight++;
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    wrong[counterWrong] = num[i];
                    Console.Write(wrong[counterWrong]);
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.Write(" ");
                    counterWrong++;
                }
            }
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write(";");
            Console.WriteLine();
        }
        static int[] GenerateInFive(int length)
        {
            Random rnd = new Random();
            int[] result = new int[length];
            int rozr =0;
            string tmp = "";
            string num = "";
            for (int i = 0; i < length; i++)
            {
                rozr = rnd.Next(1, 6);
                for (int j = 0; j < rozr; j++)
                {
                    if (j==0)
                    {
                        tmp = Convert.ToString(rnd.Next(1, 5));
                    }
                    else
                    {
                        tmp = Convert.ToString(rnd.Next(5));
                    }
                    num += tmp;
                    tmp = "";
                }
                result[i] = int.Parse(num);
                num = "";
            }
            return result;
        }
        static int[] Split(int num)
        {
            int length = Convert.ToString(num).Length; 
            int[] numbers = new int[length];
            int zifra = 0;
            int ost = 0;
            int counter = 0;
            for (int i = length-1; i >=0; i--)
            {
                ost = num%(int)Math.Pow(10, i);
                zifra = (num-ost)/ (int)Math.Pow(10, i);
                numbers[counter] = zifra;
                num = ost;
                counter++;
            }
            return numbers;
        } //+
        
        static int ConvertToTen(int fifth)
        {
            int tenth = 0;
            int[] tmp = Split(fifth);
            int fivthCat = 0;
            int counter = 0;
            int sum = 0;
            for (int i = tmp.Length - 1; i >= 0; i--)
            {
                fivthCat = tmp[counter] * (int)Math.Pow(5, i);
                sum += fivthCat;
                fivthCat = 0;
                counter++;
            }
            tenth = sum;
            return tenth;
        } //+
        static int[,] Swap(int[,] original, int a, int b)
        {
            int[] tmp = new int[original.GetLength(1)] ;
            for (int j = 0; j < original.GetLength(1); j++)
            {
                tmp[j] = original[a,j] ;
            }
            for (int j = 0; j < original.GetLength(1); j++)
            {
                original[a, j] = original[b, j];
            }
            for (int j = 0; j < original.GetLength(1); j++)
            {
                original[b, j] = tmp[j];
            }
           
            return original;

        } //+
        
        static int[,] AddZeroesRight(int[] fifth)
        {
            int[,] final;
            int length = 0;
            for (int i = 0; i < fifth.Length; i++)
            {
                if (Convert.ToString(fifth[i]).Length > length) length = Convert.ToString(fifth[i]).Length;
            }
            final = new int[fifth.Length, length+1]; // добавление нолика
            int[] tmp;
            int lengthTmp = length;
            int counter = 0;
            for (int i = 0; i < fifth.Length; i++)
            {
                tmp = Split(fifth[i]);
                if(i == fifth.Length)
                {
                    for (int j = 0; j < length; j++)
                    {
                        final[i, j] = 0;
                    }
                }
                else
                {
                    for (int j = 0; j < length; j++)
                    {
                        if (j < lengthTmp - tmp.Length)
                        {
                            final[i, j] = 0;
                        }
                        else
                        {
                            final[i, j] = tmp[counter];
                            counter++;
                        }
                    }
                }
                counter = 0;
            }
            return final;
        } //+

        static int[,] SortRight(int[,] matrix)
        {
            for (int i = matrix.GetLength(1)-2; i >=0; i--)
            {

                for (int j = 0; j < matrix.GetLength(0); j++)
                {
                    for (int k = 1; k < matrix.GetLength(0) - j; k++)
                    {
                        if ((matrix[k - 1, i] < matrix[k, i]) && ComparePrevDigRight(matrix, k, i))
                        {
                            Swap(matrix, k - 1, k);
                        }
                    }
                }

                for (int i1 = 0; i1 < matrix.GetLength(0); i1++)
                {
                    for (int j = 0; j < matrix.GetLength(1)-1; j++)
                    {
                        Console.Write(matrix[i1, j]);
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
            }
            return matrix;
        } //+

        static bool ComparePrevDigRight(int[,] matrix, int k, int i)
        {
            while (++i < matrix.GetLength(1))
            {
                if (matrix[k - 1, i] != matrix[k, i]) return false;
            }
            return true;
        } //+

        static int[] Return(int[,] matrix)
        {
            int[] final = new int[matrix.GetLength(0)];
            int length = matrix.GetLength(1)-1;
            string strDid = "";
            for (int i = 0;i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < length; j++)
                {
                    strDid+=matrix[i, j];
                }
                final[i] = RemoveZeroes(Convert.ToInt32(strDid));
                strDid = "";
            }
            return final;
        } //+

        static int RemoveZeroes(int num)
        {
            int ret = 0;
            string digit = Convert.ToString(num);
            string final="";
            int counter = 0;
            for (int i = 0; i<digit.Length; i++)
            {
                counter = i;
                if(digit[i] !='0')
                {
                    for (int j = 0; j < digit.Length-i; j++)
                    {
                        final += digit[counter];
                        counter++;
                    }
                    break;
                }
            }
            ret = int.Parse(final);
            return ret;
        } //+

        
    }
}
