using System;
using System.Collections.Generic;
using System.Text;

namespace SFGproto
{
    interface IStatistics
    {
        public double GreenHits(double hits);
        public double GreenMiss(double hits);
        public double MissLeft();
        public double MissRight();
    }
}
