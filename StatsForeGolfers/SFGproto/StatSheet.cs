using System;
using System.Collections.Generic;
using System.Text;

namespace SFGproto
{
    class StatSheet : IStatistics
    {
        public int TotalHits { get; set; }
        public int TotalGreenHits { get; set; }
        public bool GreenHit { get; set; }
        public bool GreenMissRight { get; set; }
        public bool GreenMissLeft { get; set; }
        // If green miss---> did it hit Bunker, rough or French
        public bool Bunker { get; set; }
        public bool Rough { get; set; }
        public bool French { get; set; }
        public int FairWayHit { get; set; }
        public bool FairWayMissLeft { get; set; }
        public bool FairWayMissRight { get; set; }
        public bool Scramble { get; set; }
        public int TotalMisses { get; set; }

        public double FairWayHits(int hits,int totalFairWayHits)
        {
            FairWayHit = hits;
            if (totalFairWayHits != 0 && hits != 0)
            {
                hits = (totalFairWayHits / hits);
            }
            return hits;
        }
        public double FairWayMisses(int misses,int totalFairWayHits)
        {
             
            if (totalFairWayHits != 0 && misses != 0)
            {
                misses = (misses / totalFairWayHits);
            }
            return misses;
        }

        public double FairWayMissesLeft(int misses,int totalFairWayHits)
        {
            
            if (totalFairWayHits != 0 && misses != 0)
            {
                misses = (misses / TotalHits);
            }
            return misses;
        }

        public double FairWayMissesRight(int misses, int totalFairWayHits)
        {
            if (totalFairWayHits != 0 && misses != 0)
            {
                misses = (misses / totalFairWayHits);
            }
            return misses;
        }

        public double GreenHits(int hits, int totalGreenHits)
        {
            if (totalGreenHits != 0 && hits != 0)
            {
                hits = (totalGreenHits / hits);
            }
            return hits;
        }
        public double GreenMisses(int misses, int totalGreenHits)
        {
           
            if (totalGreenHits != 0 && misses != 0)
            {
                misses = (misses / totalGreenHits);
            }
            return misses;
        }

        public double GreenMissesLeft(int misses, int totalGreenHits)
        {
            
            if (totalGreenHits != 0 && misses != 0)
            {
                misses = (misses / totalGreenHits);
            }
            return misses;
        }

        public double GreenMissesRight(int misses, int totalGreenHits)
        {
            if (totalGreenHits != 0 && misses != 0)
            {
                misses = (misses / totalGreenHits);
            }
            return misses;
        }

        public double ScrambleIn(int scrambleIn,int totalMisses)
        {
            if (totalMisses != 0 && totalMisses <= 18)
            {
                scrambleIn = scrambleIn / totalMisses;
            }
            return scrambleIn;
        }

    }
}
