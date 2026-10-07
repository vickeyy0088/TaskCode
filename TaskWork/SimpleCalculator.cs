using System;
using System.Collections.Generic;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TaskWork
{
    internal class SimpleCalculator
    {
        public static void Calculator()
        {
            StringBuilder Data = new StringBuilder();
            bool running = true;

            Console.WriteLine("Simple Calculator with Crash Free.------");

            while (running)
            {
                double num1 = ReadNumber("Enter Number 1: ");
                Console.Write("Enter operator (+, -, *, /): ");
                string op = Console.ReadLine()?.Trim();
                double num2 = ReadNumber("Enter Number 2: ");

                if (op == "/" && num2 == 0) Console.WriteLine("Error: Cannot divide by zero!\n");

                double result = op switch
                {
                    "+" => num1 + num2,
                    "-" => num1 - num2,
                    "*" => num1 * num2,
                    "/" => num1 / num2,
                    _ => double.NaN
                };

                if (double.IsNaN(result))
                {
                    Console.WriteLine("Error: Invalid operator!\n");
                    continue;
                }

                string record = $"{num1} {op} {num2} = {result}";
                Console.WriteLine($"Result = {record}");

                Data.AppendLine(record);

                Console.Write("\nAnother calculation? (y/n): ");
                string answer = Console.ReadLine()?.Trim().ToLower(); // String methods

                if (answer != "y" && answer != "yes")
                {
                    running = false;
                }

                Console.WriteLine("------------------------------------");
            }
            Console.WriteLine("\n=== Calculation History ===");
            Console.WriteLine(Data.ToString());
        }

        private static double ReadNumber(string str)
        {
            double num;
            Console.Write(str);

            while (!double.TryParse(Console.ReadLine()?.Trim(), out num))
            {
                Console.WriteLine("Invalid input! Please enter a valid number.");
                Console.Write(str);
            }
            return num;
        }
    }
}
