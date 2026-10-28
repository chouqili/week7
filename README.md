# Programming Basics in C# - Topic 7 lab

158.258 Web Development - Topic 7 laboratory exercises (28 October 2026).

Zezhi Li - Massey student ID 25014437, NZ244 student ID 247107.

Seven console programs that answer the seven exercises on the Topic 7 lab
sheet: the three counting loops, the loop that finds numbers divisible by 3 and
4, the analysis of the endless `do while`, the `Car` class, and the calculator
that validates its input in four ways. The written report is
`班级NZ244 姓名李泽智 学号247107-week7.docx`, submitted with this folder.

## What is in the folder

| Path | What it holds |
| --- | --- |
| `Exercises\Exercise01_ForLoop\Program.cs` | Exercise 1 - 0 to 10 with a `for` loop. |
| `Exercises\Exercise02_WhileLoop\Program.cs` | Exercise 2 - 0 to 10 with a `while` loop. |
| `Exercises\Exercise03_DoWhileLoop\Program.cs` | Exercise 3 - 0 to 10 with a `do while` loop, and the same loop started at 11 to show that the body always runs once. |
| `Exercises\Exercise04_DivisibleByThreeAndFour\Program.cs` | Exercise 4 - the whole numbers from 0 to 100 that divide by 3 and by 4, counted, and checked against the single `% 12` test. |
| `Exercises\Exercise05_EndlessDoWhile\Program.cs` | Exercise 5 - the loop from the lab sheet, run to the point where it actually stops, and a version whose condition can become false. |
| `Exercises\Exercise06_Car\Car.cs` | Exercise 6 - the `Car` class: fields, constructor, read-only `RegistrationNumber`, guarded `Make`, `Describe()`. |
| `Exercises\Exercise06_Car\Program.cs` | Exercise 6 - creates two cars and exercises the properties. |
| `Exercises\Exercise07_Calculator\Calculator.cs` | Exercise 7 - the calculator: prevention with if/else, `try`/`catch`, `try`/`catch`/`finally`, and one `catch` per exception type. |
| `Exercises\Exercise07_Calculator\Program.cs` | Exercise 7 - the entry point. |
| `tests\calculator-prevention.txt` | Input for the calculator in prevention mode: a multiplication, a division, a division by zero, a word where a number belongs, a subtraction. |
| `tests\calculator-exceptions.txt` | Input for the calculator in exception mode: a division by zero, a word, a number too large for `decimal`, a valid subtraction, and a two-character operator. |
| `build.ps1`, `build.cmd` | Builds all seven programs into `bin`. |
| `README.md` | This file. |

## Build

`build.cmd` builds every program into `bin` with the C# compiler that ships
with Windows, so neither Visual Studio nor the .NET SDK is needed:

```bat
build.cmd
```

`build.cmd` is a wrapper around `build.ps1`, because Windows blocks unsigned
PowerShell scripts on many machines by default. To run the script directly:

```powershell
powershell -NoProfile -ExecutionPolicy Bypass -File .\build.ps1
```

The compiler is `C:\Windows\Microsoft.NET\Framework64\v4.0.30319\csc.exe`
(version 14.8.10001.0, C# 5) against .NET Framework 4.8, which is on every
supported Windows installation. The sources use nothing newer than C# 5, so
they can also be pasted into a Visual Studio Console Application project
(`File > New > Project > Console App`), one project per exercise, with the
files of that exercise added to the project.

## Run

| Program | Command | Prints |
| --- | --- | --- |
| Exercise 1 | `bin\Exercise01_ForLoop.exe` | `0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10` |
| Exercise 2 | `bin\Exercise02_WhileLoop.exe` | the same sequence |
| Exercise 3 | `bin\Exercise03_DoWhileLoop.exe` | the same sequence, then the start-at-11 comparison |
| Exercise 4 | `bin\Exercise04_DivisibleByThreeAndFour.exe` | `0, 12, 24, 36, 48, 60, 72, 84, 96`, the count 9, and the `% 12` cross-check |
| Exercise 5 | `bin\Exercise05_EndlessDoWhile.exe` | 2,147,483,648 turns taken, `Result` at -2,147,483,648, then the bounded loop |
| Exercise 6 | `bin\Exercise06_Car.exe` | two cars described, the registration read, and the guarded `Make` property |
| Exercise 7 | `bin\Exercise07_Calculator.exe` | the calculator; it asks first whether to validate by prevention or by exception |

Exercise 7 reads its three values one line at a time. To run it without typing
by hand, feed it one of the test inputs:

```powershell
Get-Content .\tests\calculator-prevention.txt | .\bin\Exercise07_Calculator.exe
Get-Content .\tests\calculator-exceptions.txt | .\bin\Exercise07_Calculator.exe
```

## How each exercise answers the lab sheet

**Exercise 1** uses `for (int number = 0; number <= 10; number++)`: the
initialisation runs once, the condition is tested before every turn and the
update after it, so 10 is printed and the loop stops before 11. The comma is
printed only when another number follows, which is why the line does not end
with one.

**Exercise 2** writes the same sequence with `while`. A `while` loop has no
place for the initialisation or the update, so the counter is created above the
loop and increased inside it; leaving the `number++` out is what would make this
loop endless.

**Exercise 3** writes the same sequence with `do while`, where the condition is
tested at the end. Both loops print 0 to 10 because the counter starts inside
the range. Started at 11, the `do while` prints 11 once and the `while` prints
nothing, which is the difference the two constructs exist for.

**Exercise 4** tests `number % 3 == 0 && number % 4 == 0` for every number from
0 to 100. Nine numbers pass: 0 and the eight multiples of 12 below 100. Zero is
in the list because it divides by both 3 and 4 with no remainder. The program
also builds the same list with the single test `number % 12 == 0` and compares
the two strings, which come out equal.

**Exercise 5** answers the question on the sheet. The condition `Result >= 0`
is true whenever `Result` is zero or more, and the only statement in the body
adds one, so the condition is true again on every turn: the loop has no exit
that the code asks for. `Result` is not declared on the sheet either, so the
snippet does not compile as it stands. With `int result = 0;` added, the loop
does stop - after 2,147,483,648 turns - because the `int` wraps from
2,147,483,647 to -2,147,483,648, which is the only value that makes the
condition false. That is an overflow, not a loop condition: with `long` or
`decimal` the same loop would run until that type wrapped too, which is beyond
any real run. The repair is a bound in the condition, as in the second half of
the program.

**Exercise 6** puts the four data members in private fields and sets them in
the constructor `Car(string make, string model, string colour, string
registrationNumber)`. `RegistrationNumber` has a `get` accessor and no `set`,
so `car.RegistrationNumber = "AAA111";` does not compile:

```text
error CS0200: Property or indexer 'ProgrammingBasicsLab.Exercise06.Car.RegistrationNumber' cannot be assigned to -- it is read only
```

`Make` is writable, but its `set` runs the value through
`string.IsNullOrWhiteSpace`, so an empty string, a string of spaces or `null`
leaves the old make in place. `Describe()` returns the four values as one
string.

**Exercise 7** is the calculator. The operator is checked with `if`/`else` in
both modes, because one character out of four is cheaper to check than to
catch. After that the two modes take different routes:

| Mechanism | Where | What it catches |
| --- | --- | --- |
| Prevention with if/else | `CalculateWithPrevention` | `decimal.TryParse` fails for a word, and `second == 0` is refused before the division happens. |
| `try`/`catch` | `CalculateWithExceptions` | `10 / 0` throws `DivideByZeroException`, which is caught and reported. |
| `try`/`catch`/`finally` | the same `try` block | the `finally` line runs after every attempt, whether the sum worked or not. |
| Multiple catch types | the four `catch` clauses | `DivideByZeroException`, `FormatException` (a word), `OverflowException` (a number too large for `decimal`), and `Exception` for anything else. |

The operands are `decimal` rather than `double` on purpose. With `double`,
`10 / 0` returns `Infinity` and does not throw, so the `catch` in the lecture's
example would never run; `decimal` throws `DivideByZeroException`, which is the
behaviour the Topic 7 slides describe. `decimal` is also exact for values with
a fixed number of decimal places, which suits a calculator.

The `goto Start` of the lab sheet's sample is replaced by a `while (true)` loop
that returns to the top by finishing the round, and leaves by breaking when `q`
is typed. It is the same control flow without a jump that can skip the
initialisation of a variable.

## Checks

Every program was built and run before the work was handed in, and the output
in the report is the output of these runs. The two claims that are easy to get
wrong were checked separately:

| Claim | How it was checked | Result |
| --- | --- | --- |
| `RegistrationNumber` cannot be written to | A file that assigns to it was compiled with `Car.cs`. | `error CS0200 ... it is read only` |
| The Exercise 5 loop stops only through overflow | The loop was run with a `long` turn counter beside the `int`. | 2,147,483,648 turns, `Result` = -2,147,483,648 |
