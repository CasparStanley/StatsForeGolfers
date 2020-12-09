using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProtoWeb.Models;

namespace ProtoWeb.Pages.ProStats
{
    public class ProStatisticsModel : PageModel
    {
        public double ScoringAverage { get; set; }
        public double DrivingDistance { get; set; }
        public double FairwayAverage { get; set; }
        public double GreenInRegAverage { get; set; }
        public double ScramblingAverage { get; set; }
        

        // Should not be using a constructor
        //public ProStatisticsModel(double scoringAverage, double drivingDistance, double fairwayAverage, double greenInRegAverage, double scramblingAverage)
        //{
        //    ScoringAverage = scoringAverage;
        //    DrivingDistance = drivingDistance;
        //    FairwayAverage = fairwayAverage;
        //    GreenInRegAverage = greenInRegAverage;
        //    ScramblingAverage = scramblingAverage;
        //}

        public override string ToString()
        {
            return $"{nameof(ScoringAverage)}: {ScoringAverage}, {nameof(DrivingDistance)}: {DrivingDistance}, {nameof(FairwayAverage)}: {FairwayAverage}, {nameof(GreenInRegAverage)}: {GreenInRegAverage}, {nameof(ScramblingAverage)}: {ScramblingAverage}";
        }

        private ProStatsRepository repo;
        public List<ProStatisticsModel> PSAverages { get; private set; }

        public ProStatisticsModel()
        {
            repo = new ProStatsRepository();
        }
        
        public void OnGet()
        {
            PSAverages = (List<ProStatisticsModel>)repo.GetAllPSAverages();
        }
    }
}
