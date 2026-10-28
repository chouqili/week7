using System;

namespace ProgrammingBasicsLab.Exercise05
{
    /// <summary>
    /// Exercise 5: runs the looping construct from the lab sheet and measures what
    /// actually stops it, then shows a loop that stops for the reason it was
    /// written for.
    /// </summary>
    public class Program
    {
        public static void Main()
        {
            // The lab sheet gives this body and this condition:
            //
            //     do
            //     {
            //         Result += 1;
            //     } while (Result >= 0);
            //
            // Result is never declared on the sheet, so the first change is
            //     int result = 0;
            // which is the least that lets the snippet compile. A long counter is
            // kept beside it to count the turns, because an int counter would wrap
            // at the same moment as result.
            int result = 0;
            long turns = 0;

            do
            {
                result += 1;
                turns += 1;
            }
            while (result >= 0);

            Console.WriteLine("The construct from the lab sheet, run until it stopped");
            Console.WriteLine("  turns taken   : " + turns);
            Console.WriteLine("  Result at exit: " + result);
            Console.WriteLine("  the int wrapped round; the condition was never false.");
            Console.WriteLine();

            // The repaired version: the counter is tested against a bound, so the
            // loop ends after five turns because of the condition, not because of
            // an overflow.
            Console.WriteLine("The same idea with a bound in the condition");
            int total = 0;

            for (int turn = 1; turn <= 5; turn++)
            {
                total += 1;
                Console.WriteLine("  turn " + turn + ": Result = " + total);
            }

            Console.WriteLine("  the loop ended because the condition turned false.");
        }
    }
}
