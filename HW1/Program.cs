using System;
using System.Diagnostics;

namespace HW1
{
    internal class Program
    {
        static string Task1(int num) 
        {
            if (num < 1 || num > 100)
            {
                return("Error! The integer number must be between 1 and 100 inclusive!");
            }
            else if ((num % 3) == 0)
            {
                return("Fizz");
            }
            else if ((num % 5) == 0)
            {
                return ("Buzz");
            }
            else if ((num % 3) == 0 && (num % 5) == 0)
            {
                return ("Fizz Buzz");
            }
            else
            {
                return num.ToString();
            }
        }
        static double Task2(int num2, int perc)
        {
            if (perc < 1 || perc > 100)
            {
                Console.WriteLine("Error!");
                return 0;
            }
            else
                return (num2 * (double)perc) / 100;
        }
        static int Task3()
        {
            Console.WriteLine("Enter digits separated by space:");
            string input = Console.ReadLine();
            string[] numbers = input.Split(' ');
            int res = 0;
            foreach (string number in numbers)
            {
                res = res * 10 + int.Parse(number);
            }
            return res;
        }
        static int Task4(int num4, int position1, int position2) 
        {
            if (num4 < 100000 || num4 > 999999)
            {
                Console.WriteLine("Error! The number must be six digits!");
                return num4;
            }
            else if (position1 < 1 || position1 > 6 || position2 < 1 || position2 > 6)
            {
                Console.WriteLine("Error! The number must be between 1 and 2 inclusive");
                return num4;
            }
            string numStr = num4.ToString();
            char[] charArr = numStr.ToCharArray();
            char temp = charArr[position1 - 1];
            charArr[position1 - 1] = charArr[position2 - 1];
            charArr[position2 - 1] = temp;
            int res = Convert.ToInt32(new string(charArr));
            return res;
            /*else
            {
                int[] numbers = new int[6];
                for (int i = 5; i >= 0; i--)
                {
                    numbers[i] = num4 % 10;
                    num4 /= 10;
                }
                int temp = numbers[position1 - 1];
                numbers[position1 - 1] = numbers[position2 - 1];
                numbers[position2 - 1] = temp;
                int res = 0;
                for (int i = 0; i < 6; i++)
                {
                    res = res * 10 + numbers[i];
                }
                return res;
            }*/
        }
        static void Task5(string input)
        {
            DateTime date;
            if (!DateTime.TryParse(input, out date))
            {
                Console.WriteLine("Error! Wrong date format! Enter the date in the format DD.MM.YYYY!");
                return;
            }
            string season;
            if (date.Month == 3 || date.Month == 4 || date.Month == 5)
            {
                season = "Spring";
            }
            else if (date.Month == 6 || date.Month == 7 || date.Month == 8)
            {
                season = "Summer";
            }
            else if (date.Month == 9 || date.Month == 10 || date.Month == 11)
            {
                season = "Autumn";
            }
            else if (date.Month == 12 || date.Month == 1 || date.Month == 2)
            {
                season = "Winter";
            }
            else
            {
                Console.WriteLine("Error! Invalid month value!");
                return;
            }
            string week = date.DayOfWeek.ToString();
            Console.WriteLine(season + " " + week);
        }
        static void Main(string[] args)
        {
            //////////////TASK 1////////////////
            Console.WriteLine("Enter a integer number between 1 and 100 inclusive: ");
            int num = int.Parse(Console.ReadLine());
            Program.Task1(num);

            //////////////TASK 2////////////////
            Console.WriteLine("Enter a number: ");
            int num2 = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter percent");
            int perc = int.Parse(Console.ReadLine());
            double res = Task2(num2, perc);
            Console.WriteLine(perc + "% of " + num2 + " = " + res);

            //////////////TASK 3////////////////
            int num3 = Task3();
            Console.WriteLine("The generated number is: " + num3);

            //////////////TASK 4////////////////
            Console.WriteLine("Enter a six-digit number:");
            int num4 = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the positions of the digits to swap:");
            int position1 = int.Parse(Console.ReadLine());
            int position2 = int.Parse(Console.ReadLine());
            int result = Task4(num4, position1, position2);
            Console.WriteLine("Result: " + result);

            //////////////TASK 5////////////////
            Console.WriteLine("Enter a date in the format DD.MM.YYYY");
            string input = Console.ReadLine();
            Task5(input);
        }
    }
}
//Console.WriteLine("Try again?\n Press Y to continue or any key to stop: ");
//string answer = Console.ReadLine();
//if (answer == "y" || answer == "Y")Program.Main(args);
