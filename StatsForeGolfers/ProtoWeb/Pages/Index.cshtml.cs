using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProtoWeb.Helpers;

namespace ProtoWeb.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            StatSheet sh = new StatSheet();
            sh.FairWayHit = 2;
            sh.Rough = false;
            sh.ScrambleHit = 1;
            JsonFileWriterStats.WriteToJson(sh, "testJsonFile.json");
        }
    }
}
