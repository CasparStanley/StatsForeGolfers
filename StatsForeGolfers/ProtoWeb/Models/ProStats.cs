using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProtoWeb.Models
{
    public class ProStats
    {
        public int Id { get; set; }
        public string Name  { get; set; }
        public double ScoringAverage { get; set; }
        public double DrivingDistance { get; set; }
        public double FairwayAverage { get; set; }
        public double GreenInRegAverage { get; set; }
        public double ScramblingAverage { get; set; }



        public override string ToString()
        {
            return $"{nameof(Name)}: {Name}, {nameof(ScoringAverage)}: {ScoringAverage}, {nameof(DrivingDistance)}: {DrivingDistance}, {nameof(FairwayAverage)}: {FairwayAverage}, {nameof(GreenInRegAverage)}: {GreenInRegAverage}, {nameof(ScramblingAverage)}: {ScramblingAverage}";
        }
    }
}
