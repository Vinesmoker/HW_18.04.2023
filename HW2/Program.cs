using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] A = new int[5];
            double[,] B = new double[3, 4];
            int maxA = A[0];
            int minA = A[0];
            double maxB = B[0, 0];
            double minB = B[0, 0];
            Random rand = new Random();
            for (int i = 0; i < A.Length; i++) 
            {
                A[i] = int.Parse(Console.ReadLine());
            }
            for (int i = 0;i < B.GetLength(0); i++) 
            {
                for (int j = 0; j < B.GetLength(1); j++) 
                {
                    B[i, j] = rand.Next(-100, 100);
                }
            }
            for (int i = 0; i < A.Length; i++)
            {
                Console.Write(A[i] + "\t");
            }
            Console.WriteLine("\n");
            for (int i = 0; i < B.GetLength(0); i++)
            {
                for (int j = 0; j < B.GetLength(1); j++) 
                {
                    Console.Write(B[i, j] + "\t");
                }
                Console.WriteLine("\n");
            }
            for (int i = 0; i < A.Length; i++)
            {
                if (A[i] > maxA)
                {
                    maxA = A[i];
                }
                if (A[i] < minA)
                {
                    minA = A[i];
                }
            }
            for (int i = 0; i < B.GetLength(0); i++)
            {
                for (int j = 0; j < B.GetLength(1); j++)
                {
                    if (B[i, j] > maxB)
                    {
                        maxB = B[i, j];
                    }
                    if (B[i, j] < minB)
                    {
                        minB = B[i, j];
                    }
                }
            }
            Console.WriteLine("Максимальное значение в массиве A: " + maxA);
            Console.WriteLine("Минимальное значение в массиве A: " + minA);
            Console.WriteLine("Максимальное значение в массиве B: " + maxB);
            Console.WriteLine("Минимальное значение в массиве B: " + minB);

        }
    }
}
