using System;
using static System.Console;
using System.Collections.Generic;

namespace листик
{
    class Program
    {
        static int N;
        static int[,] matrix;
        //******************************************
        static void Main(string[] args)
        {
            Write("matrix length and width (N/M) = ");
            N = int.Parse(Console.ReadLine());
            matrix = GenerateMatrix(N);
            PrintMatrix(matrix);

            //****************************
            /* WriteLine();
             Diagonal(matrix);
             PrintMatrix(matrix);*/

            //****************************
            WriteLine("Vert:");
            ZVert(matrix);
            //PrintMatrix(matrix);
            WriteLine("Diagonal:");
            Diagonal(matrix);
            WriteLine();
            //*****************************
            WriteLine("Gor:");
            ZGor(matrix);
            //PrintMatrix(matrix);*/
        }
        static Random rnd = new Random();

        //*******************************************
        static int[,] GenerateMatrix(int dim)
        {
            int[,] arr = new int[dim, dim];
            for (int i = 0; i < dim; i++)
            {
                for (int j = 0; j < dim; j++)
                {
                    arr[i, j] = rnd.Next(1, 10);
                }
            }
            return arr;
        }
        //*******************************************
        static void PrintMatrix(int[,] arr)
        {
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    Write($"{arr[i, j],3}");
                }
                WriteLine();
            }
            Write("\n");
        }

        static void Diagonal(int[,] arr)
        {
            int[] result = new int[arr.GetLength(0)];
            int itemResult = 0;
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    if (i + j == arr.GetLength(0) - 1)
                    {
                        result[itemResult] = arr[i, j];
                        itemResult++;
                    }
                }
            }
            for (int i = result.Length-1; i >=0 ; i--)
            {
                Write(result[i] + " ");
            }
        }

        static void ZVert(int[,] arr)
        {
            int x = 0, y = arr.GetLength(1) - 2;
            int max, min;
            max = arr[x, y];
            min = arr[x, y];
            int rowMax = y, lineMax = x, rowMin = y, lineMin = x;
            int [] result = new int [(arr.GetLength(0) * arr.GetLength(1) - arr.GetLength(0)) / 2];
            int itemResult = 0;
            result[itemResult] = arr[x, y];
            itemResult++;
            for (int i = 0, count = 1; i < arr.GetLength(0) - 2; i++)
            {
                if (i % 2 == 0)
                {
                    y--;
                    result[itemResult] = arr[x, y];
                    itemResult++;
                    if (arr[x, y] > max)
                    {
                        max = arr[x, y];
                        rowMax = y;
                        lineMax = x;
                    }
                    if (arr[x, y] < min)
                    {
                        min = arr[x, y];
                        rowMin = y;
                        lineMin = x;
                    }

                    for (int j = 0; j < count; j++)
                    {
                        x++;
                        result[itemResult] = arr[x, y];
                        itemResult++;
                        if (arr[x, y] > max)
                        {
                            max = arr[x, y];
                            rowMax = y;
                            lineMax = x;
                        }
                        if (arr[x, y] < min)
                        {
                            min = arr[x, y];
                            rowMin = y;
                            lineMin = x;
                        }
                    }
                }
                else
                {
                    y--;
                    x++;
                    result[itemResult] = arr[x, y];
                    itemResult++;
                    if (arr[x, y] > max)
                    {
                        max = arr[x, y];
                        rowMax = y;
                        lineMax = x;
                    }
                    if (arr[x, y] < min)
                    {
                        min = arr[x, y];
                        rowMin = y;
                        lineMin = x;
                    }
                    for (int j = 0; j < count; j++)
                    {
                        x--;
                        result[itemResult] = arr[x, y];
                        itemResult++;
                        if (arr[x, y] > max)
                        {
                            max = arr[x, y];
                            rowMax = y;
                            lineMax = x;
                        }
                        if (arr[x, y] < min)
                        {
                            min = arr[x, y];
                            rowMin = y;
                            lineMin = x;
                        }
                    }
                }
                count++;
            }
            for (int i = 0; i < result.Length; i++)
            {
                Write(result[i]+" ");
            }
            WriteLine();
            WriteLine("max = {0}, ({1},{2}) ", max,  rowMax, lineMax);
            WriteLine("min = {0}, ({1},{2}) ", min, rowMin, lineMin);
            
        }

        static void ZGor(int[,] arr)
        {
            int x = 0, y = arr.GetLength(1) - 1;
            int max, min;
            max = arr[x, y];
            min = arr[x, y];
            int rowMax = y, lineMax = x, rowMin = y, lineMin = x;
            int[] result = new int[(arr.GetLength(0) * arr.GetLength(1) - arr.GetLength(0)) / 2];
            int itemResult = 0;
            x++;
            result[itemResult] = arr[x, y];
            itemResult++;
            
            for (int i = 0, count = 1; i < arr.GetLength(0) - 2; i++, count++)
            {
                if (i % 2 == 0)
                {
                    x++;
                    y--;
                    result[itemResult] = arr[x, y];
                    itemResult++;
                    if (arr[x, y] > max)
                    {
                        max = arr[x, y];
                        rowMax = y;
                        lineMax = x;
                    }
                    if (arr[x, y] < min)
                    {
                        min = arr[x, y];
                        rowMin = y;
                        lineMin = x;
                    }

                    for (int j = 0; j < count; j++)
                    {
                        y++;
                        result[itemResult] = arr[x, y];
                        itemResult++;
                        if (arr[x, y] > max)
                        {
                            max = arr[x, y];
                            rowMax = y;
                            lineMax = x;
                        }
                        if (arr[x, y] < min)
                        {
                            min = arr[x, y];
                            rowMin = y;
                            lineMin = x;
                        }

                    }
                }
                else
                {
                    x++;
                    result[itemResult] = arr[x, y];
                    itemResult++;
                    if (arr[x, y] > max)
                    {
                        max = arr[x, y];
                        rowMax = y;
                        lineMax = x;
                    }
                    if (arr[x, y] < min)
                    {
                        min = arr[x, y];
                        rowMin = y;
                        lineMin = x;
                    }

                    for (int j = 0; j < count; j++)
                    {
                        y--;
                        result[itemResult] = arr[x, y];
                        itemResult++;
                        if (arr[x, y] > max)
                        {
                            max = arr[x, y];
                            rowMax = y;
                            lineMax = x;
                        }
                        if (arr[x, y] < min)
                        {
                            min = arr[x, y];
                            rowMin = y;
                            lineMin = x;
                        }
                    }

                }

            }
            for (int i = 0; i < result.Length; i++)
            {
                Write(result[i] + " ");
            }
            WriteLine();
            WriteLine("max = {0}, ({1},{2}) ", max, rowMax, lineMax);
            WriteLine("min = {0}, ({1},{2}) ", min, rowMin, lineMin);
        }
    }
}

