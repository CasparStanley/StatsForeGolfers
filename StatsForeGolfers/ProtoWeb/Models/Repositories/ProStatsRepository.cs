using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using ProtoWeb.Helpers;
using ProtoWeb.Pages.Courses.CoursesHoles;
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
                    _instance.proStats = JsonHelper.ReadProStat("ProStatsData.json"); // Hent gemte data
                }
                return _instance;
            }
        }

        private ProStatsRepository()
        {
        }

        public void AddProStats(ProStats pr)
        {
            if (!(proStats.Count >= 2)) //begrænser listen til 2 
            {
                List<int> proStatsIds = new List<int>();

                foreach (var pro in proStats)
                {
                    proStatsIds.Add(pro.Id);
                }

                if (proStatsIds.Count != 0)
                {
                    int start = proStatsIds.Max();
                    pr.Id = start + 1;
                }
                else
                {
                    pr.Id = 1;
                }

                proStats.Add(pr);

                JsonHelper.WriteProStat(proStats, "ProStatsData.json");
            }
        }

        public ProStats GetProStats(int id)
        {
            foreach (ProStats g in proStats)
            {
                if (g.Id == id) return g;
            }
            return new ProStats();
        }

        public void UpdateProStats(ProStats eProStats)
        {
            if (eProStats != null)
            {
                foreach (ProStats e in proStats)
                {
                    if (e.Id == eProStats.Id)
                    {
                        e.Name = eProStats.Name;
                        e.ScoringAverage = eProStats.ScoringAverage;
                        e.DrivingDistance = eProStats.DrivingDistance;
                        e.FairwayAverage = eProStats.FairwayAverage;
                        e.GreenInRegAverage = eProStats.GreenInRegAverage;
                        e.ScramblingAverage = eProStats.ScramblingAverage;
                    }
                }

                JsonHelper.WriteProStat(proStats, "ProStatsData.json");
            }
        }

        public void EditProStats(ProStats edStats)
        {
            List<int> editList = new List<int>();
            foreach (var es in proStats)
            {
                editList.Add(es.Id);
            }

            if (editList.Count !=0)
            {
                int start = editList.Max();
                edStats.Id = start + 1;
            }
            else
            {
                edStats.Id = 1;
            }
            proStats.Add(edStats);
            JsonHelper.WriteProStat(proStats, "ProStatsData.json");
        }
        public List<ProStats> GetAllProStats() {
            return proStats.ToList();
        }
    }
}
