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
                text = TaskChecker(text);
                string[] text_aray = CreateArray(text);
                double result = Calculator(text_aray);
                Console.WriteLine(result);
                Console.WriteLine("enter \"YES\" if you want to restart the program");
                answer = Console.ReadLine();
                answer = answer.ToLower();
                
            }
        }
        static double Calculator(string []text)
        {
           
               
            if (text.Length == 1&&text[0].Contains("Sqrt")==true)
            {
                string[] values = text[0].Split("Sqrt");
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
        static string TaskChecker(string txt)
        {
            try
            {
                string[] sign = { "*", "/", "+", "-", "%", "Sqrt" };
                
                for (int k = 0; k < sign.Length; k++)
                {
                    if (txt.Contains(sign[k]) == true)
                    {
                        return txt;
                    }
                }
                throw new Exception("metod WhatOperator doesn't find acceptable operator");
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("try again");
                string a = Console.ReadLine();
                a = WithoutSpaces(a);
                return TaskChecker(a);
            }
        }
        static string FindASign(string [] txt)
        {
            string[] result=new string[2];
            try
            {
                string[] sign = { "Sqrt","*", "/", "+", "-", "%"};
                int k = 0;

                
                throw new  Exception("metod WhatOperator doesn't find acceptable operator");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("try again");
                string a = Console.ReadLine();
                a = WithoutSpaces(a);
                return TaskChecker(a);
            }
        }
        static string[] DeleteEmptyIndex(string[] array)
        {

        }
        static string[] CreateArray(string a)
        {
            string[] text =new string[a.Length];
            for(int k = 0, i=0; k < a.Length; k++)
            {
                if((a[k]=='*')||(a[k]=='+')|| (a[k] == '-') || (a[k] == '/')|| (a[k] == '%') || (a[k] == '+'))
                {
                    i++;
                    text[i] += a[k];
                    i++;
                }
                else text[i] += a[k];
            }
            int size = 0;
            foreach(string s in text)
            {
                if (String.IsNullOrWhiteSpace(s) == false) size++;
            }
            string[] new_text = new string[size];
            for(int k = 0; k < new_text.Length; k++)
            {
                new_text[k] = text[k];
            }
            return new_text;
        }
    }
}
