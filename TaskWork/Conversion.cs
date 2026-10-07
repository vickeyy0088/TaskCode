using System;
using System.Collections.Generic;
using System.Text;

namespace TaskWork
{
    internal class Conversion
    {
        public static void RunExercise()
        {

            // Types
            int totalTasks = 42;
            long globalCount = 7800000000L;
            bool isTaskComplete = true;
            char word = 'A';
            decimal price = 19.43m;
            Console.WriteLine($"{totalTasks.GetType()} ," +
                $"{globalCount.GetType()} ," +
                $"{isTaskComplete.GetType()} ," +
                $"{word.GetType()} ," +
                $"{price.GetType()}");

            // Conversion
            long longNum = 12345L;
            int smallNum = (int)longNum;
            Console.WriteLine(smallNum);

            int input = 435;
            double decimalinput = input;
            Console.WriteLine(decimalinput);

            double rating = 4.78;
            int displayRating = (int)rating;
            Console.WriteLine(displayRating);

            // Parsing
            string textInput = "123";
            int parsedinput = int.Parse(textInput);
            Console.WriteLine(parsedinput);

            decimal Sprice = 9.99m;
            string displayPrice = Sprice.ToString();
            Console.WriteLine(displayPrice);


            // var, const
            var data = "EMployee Data";
            Console.WriteLine(data); //treat as a string

            const double pi = 3.14159;
            Console.WriteLine(pi);

            Console.WriteLine("Conversion and Types are Done!");
        }
    }
}
