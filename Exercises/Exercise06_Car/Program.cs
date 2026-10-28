using System;

namespace ProgrammingBasicsLab.Exercise06
{
    /// <summary>
    /// Exercise 6: creates Car objects and exercises the properties and the
    /// Describe method.
    /// </summary>
    public class Program
    {
        public static void Main()
        {
            Car first = new Car("Toyota", "Corolla", "silver", "ABC123");
            Car second = new Car("Ford", "Ranger", "blue", "XYZ987");

            Console.WriteLine(first.Describe());
            Console.WriteLine(second.Describe());
            Console.WriteLine();

            // The registration number is read from the object.
            Console.WriteLine("Registration read from the first car: "
                              + first.RegistrationNumber);
            Console.WriteLine();

            // The next line is the one the lab asks about. It does not compile:
            //     first.RegistrationNumber = "AAA111";
            // error CS0200: Property or indexer 'Car.RegistrationNumber' cannot be
            // assigned to -- it is read only
            Console.WriteLine("Make before any change           : " + first.Make);

            // The make property accepts a value with something in it.
            first.Make = "Honda";
            Console.WriteLine("Make after a valid change        : " + first.Make);

            // An empty string is ignored, so the Honda stays.
            first.Make = "";
            Console.WriteLine("Make after an empty string       : " + first.Make);

            // So is a string of spaces.
            first.Make = "    ";
            Console.WriteLine("Make after a string of spaces    : " + first.Make);
            Console.WriteLine();
            Console.WriteLine("The car after the changes:");
            Console.WriteLine(first.Describe());
        }
    }
}
