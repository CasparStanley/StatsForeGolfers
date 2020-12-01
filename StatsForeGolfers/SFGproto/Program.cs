using System;

namespace SFGproto
{
    class Program
    {
        private const string INPUT_ERROR = "\nInvalid Input. Please try again.";
        private const string CALC_ERROR = "\nSomething went wrong. Please restart the program.";

        static Course currentCourse;
        static StatSheet statSheet;

        static void Main(string[] args)
        {
            Console.Title = "STATS FORE GOLFERS - PROTOTYPE";
            statSheet = new StatSheet();

            WriteWithGolfColors("\n\nHello user!", ShotType.None);
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
            WriteWithGolfColors($"\nTee selection", ShotType.None);
            Console.WriteLine($"What is your Tee?");
            string currentTee = InfoInputLoop();

            int currentHole = 1;

            #region COURSE CREATION
            WriteWithGolfColors($"\nCreating a new Course", ShotType.None);

            Console.WriteLine($"\nWhat is the name of the course?");
            string courseName = InfoInputLoop();

            Console.WriteLine($"\nHow many holes does the course have?");
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
                WriteWithGolfColors($"\nHole {currentHole}", ShotType.None);
                Console.WriteLine($"\nWhat is the Par of the Hole {currentHole}?");

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
            WriteWithGolfColors("YOU CREATED A GOLF COURSE!", ShotType.None);
            Console.WriteLine(currentCourse.ToString());
        }

        static void PlayGame()
        {
            #region INPUT STATS
            WriteWithGolfColors("Let's now play some Golf, and while playing input our stats.", ShotType.None);
            foreach(var h in currentCourse.GetHoles())
            {
                Console.WriteLine($"\nYou are now on Hole {h.Key}");
                bool hit;
                switch(h.Value.Par)
                {
                    case 3:
                        hit = HitOrMissShot(ShotType.Green);

                        if (hit == false)
                            HitOrMissShot(ShotType.Scramble);
                        break;
                    case 4:
                        HitOrMissShot(ShotType.Fairway);
                        hit = HitOrMissShot(ShotType.Green);
                        // If you miss the Green, go to Scramble
                        if (hit == false)
                            HitOrMissShot(ShotType.Scramble);
                        break;
                    case 5:
                        HitOrMissShot(ShotType.Fairway);
                        hit = HitOrMissShot(ShotType.Green);
                        // If you miss the Green, go to Scramble
                        if (hit == false)
                            HitOrMissShot(ShotType.Scramble);
                        break;
                    default:
                        break;
                }
            }

            statSheet.TotalHits = statSheet.TotalGreenStrokes + statSheet.TotalFairwayStrokes;

            // WRITE YOUR STATS
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(statSheet.ToString());
            Console.ResetColor();
            Console.WriteLine();
            #endregion
        }

        // THIS WILL BECOME A TOGGLE 
        static bool HitOrMissShot(ShotType shot)
        {
            // ADD TO THE TOTAL STROKES IN THIS CATEGORY
            switch (shot)
            {
                case ShotType.Green:
                    {
                        statSheet.TotalGreenStrokes++;
                        break;
                    }
                case ShotType.Fairway:
                    {
                        statSheet.TotalFairwayStrokes++;
                        break;
                    }
                case ShotType.Scramble:
                    {
                        statSheet.TotalScrambleStrokes++;
                        break;
                    }
                default:
                    {
                        WriteError(CALC_ERROR);
                        break;
                    }
            }

            // ----------- NOW ASK IF YOU HIT OR MISSED
            WriteWithGolfColors($"{shot} Shot! - Did you Hit or miss this? H) Hit - M) Miss", shot);
            string hitOrMiss = InfoInputLoop();
            if (hitOrMiss.ToLower() == "h")
            {
                Console.WriteLine($"You hit the {shot}.");
                AddHit(shot);
                return true;
            }
            else if (shot != ShotType.Scramble)
            {
                // ----------- IF YOU MISSED LEFT OR RIGHT
                WriteWithGolfColors($"Did you miss left or right on the {shot} shot? L) Left - R) Right", shot);
                string missLeft = InfoInputLoop();
                if (missLeft.ToLower() == "l")
                {
                    AddMiss(shot, true);
                }
                else
                {
                    AddMiss(shot, false);
                }
                return false;
            }
            else
            {
                // ----------- IF YOU MISSED A SCRAMBLE
                AddMiss(shot);
                Console.WriteLine($"Logged missed {shot} shot.");
                return false;
            }
        }

        static void AddHit(ShotType shot) 
        {
            switch (shot)
            {
                case ShotType.Green:
                {
                    statSheet.GreenHit++;
                    break;
                }
                case ShotType.Fairway:
                {
                    statSheet.FairWayHit++;
                    break;
                }
                case ShotType.Scramble:
                {
                    statSheet.ScrambleHit++;
                    break;
                }
                default:
                {
                    WriteError(CALC_ERROR);
                    break;
                }
            }
        }
        static void AddMiss(ShotType shot, bool left = false) // left is set to false, making it an optional parameter.
        {
            switch (shot)
            {
                case ShotType.Green:
                    {
                        if (left)
                            statSheet.GreenMissLeft++;
                        else
                            statSheet.GreenMissRight++;
                        break;
                    }
                case ShotType.Fairway:
                    {
                        if (left)
                            statSheet.FairWayMissLeft++;
                        else
                            statSheet.FairWayMissRight++;
                        break;
                    }
                case ShotType.Scramble:
                    {
                        statSheet.ScrambleMiss++;
                        break;
                    }
                default:
                    {
                        WriteError(CALC_ERROR);
                        break;
                    }
            }
        }

        static Hole CreateHole(int holeNo, int par, int length, int hcp)
        {
            //WriteWithGolfColors($"\nFAKE CREATION OF HOLE {holeNo} - PAR: {par}");
            return new Hole(holeNo, par, length, hcp);    
        }

        static void WriteWithGolfColors(string line, ShotType shot)
        {
            switch (shot)
            {
                case ShotType.Green:
                    {
                        Console.BackgroundColor = ConsoleColor.DarkGreen;
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        break;
                    }
                case ShotType.Fairway:
                    {
                        Console.BackgroundColor = ConsoleColor.DarkBlue;
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        break;
                    }
                case ShotType.Scramble:
                    {
                        Console.BackgroundColor = ConsoleColor.Yellow;
                        Console.ForegroundColor = ConsoleColor.Black;
                        break;
                    }
                default:
                    {
                        Console.BackgroundColor = ConsoleColor.DarkMagenta;
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        break;
                    }
            }

            Console.WriteLine("\n"+line);
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
