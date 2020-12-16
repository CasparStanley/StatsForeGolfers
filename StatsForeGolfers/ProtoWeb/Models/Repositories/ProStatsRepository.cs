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
        private static ProStatsRepository _instance;
        public static ProStatsRepository Instance
        {
            get
            {
                return _instance ?? (_instance = new ProStatsRepository());
            }
        }


        public ProStatsRepository()
        {
            proStats = new List<ProStats>();
            proStats.Add(new ProStats(){Id = 1,Name = "PGA Tour", ScoringAverage = 71.3, DrivingDistance = 295, FairwayAverage = 58.9, GreenInRegAverage = 66.6, ScramblingAverage = 57.1});
        }

        public void AddProStats(ProStats pr)
        {
            List<int> proStatsIds = new List<int>();

            foreach (var pro in proStats)
            {
                proStatsIds.Add(pro.Id);
            }

            if (proStatsIds.Count !=0)
            {
                int start = proStatsIds.Max();
                pr.Id = start + 1;
            }
            else
            {
                pr.Id = 1;
            }
            proStats.Add(pr);
        }
        public List<ProStats> GetAllProStats() {
            return proStats.ToList();
        }
    }
}
