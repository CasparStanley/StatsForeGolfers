using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Text;

namespace SFGproto
{
    class Hole : IStatistics
    {
        public int Par { get; set; }
        public int Length { get; set; }
        public int Handicap { get; set; }
        public  int TotalHits { get; set; }
        public bool GreenHit { get; set; }     
        public bool GreenMissRight { get; set; }
        public bool GreenMissLeft { get; set; }
        // If green miss did it hit Bunker, rough or French
        public bool Bunker { get; set; }
        public bool Rough { get; set; }
        public bool French { get; set; }
        public bool Scramble { get; set; }
        public int TotalMisses { get; set; }

        public double GreenHits(int hits)
        {
            if (TotalHits != 0 && hits != 0)
            {
                hits = (TotalHits / hits);
            }
            return hits;
        }

        public double GreenMisses(int misses)
        {
            if (TotalHits != 0 && misses != 0)
            {
                misses = (misses / TotalHits);
            }
            return misses;
        }

        public double GreenMissesLeft(int misses)
        {
            TotalMisses += misses;
            if (TotalHits != 0 && misses != 0)
            {
                misses = (misses / TotalHits);
            }
            return misses;
        }

        public double GreenMissesRight(int misses)
        {
            TotalMisses += misses;
            if (TotalHits != 0 && misses != 0)
            {
                misses = (misses / TotalHits);
            }
            return misses;
        }

        public double ScrambleIn(int scrambleIn)
        {
            if (TotalMisses != 0 && TotalMisses <= 18)
            {
                scrambleIn = scrambleIn / TotalMisses;
            }
            return scrambleIn;
        }

    }
}
