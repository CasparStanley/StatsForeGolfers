using System;
using System.Collections.Generic;
using System.Text;

namespace SFGproto
{
    interface IStatistics
    {
        public double GreenHits(int hits);
        public double GreenMisses(int misses);
        public double GreenMissesLeft(int misses);
        public double GreenMissesRight(int misses);
        public double ScrambleIn(int scrambleIn);
    }
}
