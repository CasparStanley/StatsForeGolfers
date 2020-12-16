using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProtoWeb.Pages.ProStats;

namespace ProtoWeb.Models
{
    
    public class ProStatsRepository
    {
        private static ProStatsRepository _instance;

        private List<ProStats> proStats = new List<ProStats>();

        public static ProStatsRepository Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ProStatsRepository();
                }
                return _instance;
            }
        }

        private ProStatsRepository()
        {
        }

        public void AddProStats(ProStats pr)
        {
            if (!(proStats.Count >= 2))//begrænser listen til 2 
            {
                List<int> proStatsIds = new List<int>();

                foreach (var pro in proStats) {
                    proStatsIds.Add(pro.Id);
                }

                if (proStatsIds.Count != 0) {
                    int start = proStatsIds.Max();
                    pr.Id = start + 1;
                }
                else {
                    pr.Id = 1;
                }
                proStats.Add(pr);
            }
           
        }
        public List<ProStats> GetAllProStats() {
            return proStats.ToList();
        }
    }
}
