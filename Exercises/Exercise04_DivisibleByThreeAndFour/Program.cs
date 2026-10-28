using System;

namespace ProgrammingBasicsLab.Exercise04
{
    /// <summary>
    /// Exercise 4: writes every whole number from 0 to 100 that divides by both
    /// 3 and 4, then checks the list against the single test for 12.
    /// </summary>
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("Whole numbers from 0 to 100 that divide by both 3 and 4");

            int count = 0;

            for (int number = 0; number <= 100; number++)
            {
                // % gives the remainder, and && needs both tests to be true.
                // 0 passes because 0 divided by 3 and by 4 leaves no remainder.
                if (number % 3 == 0 && number % 4 == 0)
                {
                    if (count > 0)
                    {
                        Console.Write(", ");
                    }

                    Console.Write(number);
                    count++;
                }
            }

            Console.WriteLine();
            Console.WriteLine("Count: " + count);
            Console.WriteLine();

            // A number that divides by 3 and by 4 divides by 12, so the same list
            // should come out of one test. The two tests are compared here.
            string bothTests = "";
            string twelveTest = "";

            for (int number = 0; number <= 100; number++)
            {
                if (number % 3 == 0 && number % 4 == 0)
                {
                    bothTests = bothTests + number + " ";
                }

                if (number % 12 == 0)
                {
                    twelveTest = twelveTest + number + " ";
                }
            }

            Console.WriteLine("The % 3 && % 4 test and the % 12 test give the same list: "
                              + (bothTests == twelveTest));
        }
    }
}
