﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SFGproto
{
    class Par4 : Hole
    {
        public int FairWayHit { get; set; }
        public bool FairWayMissLeft { get; set; }
        public bool FairWayMissRight { get; set; }
        public Par4(int par, int length, int handicap)
            : base(par, length, handicap)
        {
            
        }
        public double FairWayHits(int hits)
        {
            if (TotalHits != 0 && hits != 0)
            {
                hits = (TotalHits / hits);
            }
            return hits;
        }
        public double FairWayMisses(int misses)
        {
            TotalMisses += misses;
            if (TotalHits != 0 && misses != 0)
            {
                misses = (misses / TotalHits);
            }
            return misses;
        }

        public double FairWayMissesLeft(int misses)
        {
            TotalMisses += misses;
            if (TotalHits != 0 && misses != 0)
            {
                misses = (misses / TotalHits);
            }
            return misses;
        }

        public double FairWayMissesRight(int misses)
        {
            TotalMisses += misses;
            if (TotalHits != 0 && misses != 0)
            {
                misses = (misses / TotalHits);
            }
            return misses;
        }
    }
}