using System;

namespace ProgrammingBasicsLab.Exercise03
{
    /// <summary>
    /// Exercise 3: writes the numbers 0 to 10 with a do while loop, and shows the
    /// one behaviour that separates it from a while loop.
    /// </summary>
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("do while loop: 0 to 10");

            // The body runs first and the condition is tested at the end, so the
            // body always runs at least once.
            int number = 0;

            do
            {
                Console.Write(number);

                if (number < 10)
                {
                    Console.Write(", ");
                }

                number++;
            }
            while (number <= 10);

            Console.WriteLine();
            Console.WriteLine();

            // Starting above the limit: the do while still runs once, the while
            // loop does not run at all. The two loops give the same output for
            // Exercise 3 only because the counter starts inside the range.
            Console.WriteLine("Starting at 11, the same two loops behave differently:");

            int doWhileCounter = 11;
            Console.Write("  do while from 11: ");

            do
            {
                Console.Write(doWhileCounter);
                doWhileCounter++;
            }
            while (doWhileCounter <= 10);

            Console.WriteLine();

            int whileCounter = 11;
            Console.Write("  while from 11   : ");

            while (whileCounter <= 10)
            {
                Console.Write(whileCounter);
                whileCounter++;
            }

            Console.WriteLine("(nothing)");
        }
    }
}
