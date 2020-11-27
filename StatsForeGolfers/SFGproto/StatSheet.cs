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

        public int TotalFairWayStrokes { get; set; }
        public int FairWayHit { get; set; }
        public int FairWayMissLeft { get; set; }
        public int FairWayMissRight { get; set; }

        public bool Scramble { get; set; }

        public double PercentageCalculator(int number,int totalNumber)
        {
            double result = 0;
            if (totalNumber != 0 && number != 0)
            {
                result = (number / totalNumber);
            }

            return result;
        }

        public override string ToString()
        {
            string output = "YOUR STATS";
            for (int i = 0; i < TotalHits; i++)
            {
                // Fairway hits
                output += $"\nFairway Hits: {PercentageCalculator(FairWayHit, TotalFairWayStrokes) * 100}%";
                // Fairway misses
                output += $"\nFairway Misses: {PercentageCalculator(FairWayMissLeft, FairWayMissLeft + FairWayMissRight) * 100}%";
                // Green hits
                output += $"\nGreen Hits: {PercentageCalculator(GreenHit, TotalGreenStrokes) * 100}%";
                // Green misses
                output += $"\nGreen Misses: {PercentageCalculator(GreenMissLeft, GreenMissLeft + GreenMissRight) * 100}%";
            }
            return output;
        }
    }
}
