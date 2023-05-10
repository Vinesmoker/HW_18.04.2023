using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW2
{
    internal class Program
    {
        static void PrintArr1(int[] Arr1) 
        {
            for (int i = 0; i < Arr1.Length; i++)
            {
                Console.Write(Arr1[i] + "\t");
            }
        }
        static void PrintArr2(double[,] Arr2) 
        {
            for(int i = 0; i < Arr2.GetLength(0); i++) 
            {
                for(int j = 0; j < Arr2.GetLength(1); j++) 
                {
                    Console.Write(Arr2[i, j] + "\t");
                }
                Console.WriteLine("\n");
            }
        }
        static void Main(string[] args)
        {
            int[] Arr1 = new int[5];
            double[,] Arr2 = new double[3, 4];
            Random rand = new Random();
            for (int i = 0; i < Arr1.Length; i++) 
            {
                Arr1[i] = int.Parse(Console.ReadLine());
            }
            for (int i = 0;i < Arr2.GetLength(0); i++) 
            {
                for (int j = 0; j < Arr2.GetLength(1); j++) 
                {
                    Arr2[i, j] = rand.Next(-100, 100);
                }
            }
            PrintArr1(Arr1);
            Console.WriteLine("\n");
            PrintArr2(Arr2);
            int maxArr1 = Arr1[0];
            int minArr1 = Arr1[0];
            double maxArr2 = Arr2[0, 0];
            double minArr2 = Arr2[0, 0];
            for (int i = 0; i < Arr1.Length; i++)
            {
                if (Arr1[i] < minArr1)
                {
                    minArr1 = Arr1[i];
                }
                if (Arr1[i] > maxArr1)
                {
                    maxArr1 = Arr1[i];
                }
            }
            for (int i = 0; i < Arr2.GetLength(0); i++)
            {
                for (int j = 0; j < Arr2.GetLength(1); j++)
                {
                    if (Arr2[i, j] < minArr2)
                    {
                        minArr2 = Arr2[i, j];
                    }
                    if (Arr2[i, j] > maxArr2)
                    {
                        maxArr2 = Arr2[i, j];
                    }
                }
            }
            Console.WriteLine("Min value in the array Arr2 is: " + minArr1);
            Console.WriteLine("Max value in the array Arr1 is: " + maxArr1);
            Console.WriteLine("Min value in the array Arr2 is: " + minArr2);
            Console.WriteLine("Max value in the array Arr2 is: " + maxArr2);
        }
    }
}
