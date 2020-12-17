using System;
using ProtoWeb.Interfaces;

namespace ProtoWeb
{
    public class StatSheet
    {
        public int TotalScore { get; set; }
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
    }
}
