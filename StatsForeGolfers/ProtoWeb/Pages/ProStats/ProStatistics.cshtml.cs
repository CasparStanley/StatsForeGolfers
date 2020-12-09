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

        private ProStatsRepository repo;
        public List<Models.ProStats> ProStatses { get; private set; }

        public ProStatisticsModel()
        {
            repo = new ProStatsRepository();
        }
        
        public void OnGet()
        {
            ProStatses = (List<Models.ProStats>)repo.GetAllProStats();
        }
    }
}
