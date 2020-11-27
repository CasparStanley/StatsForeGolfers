using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Text;

namespace SFGproto
{
    class Hole : IStatistics
    {
        /// <summary>
        /// A Course contains 18 Holes which can contain different kind of Par(The amount of shots you have) 
        /// The Hole Class is going to be a super class which Different kind of "Par Hole" Classes are going to inherit from.
        /// </summary>
        public int Par { get; set; }
        public int Length { get; set; }
        public int Handicap { get; set; }
        public  int TotalHits { get; set; }
        public bool GreenHit { get; set; }     
        public bool GreenMissRight { get; set; }
        public bool GreenMissLeft { get; set; }
        // If green miss---> did it hit Bunker, rough or French
        public bool Bunker { get; set; }
        public bool Rough { get; set; }
        public bool French { get; set; }
        public bool Scramble { get; set; }
        public int TotalMisses { get; set; }

        public Hole()
        {
            
        }
        public Hole(int par, int length, int handicap, int totalHits, bool greenHit, bool greenMissRight, bool greenMissLeft, bool bunker, bool rough, bool french, bool scramble, int totalMisses)
        {
            Par = par;
            Length = length;
            Handicap = handicap;
            TotalHits = totalHits;
            GreenHit = greenHit;
            GreenMissRight = greenMissRight;
            GreenMissLeft = greenMissLeft;
            Bunker = bunker;
            Rough = rough;
            French = french;
            Scramble = scramble;
            TotalMisses = totalMisses;
        }
        public double GreenHits(int hits)
        {
            if (TotalHits != 0 && hits != 0)
            {
                hits = (TotalHits / hits);
            }
            return hits;
        }

        // Method Section
        public double GreenMisses(int misses)
        {
            TotalMisses += misses;
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
