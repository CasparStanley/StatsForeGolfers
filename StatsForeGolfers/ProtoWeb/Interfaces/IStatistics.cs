using System;
using System.Collections.Generic;
using System.Text;

namespace ProtoWeb.Interfaces
{
    public interface IStatistics
    {
        public StatSheet GetSheet();
        public void CreateSheet(StatSheet sheet);
        public void UpdateSheet(StatSheet sheet);
        public double PercentageCalculator(double number, double totalNumber);
    }
}
