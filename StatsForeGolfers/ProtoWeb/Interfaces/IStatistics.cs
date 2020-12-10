using System;
using System.Collections.Generic;
using System.Text;

namespace ProtoWeb.Interfaces
{
    public interface IStatistics
    {
        public StatSheet Sheet();
        public double PercentageCalculator(double number, double totalNumber);
    }
}
