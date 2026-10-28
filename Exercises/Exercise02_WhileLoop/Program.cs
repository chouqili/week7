using System;

namespace ProgrammingBasicsLab.Exercise02
{
    /// <summary>
    /// Exercise 2: writes the numbers 0 to 10 with a while loop.
    /// </summary>
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("while loop: 0 to 10");

            // A while loop has no place for initialisation or update, so both are
            // written by hand: the counter is created above the loop and increased
            // inside it. If the update were left out, the condition would stay true
            // and the loop would never end.
            int number = 0;

            while (number <= 10)
            {
                Console.Write(number);

                if (number < 10)
                {
                    Console.Write(", ");
                }

                number++;
            }

            Console.WriteLine();
        }
    }
}
