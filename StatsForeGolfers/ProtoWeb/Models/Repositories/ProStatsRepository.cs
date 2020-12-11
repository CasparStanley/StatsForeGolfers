using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProtoWeb.Pages.ProStats;

namespace ProtoWeb.Models
{
    
    public class ProStatsRepository
    {
        private List<ProStats> proStats { get; }

        public ProStatsRepository()
        {
            proStats = new List<ProStats>();
            proStats.Add(new ProStats(){Name = "PGA Tour", ScoringAverage = 71.3, DrivingDistance = 295, FairwayAverage = 58.9, GreenInRegAverage = 66.6, ScramblingAverage = 57.1});
        }

        public IEnumerable<ProStats> GetAllProStats()
        {
            return proStats.ToList();
        }
    }
}
