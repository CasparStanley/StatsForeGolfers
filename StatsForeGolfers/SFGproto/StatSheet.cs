namespace SFGproto
{
    class StatSheet : IStatistics
    {
        public int TotalHits { get; set; }
        public int TotalMisses { get; set; }

        public int TotalGreenStrokes { get; set; }
        public int GreenHit { get; set; }
        public int GreenMissRight { get; set; }
        public int GreenMissLeft { get; set; }
        // If green miss---> did it hit Bunker, rough or French

        public bool Bunker { get; set; }
        public bool Rough { get; set; }
        public bool French { get; set; }

        public int TotalFairwayStrokes { get; set; }
        public int FairWayHit { get; set; }
        public int FairWayMissLeft { get; set; }
        public int FairWayMissRight { get; set; }

        public int TotalScrambleStrokes { get; set; }
        public int ScrambleHit { get; set; }
        public int ScrambleMiss { get; set; }

        public double PercentageCalculator(double number,double totalNumber)
        {
            double result = 0;
            if (totalNumber != 0 && number != 0)
            {
                result = number / totalNumber;
            }

            return result;
        }

        public override string ToString()
        {
            string output = "YOUR STATS";
            //for (int i = 0; i < TotalHits; i++) // ForLoop Doesnt make sense since the value would be the same on every hole since FairWayHit is a constant at the moment
            // We Could make it so it calculate precentege for every hole If we set Number and totalNumber to 0 every time we start a new hole.
            {
                // Fairway hits
                output += $"\nFairway Hits: {PercentageCalculator(FairWayHit, TotalFairwayStrokes) * 100}%\n";
                // Fairway misses Left
                output += $"\nFairway Misses Left: {PercentageCalculator(FairWayMissLeft, TotalFairwayStrokes) * 100}%\n";
                //FairWay misses Right
                output += $"\nFairway MissesRight: {PercentageCalculator(FairWayMissRight, TotalFairwayStrokes) * 100}%\n";
                // Green hits
                output += $"\nGreen Hits: {PercentageCalculator(GreenHit, TotalGreenStrokes) * 100}%\n";
                // Green misses Left
                output += $"\nGreen Misses Left: {PercentageCalculator(GreenMissLeft, TotalGreenStrokes) * 100}%\n";
                // Green misses Left
                output += $"\nGreen Misses Right: {PercentageCalculator(GreenMissRight, TotalGreenStrokes) * 100}%\n";
                // Scramble in's
                output += $"\nScramble in's: {PercentageCalculator(ScrambleHit, TotalScrambleStrokes) * 100}%\n";
                // Scramble out's
                output += $"\nScramble out's: {PercentageCalculator(ScrambleMiss, TotalScrambleStrokes) * 100}%\n";
            }
            return output;
        }
    }
}
