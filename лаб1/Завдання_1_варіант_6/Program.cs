using System;
using static System.Console;
using static System.Math;

namespace Завдання_1_варіант_6
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Input x: ");
            double x = double.Parse(ReadLine());
            Console.Write("Input y: ");
            double y = double.Parse(ReadLine());
            Console.Write("Input z: ");
            double z = double.Parse(ReadLine());
            double a = 0, b = 0;
            if(Sin(PI+x) == 0 || y ==0 || z==0)
            {
                WriteLine("Erorr");
            }
            else
            {
                a = 1.0 / (2 * Sin(PI + x))+Pow(Sin((x+y)/2), 2);
                b = (Cos(a * a * x)) / (2 * y * z);
                WriteLine(a);
                WriteLine(b);
            }
            
        }
    }
}
