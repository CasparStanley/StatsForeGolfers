using System;

namespace SFGproto
{
    class Program
    {
        private const string INPUT_ERROR = "\nInvalid Input. Please try again.";
        static Course currentCourse;
        static StatSheet statSheet;

        static void Main(string[] args)
        {
            Console.Title = "STATS FORE GOLFERS - PROTOTYPE";
            statSheet = new StatSheet();

            Console.WriteLine("\n\nHello user!");
            UserCreation();
            CreateNewGame();
            PlayGame();
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

        static void CreateNewGame()
        {
            // Tee selection
            WriteWithGolfColors($"\nTee selection");
            Console.WriteLine($"What is your Tee?");
            string currentTee = InfoInputLoop();

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

            currentCourse = new Course(courseName);
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
                            currentCourse.AddHole(currentHole, CreateHole(currentHole, currentPar, 0, 0));
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
            WriteWithGolfColors("YOU CREATED A GOLF COURSE!");
            Console.WriteLine(currentCourse.ToString());
        }

        static void PlayGame()
        {
            #region INPUT STATS
            WriteWithGolfColors("Let's now play some Golf, and while playing input our stats.");
            foreach(var h in currentCourse.GetHoles())
            {
                Console.WriteLine($"You are now on Hole {h.Key}");
                switch(h.Value.Par)
                {
                    case 3:
                        HitOrMissGreen();
                        break;
                    case 4:
                        HitOrMissFairway();
                        HitOrMissGreen();
                        break;
                    case 5:
                        HitOrMissFairway();
                        HitOrMissGreen();
                        break;
                    default:
                        break;
                }
            }

            statSheet.TotalHits = statSheet.TotalGreenStrokes + statSheet.TotalFairWayStrokes;
            Console.WriteLine(statSheet.ToString());
            #endregion
        }

        static void HitOrMissGreen()
        {
            Console.WriteLine($"Hit or miss on this hole. Green. H) Hit - M) Miss");
            string hitOrMiss = InfoInputLoop();
            if (hitOrMiss.ToLower() == "h")
            {
                Console.WriteLine($"You hit the green.");
                statSheet.GreenHit++;
            }
            else
            {
                Console.WriteLine($"Did you miss left or right? L) Left - R) Right");
                string missLeft = InfoInputLoop();
                if (missLeft.ToLower() == "l")
                {
                    statSheet.GreenMissLeft++;
                }
                else
                {
                    statSheet.GreenMissRight++;
                }
                // NOW ASK IF YOU MISSED LEFT OR RIGHT
            }

            statSheet.TotalGreenStrokes++;
        }
        static void HitOrMissFairway()
        {
            Console.WriteLine($"Hit or miss on this hole. Fair Way. H) Hit - M) Miss");
            string hitOrMiss = InfoInputLoop();
            if (hitOrMiss.ToLower() == "h")
            {
                Console.WriteLine($"You hit the fairway.");
                statSheet.FairWayHit++;
            }
            else
            {
                Console.WriteLine($"Did you miss left or right? L) Left - R) Right");
                string missLeft = InfoInputLoop();
                if (missLeft.ToLower() == "l")
                {
                    statSheet.FairWayMissLeft++;
                }
                else
                {
                    statSheet.FairWayMissRight++;
                }
                // NOW ASK IF YOU MISSED LEFT OR RIGHT
            }

            statSheet.TotalFairWayStrokes++;
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
