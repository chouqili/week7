using System;

namespace ProgrammingBasicsLab.Exercise07
{
    /// <summary>
    /// Exercise 7: a calculator that validates its operands and its operator in
    /// four ways - prevention with if/else, try/catch, try/catch/finally, and one
    /// catch clause per exception type.
    /// </summary>
    public class Calculator
    {
        public static void Run()
        {
            Console.WriteLine("Calculator");
            Console.WriteLine();
            Console.WriteLine("Choose the validation method:");
            Console.WriteLine("  1 - prevention, with if/else statements");
            Console.WriteLine("  2 - exception handling, with try/catch");
            Console.Write("Method: ");

            string methodText = Console.ReadLine();
            bool useExceptions = methodText != null && methodText.Trim() == "2";

            Console.WriteLine();
            Console.WriteLine("Enter a number, an operator (+ - * /) and a second number.");
            Console.WriteLine("Type q at the first prompt to stop.");

            while (true)
            {
                Console.WriteLine();
                Console.Write("First number : ");
                string firstText = Console.ReadLine();

                if (firstText == null || firstText.Trim().ToLower() == "q")
                {
                    break;
                }

                Console.Write("Operator     : ");
                string operatorText = Console.ReadLine();

                Console.Write("Second number: ");
                string secondText = Console.ReadLine();

                if (useExceptions)
                {
                    CalculateWithExceptions(firstText, operatorText, secondText);
                }
                else
                {
                    CalculateWithPrevention(firstText, operatorText, secondText);
                }
            }

            Console.WriteLine();
            Console.WriteLine("Calculator closed.");
        }

        // Prevention: every value is checked before it is used, so the parse, the
        // division and the switch are never reached with a value that would fail.
        private static void CalculateWithPrevention(string firstText,
                                                    string operatorText,
                                                    string secondText)
        {
            decimal first;

            if (!decimal.TryParse(firstText, out first))
            {
                Console.WriteLine("Please enter a number!");
                return;
            }

            char operation;

            if (!ReadOperator(operatorText, out operation))
            {
                return;
            }

            decimal second;

            if (!decimal.TryParse(secondText, out second))
            {
                Console.WriteLine("Please enter a number!");
                return;
            }

            // The divisor is checked before the division, which is the check the
            // lecture puts in front of a division.
            if (operation == '/' && second == 0)
            {
                Console.WriteLine("Cannot divide by zero!");
                return;
            }

            decimal result = Calculate(first, operation, second);
            Console.WriteLine(Format(first, operation, second, result));
        }

        // Exception handling: the operands are used straight away, and a failure is
        // caught by the clause that matches it. Finally runs either way.
        private static void CalculateWithExceptions(string firstText,
                                                    string operatorText,
                                                    string secondText)
        {
            char operation;

            // The operator is still checked with if/else: one character taken from
            // four is cheaper to check than to catch.
            if (!ReadOperator(operatorText, out operation))
            {
                return;
            }

            firstText = firstText ?? string.Empty;
            secondText = secondText ?? string.Empty;

            try
            {
                decimal first = decimal.Parse(firstText);
                decimal second = decimal.Parse(secondText);
                decimal result = Calculate(first, operation, second);

                Console.WriteLine(Format(first, operation, second, result));
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Cannot divide by zero!");
            }
            catch (FormatException)
            {
                Console.WriteLine("Please enter a number!");
            }
            catch (OverflowException)
            {
                Console.WriteLine("That number is too large for this calculator.");
            }
            catch (Exception e)
            {
                Console.WriteLine("Unexpected error: " + e.Message);
            }
            finally
            {
                Console.WriteLine("[finally] finished; ready for the next sum.");
            }
        }

        // The operator check used by both methods. char.TryParse succeeds only for a
        // single character, and IsOperator rejects the rest of the keyboard.
        private static bool ReadOperator(string operatorText, out char operation)
        {
            operation = ' ';
            string trimmed = operatorText == null ? "" : operatorText.Trim();

            if (!char.TryParse(trimmed, out operation))
            {
                Console.WriteLine("Please enter correct operator: + - * /");
                return false;
            }

            if (!IsOperator(operation))
            {
                Console.WriteLine("Please enter correct operator: + - * /");
                return false;
            }

            return true;
        }

        private static bool IsOperator(char candidate)
        {
            return candidate == '+' || candidate == '-'
                   || candidate == '*' || candidate == '/';
        }

        private static decimal Calculate(decimal first, char operation, decimal second)
        {
            switch (operation)
            {
                case '+':
                    return first + second;
                case '-':
                    return first - second;
                case '*':
                    return first * second;
                default:
                    // Division is rounded to two decimal places, as on the lab sheet.
                    return Math.Round(first / second, 2);
            }
        }

        private static string Format(decimal first,
                                     char operation,
                                     decimal second,
                                     decimal result)
        {
            return first + " " + operation + " " + second + " = " + result;
        }
    }
}
