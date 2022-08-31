using System;

namespace Calc
{
    class Program
    {
        static void Main(string[] args)
        {
            
            string result= Calculator();
            while (result == "yes")
            {
                result = Calculator();
            }
        }
        static string Calculator()
        {
            Console.WriteLine("enter an arithmetic operation from the suggested: +, -, *, /,  %, Sqrt.");
            string sign = Console.ReadLine();
            if (sign == "+")
            {
                try
                {
                    Console.WriteLine("Enter the first syllable");
                    int first = Int32.Parse(Console.ReadLine());
                    Console.WriteLine("Enter the second syllable");
                    int second = Int32.Parse(Console.ReadLine());
                    first += second;
                    Console.WriteLine($"Answer is {first}");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

            }
            else if (sign == "-")
            {
                try
                {
                    Console.WriteLine("Enter the decreasing number");
                    int first = Int32.Parse(Console.ReadLine());
                    Console.WriteLine("Enter the subtracted number");
                    int second = Int32.Parse(Console.ReadLine());
                    first -= second;
                    Console.WriteLine($"Answer is {first}");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            else if (sign == "*")
            {
                
                try
                {
                    Console.WriteLine("Enter the number to be multiplied");
                    int first = Int32.Parse(Console.ReadLine());
                    Console.WriteLine("Enter the multiplier");
                    int second = Int32.Parse(Console.ReadLine());
                    first *= second;
                    Console.WriteLine($"Answer is {first}");
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            else if (sign == "/")
            {
               
                try
                {
                    Console.WriteLine("Enter a divisible number");
                    double first = Int32.Parse(Console.ReadLine());
                    Console.WriteLine("Enter the divisor");
                    double second = Int32.Parse(Console.ReadLine());
                    first /= second;
                    Console.WriteLine($"Answer is {first}");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            else if (sign == "%")
            {
                try
                {
                    Console.WriteLine("Enter a number");
                    double first = Double.Parse(Console.ReadLine());
                    Console.WriteLine("Enter the percentage");
                    double second = Double.Parse(Console.ReadLine());
                    first = (first / 100) * second;
                    Console.WriteLine($"Answer is {first}");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

            }
            else if (sign == "Sqrt")
            {
                
                try
                {
                    Console.WriteLine("Enter a number");
                    double first = Double.Parse(Console.ReadLine());
                    first = Math.Sqrt(first);
                    Console.WriteLine($"Answer is {first}");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            else Console.WriteLine("You enter an incorrect operator");
            Console.WriteLine("enter \"YES\" if you want to restart the program");
            string answer = Console.ReadLine();
            answer = answer.ToLower();
            return answer;
        }
    }
}
