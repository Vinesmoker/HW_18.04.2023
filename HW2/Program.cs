using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW2
{
    internal class Program
    {
        static void Choice()
        {
        M1:
            Console.WriteLine("Select a task!\n" +
                "1. Two arrays.\n" +
                "2. Sum of numbers in the two-dimensional array.\n" +
                "3. Ceaser Cipher.\n" +
                "4. Matrices.\n");
            switch (Console.ReadLine())
            {
                case "1":
                    Task1(); break;
                case "2":
                    Task2(); break;
                case "3":
                    Task3(); break;
                case "4":
                    Task4(); break;
                default:
                    Console.WriteLine("Incorrect input! Try again!");
                    goto M1;
            }
        }
        static void Task1()
        {
            int[] Arr1 = new int[5];
            double[,] Arr2 = new double[3, 4];
            Random rand = new Random();
            Console.WriteLine("Enter five array numbers:\n");
            for (int i = 0; i < Arr1.Length; i++)
            {
                Arr1[i] = int.Parse(Console.ReadLine());
            }
            for (int i = 0; i < Arr1.Length; i++)
            {
                Console.Write(Arr1[i] + "\t");
            }
            Console.WriteLine("\n");
            for (int i = 0; i < Arr2.GetLength(0); i++)
            {
                for (int j = 0; j < Arr2.GetLength(1); j++)
                {
                    Arr2[i, j] = rand.Next(-100, 100);
                }
            }
            for (int i = 0; i < Arr2.GetLength(0); i++)
            {
                for (int j = 0; j < Arr2.GetLength(1); j++)
                {
                    Console.Write(Arr2[i, j] + "\t");
                }
                Console.WriteLine("\n");
            }
            Console.WriteLine("\n");
            int minArr1 = Arr1[0];
            int maxArr1 = Arr1[0];
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
        static void Task2()
        {
            Console.WriteLine("Given an array 5x5:\n");
            int[,] arr = new int[10, 5];
            Random rand = new Random();
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    arr[i, j] = rand.Next(-100, 100);
                }
            }
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    Console.Write(arr[i, j] + "\t");
                }
                Console.WriteLine("\n");
            }
            Console.WriteLine("\n");
            int min = arr[0, 0];
            int max = arr[0, 0];
            int minRow = 0;
            int maxRow = 0;
            int minCol = 0;
            int maxCol = 0;
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    if (arr[i, j] < min)
                    {
                        min = arr[i, j];
                        minRow = i;
                        minCol = j;
                    }
                    if (arr[i, j] > max)
                    {
                        max = arr[i, j];
                        maxRow = i;
                        maxCol = j;
                    }
                }
            }
            int beginRow = Math.Min(minRow, maxRow) + 1;
            int endRow = Math.Max(minRow, maxRow);
            int beginCol = Math.Min(minCol, maxCol) + 1;
            int endCol = Math.Max(minCol, maxCol);
            int sum = 0;
            for (int i = beginRow; i < endRow; i++)
            {
                for (int j = beginCol; j < endCol; j++)
                {
                    sum += arr[i, j];
                }
            }
            Console.WriteLine(minRow + "\t" + maxRow + "\t" + minCol + "\t" + maxCol);
            Console.WriteLine("sum of numbers in a two-dimensional array is: " + sum);
        }
        static void Task3()
        {
            Console.WriteLine("Enter a string without encryption:\n");
            string input = Console.ReadLine();
            Console.WriteLine("Enter a key of encryption:\n");
            int key = int.Parse(Console.ReadLine());
            string encrypt = "";
            foreach (char a in input)
            {
                if (char.IsLetter(a))
                {
                    char shift = (char)(((a + key) - 97) % 26 + 97);
                    encrypt += char.IsUpper(a) ? shift : char.ToLower(shift);
                }
                else
                {
                    encrypt += a;
                }
            }
            Console.WriteLine("Encrypted line is:\n" + encrypt);
            string decrypt = "";
            foreach (char a in encrypt)
            {
                if (char.IsLetter(a))
                {
                    char shift = (char)(((a - key) - 97 + 26) % 26 + 97);
                    decrypt += char.IsUpper(a) ? shift : char.ToLower(shift);
                }
                else { decrypt += a; }
            }
            Console.WriteLine("Decripted line is:\n" + decrypt);
        }
        static void Task4()
        {
            int[,] matrix1 = new int[4, 4];
            int[,] matrix2 = new int[4, 4];
            Random random = new Random();
            Console.WriteLine("Matrix number one:\n");
            for (int i = 0; i < matrix1.GetLength(0); i++)
            {
                for (int j = 0; j < matrix1.GetLength(1); j++)
                {
                    matrix1[i, j] = random.Next(1, 50);
                    Console.Write(matrix1[i, j] + "\t");
                }
                Console.WriteLine();
            }
            Console.WriteLine("Matrix number Two:\n");
            for (int i = 0; i < matrix2.GetLength(0); i++)
            {
                for (int j = 0; j < matrix2.GetLength(1); j++)
                {
                    matrix2[i, j] = random.Next(51, 100);
                    Console.Write(matrix2[i, j] + "\t");
                }
                Console.WriteLine();
            }
            int k = 2;
            int[,] result = new int[matrix1.GetLength(0), matrix1.GetLength(1)];
            for (int i = 0; i < matrix1.GetLength(0); i++)
            {
                for (int j = 0; j < matrix1.GetLength(1); j++)
                {
                    result[i, j] = k * matrix1[i, j];
                }
            }
            Console.WriteLine("Multiplying the matrix by a number:");
            PrintMatrix(result);
            result = new int[matrix1.GetLength(0), matrix1.GetLength(1)];
            for (int i = 0; i < matrix1.GetLength(0); i++)
            {
                for (int j = 0; j < matrix1.GetLength(1); j++)
                {
                    result[i, j] = matrix1[i, j] + matrix2[i, j];
                }
            }
            Console.WriteLine("Addition of matrices:");
            PrintMatrix(result);
            result = new int[matrix1.GetLength(0), matrix2.GetLength(1)];
            for (int i = 0; i < matrix1.GetLength(0); i++)
            {
                for (int j = 0; j < matrix2.GetLength(1); j++)
                {
                    int sum = 0;
                    for (int c = 0; c < matrix1.GetLength(1); c++)
                    {
                        sum += matrix1[i, c] * matrix2[c, j];
                    }
                    result[i, j] = sum;
                }
            }
            Console.WriteLine("Matrices multiplication:");
            PrintMatrix(result);
            void PrintMatrix(int[,] matrix)
            {
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        Console.Write(matrix[i, j] + "\t");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
            }
        }
        static void Main(string[] args)
        {
            Choice();
            Console.WriteLine("To select another task, press Y! To quit, press any key!");
            string input = Console.ReadLine().ToUpper();
            if (input == "Y") Main(args); else Console.WriteLine("Have a nice day!");
        }
    }
}
