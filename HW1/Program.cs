using System;
using System.Diagnostics;

namespace HW1
{
    internal class Program
    {
        static void Choice() 
        {
            Console.WriteLine("Select a task!\n" +
                "1. A range.\n" +
                "2. Percent.\n" +
                "3. A string of numbers.\n" +
                "4. A shift.\n" +
                "5. A date.\n" +
                "6. A temperature.\n" +
                "7. Even numbers.\n" +
                "Your choice?: ");
            switch (Console.ReadLine())
            {
                case "1":
                    Task1();
                    break;
                case "2":
                    Task2();
                    break;
                case "3":
                    Task3();
                    break;
                case "4":
                    Task4();
                    break;
                case "5":
                    Task5();
                    break;
                case "6":
                    Task6();
                    break;
                case "7":
                    Task7();
                    break;
                default:
                    Console.WriteLine("Good day!");
                    break;
            }
        }
        static void Task1() 
        {
            M1:
            Console.WriteLine("Enter a integer number between 1 and 100 inclusive: ");
            int num = int.Parse(Console.ReadLine());
            if (num < 1 || num > 100)
            {
                Console.WriteLine("Error! The integer number must be between 1 and 100 inclusive! Try again!");
                goto M1;
            }
            else if ((num % 3) == 0)
            {
                Console.WriteLine("Fizz");
            }
            else if ((num % 5) == 0)
            {
                Console.WriteLine("Buzz");
            }
            else if ((num % 3) == 0 && (num % 5) == 0)
            {
                Console.WriteLine("Fizz Buzz");
            }
            else
            {
                Console.WriteLine(num.ToString());
            }
        }
        static void Task2()
        {
            M1:
            Console.WriteLine("Enter a number: ");
            int num2 = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter percent");
            int perc = int.Parse(Console.ReadLine());
            double res = (num2 * (double)perc) / 100;
            if (perc < 1 || perc > 100)
            {
                Console.WriteLine("Error! percent must be >=1 and <=100! Try again!");
                goto M1;
            }
            else
                Console.WriteLine(perc + "% of " + num2 + " = " + res);
        }
        static void Task3()
        {
            Console.WriteLine("Enter digits separated by space:");
            string input = Console.ReadLine();
            string[] numbers = input.Split(' ');
            int res = 0;
            foreach (string number in numbers)
            {
                res = res * 10 + int.Parse(number);
            }
            Console.WriteLine("The generated number is: " + res);
        }
        static void Task4() 
        {
            M1:
            Console.WriteLine("Enter a six-digit number:");
            int num4 = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the positions of the digits to swap:");
            int position1 = int.Parse(Console.ReadLine());
            int position2 = int.Parse(Console.ReadLine());
            
            if (num4 < 100000 || num4 > 999999)
            {
                Console.WriteLine("Error! The number must be six digits! Try again!"); 
                goto M1;
            }
            else if (position1 < 1 || position1 > 6 || position2 < 1 || position2 > 6)
            {
                Console.WriteLine("Error! The number must be between 1 and 6 inclusive! Try again!");
                goto M1;
            }
            string numStr = num4.ToString();
            char[] charArr = numStr.ToCharArray();
            char temp = charArr[position1 - 1];
            charArr[position1 - 1] = charArr[position2 - 1];
            charArr[position2 - 1] = temp;
            int res = Convert.ToInt32(new string(charArr));
            Console.WriteLine("Result: " + res);
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
                Console.WriteLine(res);
            }*/
        }
        static void Task5()
        {
            M1:
            Console.WriteLine("Enter a date in the format DD.MM.YYYY");
            string input = Console.ReadLine();
            DateTime date;
            if (!DateTime.TryParse(input, out date))
            {
                Console.WriteLine("Error! Wrong date format! Enter the date in the format DD.MM.YYYY! Try again!");
                goto M1;
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
                goto M1;
            }
            string week = date.DayOfWeek.ToString();
            Console.WriteLine(season + " " + week);
        }
        static void Task6() 
        {
            M1:
            Console.WriteLine("Enter a temperature:");
            double temperature = double.Parse(Console.ReadLine());
            Console.WriteLine("Make a chice:");
            Console.WriteLine("1 - Convert from fahrenheit to celsius");
            Console.WriteLine("2 - Convert from celsius to fahrenheit");
            int choice = int.Parse(Console.ReadLine());
            double result;
            if (choice == 1)
            {
                result = (temperature - 32) * 5 / 9;
                Console.WriteLine(temperature + " F = "+ result + " C");
            }
            else if (choice == 2)
            {
                result = temperature * 9 / 5 + 32;
                Console.WriteLine(temperature + " F = " + result + " C");
            }
            else
            {
                Console.WriteLine("Wrong choice! Try again!");
                goto M1;
            }
        }
        static void Task7()
        {
            Console.Write("Enter the begin of the range: ");
            int start = int.Parse(Console.ReadLine());
            Console.Write("Enter the end of the range: ");
            int end = int.Parse(Console.ReadLine());
            if (start > end)
            {
                int temp = start;
                start = end;
                end = temp;
            }
            for (int i = start; i <= end; i++)
            {
                if (i % 2 == 0)
                {
                    Console.WriteLine(i);
                }
            }
        }
        static void Main(string[] args)
        {
            Choice();
            Console.WriteLine("To select another task, press Y. To quit, press any other key!");
            string input = Console.ReadLine().ToUpper();
            if (input == "Y")
            {
                Main(args);
            }
            else 
            {
                Console.WriteLine("Good day!");
            }
        }
    }
}