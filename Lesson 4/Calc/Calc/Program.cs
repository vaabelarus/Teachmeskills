using System;

namespace Calc
{
    class Program
    {
        static void Main(string[] args)
        {
           
            string answer = "yes";
            while (answer == "yes")
            {
                Console.WriteLine("enter an arithmetic operation from the suggested: +, -, *, /,  %, Sqrt.");
                string text = Console.ReadLine();
                text = WithoutSpaces(text);
                string sign = WhatOperation(text);
                double result = Calculator(text, sign);
                Console.WriteLine(result);
                Console.WriteLine("enter \"YES\" if you want to restart the program");
                answer = Console.ReadLine();
                answer = answer.ToLower();
                
            }
        }
        static double Calculator(string text, string sign)
        {
           
                string[] values = text.Split(sign);
            if (values.Length == 2)
            {
                double first = Convert.ToDouble(values[1]);
                double result = RootOfTheNumber(first);
                return result;
            }
            else
            {
                double first = Convert.ToDouble(values[0]);
                double second = Convert.ToDouble(values[1]);
                double result = sign switch
                {
                    "+" => Addition(first, second),
                    "-" => Subtraction(first, second),
                    "*" => Multiplication(first, second),
                    "/" => Division(first, second),
                    "%" => Remainder(first, second),
                };
                return result;
            }
           
            
        }
        static double Addition(double first, double second)
        {
            return first + second;
        }
        static double Subtraction(double first, double second)
        {
            return first - second;
        }
        static double Multiplication(double first, double second)
        {
            return first * second;
        }
        static double Division(double first, double second)
        {
            return first / second;
        }
        static double Remainder(double first, double second)
        {
            return first % second;
        }
        static double RootOfTheNumber(double first)
        {
            return Math.Sqrt(first);
        } 
        static string WithoutSpaces(string txt)
        {
            try
            {
                if (String.IsNullOrWhiteSpace(txt) == true)
                {
                    
                    throw new Exception("You didn't write anything");

                }
                char[] symbs = txt.ToCharArray();

                string text = "";
                for (int i = 0; i < symbs.Length; i++)
                {
                    if (symbs[i] != ' ')
                    {
                        text += symbs[i];
                    }
                }
                return text;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("try again");
                string a = Console.ReadLine();
                return WithoutSpaces(a);
                
                
            }
           
        }
        static string WhatOperation(string txt)
        {
            try
            {
                string[] sign = { "*", "/", "+", "-", "%", "Sqrt" };
                for (int k = 0; k < sign.Length; k++)
                {
                    if (txt.Contains(sign[k]) == true)
                    {
                        return sign[k];
                    }
                }
                throw new Exception("metod WhatOperator doesn't find acceptable operator");
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("try again");
                string a = Console.ReadLine();
                return WhatOperation(a);
            }
        }
    }
}
