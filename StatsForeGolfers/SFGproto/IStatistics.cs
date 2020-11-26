using System;
using System.Collections.Generic;
using System.Text;

namespace SFGproto
{
    interface IStatistics
    {
        public double GreenHits(double hits);
        public double GreenMisses(double misses);
        public double MissLeft();
        public double MissRight();
    }
}
