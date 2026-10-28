using System;

namespace ProgrammingBasicsLab.Exercise01
{
    /// <summary>
    /// Exercise 1: writes the numbers 0 to 10 with a for loop.
    /// </summary>
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("for loop: 0 to 10");

            // Initialisation runs once, the condition is tested before every turn,
            // and the update runs after every turn. The loop stops when the
            // condition becomes false, so 10 is printed and 11 is never reached.
            for (int number = 0; number <= 10; number++)
            {
                Console.Write(number);

                if (number < 10)
                {
                    Console.Write(", ");
                }
            }

            Console.WriteLine();
        }
    }
}
