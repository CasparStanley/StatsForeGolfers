using System;
using System.Collections.Generic;
using System.Text;
using ProtoWeb.Models;

namespace ProtoWeb.Interfaces
{
    public interface IStatistics
    {
        public StatSheet GetSheet();
        public void CreateSheet(StatSheet sheet);
        public void UpdateSheet(StatSheet sheet, User user);
        public double PercentageCalculator(double number, double totalNumber);
    }
}
