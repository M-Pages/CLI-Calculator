using System;
using System.Text.RegularExpressions;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleKeyInfo cki;
            do
            {
                calculate cal = new calculate();
                cal.inputManager();

                Console.WriteLine("press any key to continue or press Esc button to exit");
                cki = Console.ReadKey(true);
                
                if (cki.Key == ConsoleKey.Escape)
                    break;
                else
                {
                    Console.Clear();
                    continue;
                }

            }while(true);
        }
    }

    public class calculate
    {
        public static string inputFilter = @"^[0-9\+\-\*\/]+$";
        public static char[] numberFilter = {'+', '-', '*', '/'};
        public static string operatorFilter = @"[0-9]";

        public string input;
        public string[] numbers;
        public char[] operators;

        public double result = 0;

        public void inputManager()
        {
            Console.WriteLine("***Calculator*** \nType your numbers and operators in one line:");
            input = Console.ReadLine();
            input = Regex.Replace(input, @"\s", "");

            if (Regex.IsMatch(input, inputFilter) == false)
            {
                Console.WriteLine("Your inputs are invalid, please try again.");
                return;
            }
            else
            {
                settingUpArrays(input);
            }
        } 

        public void settingUpArrays(string inp)
        {   
            numbers = inp.Split(numberFilter);
            operators = Regex.Replace(inp, operatorFilter, "").ToCharArray();
            process();
        }

        public void process()
        {
            result = Convert.ToDouble(numbers[0]);

            for ( int i = 0 ; i < operators.Length ; i++ )
            {
                int s = i + 1;
                result = compute(result, numbers[s], operators[i]);
            }

            Console.WriteLine(input + " = " + result);
        }

        public double compute(double num1, string num2, char oper)
        {
            double n2 = Convert.ToDouble(num2);

            switch(oper)
            {
                case '+':
                return num1 + n2;

                case '-':
                return num1 - n2;

                case '*':
                return num1 * n2;

                case '/':
                return num1 / n2;

                default:
                return 0;
            }
        }
    }
}
