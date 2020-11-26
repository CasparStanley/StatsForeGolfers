using System;

namespace SFGproto
{
    class Program
    {
        private const string INPUT_ERROR = "\nInvalid Input. Please try again.\n";

        static void Main(string[] args)
        {
            Console.Title = "STATS FORE GOLFERS - PROTOTYPE";

            Console.WriteLine("\n\nHello user!");
            UserCreation();
            InputGameStatistics();
        }

        static void UserCreation()
        {
            Console.WriteLine("\nPlease write your name:");

            string name;
            while (true)
            {
                name = Console.ReadLine();

                if (name.Length > 0)
                    break;
                else
                    WriteError(INPUT_ERROR);
            }

            Console.WriteLine("\nHow good are you at golf? Amateur, Intermediate, Pro?");

            string skillLevel;
            while (true)
            {
                skillLevel = Console.ReadLine();

                if (skillLevel.Length > 0)
                    break;
                else
                    WriteError(INPUT_ERROR);
            }


            Console.WriteLine($"Awesome! Welcome to Stats Fore Golfers, {name}.");
        }
        static void InputGameStatistics()
        {
            int currentHole = 1;

            while (true)
            {
                WriteWithGolfColors($"\nHole {currentHole}\n");
                Console.WriteLine($"What was your Tee on Hole {currentHole}?");

                string currentTee;
                bool holeFlow = true;

                while (holeFlow)
                {
                    currentTee = Console.ReadLine();
                    if (currentTee.Length > 0)
                    {
                        CreateHole(currentHole, currentTee);
                        holeFlow = false;
                    }
                    else
                        WriteError(INPUT_ERROR);
                }

                if (currentHole >= 18)
                    break;
                else
                    currentHole++;
            }
        }

        static void CreateHole(int holeNo, string tee)
        {
            WriteWithGolfColors($"\nFAKE CREATION OF HOLE {holeNo} - TEE: {tee}");
        }

        static void WriteWithGolfColors(string line)
        {
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(line);
            Console.ResetColor();
        }
        static void WriteError(string line)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(line);
            Console.ResetColor();
        }
    }
}
