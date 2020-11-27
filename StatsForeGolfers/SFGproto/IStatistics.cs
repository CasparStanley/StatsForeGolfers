using System;
using System.Collections.Generic;
using System.Text;

namespace SFGproto
{
    interface IStatistics
    {
        public double GreenHits(int hits,int totalGreenHits);
        public double GreenMisses(int misses, int totalGreenHits);
        public double GreenMissesLeft(int misses, int totalGreenHits);
        public double GreenMissesRight(int misses, int totalGreenHits);
        public double ScrambleIn(int scrambleIn, int totalMisses);
    }
}
