using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProtoWeb.Pages.ProStats;

namespace ProtoWeb.Models
{
    
    public class ProStatsRepository
    {
        private List<ProStatisticsModel> PSAverages { get; }

        public ProStatsRepository()
        {
            PSAverages = new List<ProStatisticsModel>();
            PSAverages.Add(new ProStatisticsModel(){ScoringAverage = 71.3, DrivingDistance = 295.4, FairwayAverage = 58.9, GreenInRegAverage = 66.6, ScramblingAverage = 57.1});
        }

        public IEnumerable<ProStatisticsModel> GetAllPSAverages()
        {
            return PSAverages.ToList();
        }
    }
}
