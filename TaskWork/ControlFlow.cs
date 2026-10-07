using System;
using System.Collections.Generic;
using System.Runtime.Intrinsics.X86;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TaskWork
{
    internal class ControlFlow
    {
        public static void RunAll()
        {
            Console.WriteLine("Control Flow Tasks");
            Console.WriteLine("------------------------------------");

            FizzBuzzGet(15);
            Console.WriteLine("------------------------------------");

            GradeCalculator();
            Console.WriteLine("------------------------------------");

            GuessNumberGame(1,15);
        }

        public static string FizzBuzzTask(int i)
        {
                if (i % 3 == 0 && i % 5 == 0) return "FizzBuzz";
                else if (i % 3 == 0) return "Fizz";
                else if (i % 5 == 0) return "Buzz";
                return i.ToString();
        }
        public static void FizzBuzzGet(int num)
        {
            Console.WriteLine("FizzBuzz Task ------------ ");
            for(int i = 1; i<=num; i++)
            {
                string result = FizzBuzzTask(i);
                Console.WriteLine($"{i}: {result}");
            }
        }

        public static void GradeCalculator()
        {
            Console.WriteLine("Grade Calculator Task ------------ ");

            int[] Marks = { 96, 87, 78, 65, 75, 50, 47, 23, 5 };

            foreach(int i in Marks)
            {
                string feedback = i switch
                {
                    > 100 or < 0 => "Invalid Marks",
                    > 90  => "Grade A",
                    > 80 => "Grade B",
                    > 60 => "Grade C",
                    _   => "Fail"
                };
                Console.WriteLine($"Score: {i} -> {feedback}");
            }
        }

        public static void GuessNumberGame(int min, int max)
        {
            Random N = new Random();
            int guessNumber = 0;

            Console.WriteLine($"Guess a number between {min} and {max}:");

            while(true)
            {
                int targetNumber = N.Next(min, max);

                Console.WriteLine("Enter the Number");
                string input = Console.ReadLine();

                if (!int.TryParse(input, out guessNumber))
                {
                    Console.WriteLine("Error: Please enter a valid number, not text or special characters.");
                    continue; // Skip the rest of the loop and prompt again
                }

                if (guessNumber < min && guessNumber > max)
                {
                    Console.WriteLine("Please enter number btw 1 to 15");
                }
                else if(guessNumber > targetNumber)
                {
                    Console.WriteLine($"Lose, G - {guessNumber} > T - {targetNumber}");
                }
                else if(guessNumber < targetNumber)
                {
                    Console.WriteLine($"Lose, G - {guessNumber} < T - {targetNumber}");
                }
                else
                {
                    Console.WriteLine($"Win, {guessNumber} = {targetNumber}");
                    Console.WriteLine("End!, Thank You for Playing");
                    break;
                }
            }
        }
    }
}
