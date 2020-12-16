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

        public List<Models.ProStats> ProStatses { get; set; }

        public ProStatisticsModel()
        {
            
        }
        
        public void OnGet()
        {
            ProStatses = ProStatsRepository.Instance.GetAllProStats();
        }
    }
}
