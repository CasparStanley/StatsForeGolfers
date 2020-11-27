using System;

namespace SFGproto
{
    class Program
    {
        private const string INPUT_ERROR = "\nInvalid Input. Please try again.";

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
            string name = InfoInputLoop();

            Console.WriteLine("\nHow good are you at golf? Amateur, Intermediate, Pro?");
            string skillLvl = InfoInputLoop();

            Console.WriteLine("\nWhat's your membership number?");
            string memberNo = InfoInputLoop();

            User newUser = new User() { Name = name, Status = skillLvl, MemberNo = memberNo};
            Console.WriteLine($"Awesome! Welcome to Stats Fore Golfers, {name}.");
        }

        static string InfoInputLoop()
        {
            string input;

            while (true)
            {
                input = Console.ReadLine();

                if (input.Length > 0)
                    break;
                else
                    WriteError(INPUT_ERROR);
            }

            return input;
        }

        static void InputGameStatistics()
        {
            // Tee selection
            WriteWithGolfColors($"\nTee selection");
            Console.WriteLine($"What is your Tee?");


            int currentHole = 1;

            #region COURSE CREATION
            WriteWithGolfColors($"\nCreating a new Course");

            Console.WriteLine($"What is the name of the course?");
            string courseName = InfoInputLoop();

            Console.WriteLine($"How many holes does the course have?");
            int amountOfHoles = 0;
            bool holeAmountFlow = true;
            while (holeAmountFlow)
            {
                try
                {
                    amountOfHoles = Convert.ToInt32(InfoInputLoop());
                    holeAmountFlow = false;
                }
                catch
                {
                    WriteError(INPUT_ERROR);
                }
            }

            Course newCourse = new Course(courseName);
            #endregion

            #region CREATION OF HOLES
            while (true)
            {
                WriteWithGolfColors($"\nHole {currentHole}");
                Console.WriteLine($"What is the Par of the Hole {currentHole}?");

                int currentPar = 0;
                bool holeFlow = true;

                while (holeFlow)
                {
                    bool parInputFlow = true;
                    bool holeCreationFlow = true;

                    while (parInputFlow)
                    {
                        try
                        {
                            currentPar = Convert.ToInt32(Console.ReadLine());
                            parInputFlow = false;
                        }
                        catch
                        {
                            WriteError(INPUT_ERROR);
                        }
                    }

                    while (holeCreationFlow)
                    {
                        if (currentPar >= 3 && currentPar <= 5)
                        {
                            newCourse.AddHole(currentHole, CreateHole(currentHole, currentPar, 0, 0));
                            holeCreationFlow = false;
                            holeFlow = false;
                        }
                        else
                        {
                            WriteError(INPUT_ERROR);
                            holeCreationFlow = false;
                            currentPar = 4;
                        }
                    }
                }

                if (currentHole >= amountOfHoles)
                    break;
                else
                    currentHole++;
            }
            #endregion

            #region TEE SELECTION
            string currentTee;
            while(true)
            {
                currentTee = Console.ReadLine();
                if (currentTee.Length > 0)
                    break;
                else
                    WriteError(INPUT_ERROR);
            }
            #endregion

            WriteWithGolfColors("YOU CREATED A GOLF COURSE!");
            Console.WriteLine(newCourse.ToString());

            #region INPUT STATS
            WriteWithGolfColors("Let's now take a look how your game went.");

            #endregion
        }

        static Hole CreateHole(int holeNo, int par, int length, int hcp)
        {
            //WriteWithGolfColors($"\nFAKE CREATION OF HOLE {holeNo} - PAR: {par}");
            return new Hole(holeNo, par, length, hcp);    
        }

        static void WriteWithGolfColors(string line)
        {
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(line);
            Console.WriteLine();
            Console.ResetColor();
            Console.WriteLine();
        }
        static void WriteError(string line)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(line);
            Console.WriteLine();
            Console.ResetColor();
            Console.WriteLine();
        }
    }
}
