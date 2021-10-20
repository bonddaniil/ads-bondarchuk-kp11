using System;
using static System.Console;
using static System.Math;
namespace Завдання_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Vvedit` rik: ");
            int year = int.Parse(ReadLine());
            int c = year / 100; //Старші цифри року
            int y = year % 100; //молодші цифри року
            double dayOfWeek = 0; // номер дня тижня
            int d = 0; //номер дня місяця
            int m = 0; //номер місяця
            bool yearIsLeap = false; //якщо рік високосний, то true
            
            if (year % 4 == 0) //визначення чи є рік високосний
            {
                if(year % 100 == 0 && year % 400 != 0)
                    yearIsLeap = false;
                else
                    yearIsLeap = true;
            }
            else
            {
                yearIsLeap = false;
            }
            int dCurrent = 0;
            int mCurrent = 0;
            int yCurrent = 0;

            for (m = 1; m < 13; m++)
            {
                if (m == 11 || m == 1 || m == 3 || m == 5 || m == 6 || m == 8 || m == 10) d = 31;
                if (m == 2 || m == 4 || m == 7 || m == 9) d = 30;
                if (m == 12 && yearIsLeap == true) d = 29;
                if (m == 12 && yearIsLeap == false) d = 28;
                if (m == 11) 
                {
                    year = year - 1;
                    c = year / 100;
                    y = year % 100;

                } 
                for (int di = 1; di < d+1; di++)
                {
                    dayOfWeek = (Floor(2.6 * m - 0.2)+di+y+(y/4)+(c/4)-2*c)%7;
                    if(dayOfWeek == 4)
                    {
                        dCurrent = di;
                    }
                }

                if (m == 11 || m == 12)
                {
                    mCurrent = m - 10;
                    yCurrent = year + 1;
                }

                else
                {
                    mCurrent = m + 2;
                    yCurrent = year;
                }
                    

                WriteLine("{0}.{1}.{2}", dCurrent, mCurrent, yCurrent);
                WriteLine("--------------------------------------");
            }
        }
    }
}
/*if (y % 4 == 0 && i == 2 && || (y % 100 == 0 && y % 400 == 0))
{
    f = 28 + (i + i / 8) % 2 + 2 % i + (1 / i) * 2 + 1;
}
f = 28 + ((i+2) + (i+2) / 8) % 2 + 2 % (i+2) + (1 / (i+2)) * 2;
                if((i == 2 && year % 4 == 0 && year % 100 != 0) || (i == 2 && year % 4 == 0 && year % 100 == 0 && year % 400 == 0))
                {
                    f++;
                }*/
