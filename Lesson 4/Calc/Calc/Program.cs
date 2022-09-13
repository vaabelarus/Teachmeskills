using System;

namespace Calc
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] memory = new string[5];
            string answer = "yes";
            while (answer == "yes"||answer=="memory")
            {
                if (answer == "memory")
                {
                    ShowOperations(memory);
                }
                Console.WriteLine("enter an arithmetic operation from the suggested: +, -, *, /,  %, Sqrt.");
                string text = Console.ReadLine();
                text = WithoutSpaces(text);
                text = TaskChecker(text);
                string[] text_aray = CreateArray(text);
                text_aray = NumberCheaker(text_aray);
                memory = OperationMemory(memory, text_aray);

                string result = Calculator(text_aray);
                Console.WriteLine(result);
                Console.WriteLine("enter \"YES\" if you want to restart the program or \"Memory\" if you want to see last operations");
                answer = Console.ReadLine();
                answer = answer.ToLower();

            }
        }
        static string Calculator(string[] text)
        {
            text = RootOfTheNumber(text);
            text = Multiplication(text);
            text = Division(text);
            text = Subtraction(text);
            text = Addition(text);
            return text[0];

        }
        static string [] Addition(string[] array)
        {
            
            for (int k = 0; k < array.Length; k++)
            {
                if (array[k].Contains("+") == true && array.Length > 1)
                {
                    double first = Convert.ToDouble(array[k - 1]);
                    double second = Convert.ToDouble(array[k + 1]);
                    double result  = first + second;
                    array[k] = Convert.ToString(result);
                   array = DeleteEmptyIndex(array, k);
                    array = Addition(array);
                }
            }
            return array;
        }
        static string[] Subtraction(string[] array)
        {
            string[] new_array = array;
            for (int k = 0; k < array.Length; k++)
            {
                if (array[k].Contains("-") == true&&array.Length>1&&array[k].Length<2)
                {
                    double first = Convert.ToDouble(array[k - 1]);
                    double second = Convert.ToDouble(array[k + 1]);
                    double result = first - second;
                    array[k] = Convert.ToString(result);
                    new_array = DeleteEmptyIndex(array, k);
                    new_array = Subtraction(new_array);

                }
            }
            return new_array;
        }
        static string[] Multiplication(string[] array)
        {
            string[] new_array = array;
            for (int k = 0; k < array.Length; k++)
            {
                if (array[k].Contains("*") == true && array.Length > 1)
                {
                    double first = Convert.ToDouble(array[k - 1]);
                    double second = Convert.ToDouble(array[k + 1]);
                    array[k] = Convert.ToString(first * second);
                    new_array = DeleteEmptyIndex(array, k);
                    new_array = Multiplication(new_array);

                }
            }
            return new_array;

        }
        static string [] Division(string[] array)
        {
            string[] new_array = array;
            for (int k = 0; k < array.Length; k++)
            {
                if (array[k].Contains("/") == true && array.Length > 1)
                {
                    double first = Convert.ToDouble(array[k - 1]);
                    double second = Convert.ToDouble(array[k + 1]);
                    array[k] = Convert.ToString(first / second);
                    new_array = DeleteEmptyIndex(array, k);
                    new_array = Division(new_array);

                }
            }
            return new_array;
        }
        static double Remainder(double first, double second)
        {
            return first % second;
        }
        static string[] RootOfTheNumber(string [] array)
        {
            for (int k = 0; k < array.Length; k++)
            {
                if (array[k].Contains("Sqrt") == true)
                {
                    string[] values = array[k].Split("Sqrt");
                    double first = Convert.ToDouble(values[1]);
                    first = Math.Sqrt(first);
                    array[k] = Convert.ToString(first);
                }
            }
            return array;
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
        
        static string[] DeleteEmptyIndex(string[] array, int index)
        {
            string[] new_array = new string[array.Length-2];
            for(int k = 0, i=0; i < new_array.Length; k++,i++)
            {
                if (k == index - 1 | k == index + 1)
                {
                    k++;
                }
                new_array[i] = array[k];
                
                
            }
            return new_array;
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
        static string[] NumberCheaker(string [] a)
        {
            try
            {
            for(int k = 0; k < a.Length; k++)
                {
                    if (a[k].Contains("+")==true|| a[k].Contains("-") == true||a[k].Contains("*") == true|| a[k].Contains("/") ==true|| a[k].Contains("%")==true || a[k].Contains("Sqrt")==true)
                    {
                        k++;
                    }
                    double b = Convert.ToDouble(a[k]);
                }
                return a;
            }
            catch
            {
                Console.WriteLine("Your enter wrong number");
                Console.WriteLine("Enter an arithmetic operation from the suggested: +, -, *, /,  %, Sqrt.");
                string text = Console.ReadLine();
                text = WithoutSpaces(text);
                text = TaskChecker(text);
                string[] text_aray = CreateArray(text);
                text_aray = NumberCheaker(text_aray);
                return text_aray;
            }
        }
        static string[] OperationMemory(string[] memory,string[]array)
        {
            string text = "";
            foreach(string s in array)
            {
                text += s;
            }
            for(int k = memory.Length-1; k>0; k--)
            {
                memory[k] = memory[k - 1];
                
            }
            memory[0] = text;
            return memory;
        }
        static void ShowOperations(string[] array)
        {
            int k = 1;
            foreach (string s in array)
            {
                
                Console.WriteLine($"{k++}  {s}");
            }
        }
    }

}
