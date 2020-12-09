using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ProtoWeb.Pages.ProStats
{
    public class IndexModel : PageModel
    {
        public double ScoringAverage { get; set; }
        public double DrivingDistance { get; set; }
        public double FairwayAverage { get; set; }
        public double GreenInRegAverage { get; set; }
        public double ScramblingAverage { get; set; }

        public IndexModel(double scoringAverage, double drivingDistance, double fairwayAverage, double greenInRegAverage, double scramblingAverage)
        {
            ScoringAverage = scoringAverage;
            DrivingDistance = drivingDistance;
            FairwayAverage = fairwayAverage;
            GreenInRegAverage = greenInRegAverage;
            ScramblingAverage = scramblingAverage;
        }

        public override string ToString()
        {
            return $"{nameof(ScoringAverage)}: {ScoringAverage}, {nameof(DrivingDistance)}: {DrivingDistance}, {nameof(FairwayAverage)}: {FairwayAverage}, {nameof(GreenInRegAverage)}: {GreenInRegAverage}, {nameof(ScramblingAverage)}: {ScramblingAverage}";
        }

        public void OnGet()
        {
        }
    }
}
