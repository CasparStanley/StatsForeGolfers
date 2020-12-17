using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProtoWeb.Interfaces;
using ProtoWeb.Models;
using ProtoWeb.Helpers;

namespace ProtoWeb.Pages
{
    public class ShowResultsModel : PageModel
    {
        private IStatistics statistics;
        private ICourses courses;

        public StatSheet MyStatSheet { get; private set; }
        public List<Models.ProStats> ProStatses { get; set; }
        public Models.ProStats CurrentProStatsShown { get; set; }

        public ShowResultsModel(IStatistics statsRepo, ICourses courseRepo)
        {
            statistics = statsRepo;
            courses = courseRepo;

            MyStatSheet = statistics.GetSheet();

            ProStatses = ProStatsRepository.Instance.GetAllProStats();

            // Simply show the first one in the list for now.
            CurrentProStatsShown = ProStatses[0];
        }

        public User CurrentUser { get; private set; }
        public Course CurrentCourse { get; private set; }
        public Dictionary<int, Hole> Holes { get; private set; }

        [BindProperty(SupportsGet = true)]
        public string FilterCriteria { get; set; }

        public IActionResult OnGet()
        {
            CurrentUser = UserRepository.Instance.Get();
            CurrentCourse = courses.GetCourse(UserRepository.Instance.Get().CurrentCourseId);
            Holes = courses.AllHoles(UserRepository.Instance.Get().CurrentCourseId);

            return Page();
        }

        public void OnPost()
        {
            CurrentUser = UserRepository.Instance.Get();
            CurrentCourse = courses.GetCourse(UserRepository.Instance.Get().CurrentCourseId);
            Holes = courses.AllHoles(UserRepository.Instance.Get().CurrentCourseId);

            statistics.UpdateSheet(MyStatSheet);
        }

        public int FairwayHit()
        {
            return (int)(MyStatSheet.PercentageCalculator(MyStatSheet.FairWayHit, MyStatSheet.TotalFairwayStrokes) * 100);
        }

        public int FairwayMiss(bool left)
        {
            if (left)
                return (int)(MyStatSheet.PercentageCalculator(MyStatSheet.FairWayMissLeft, MyStatSheet.TotalFairwayStrokes) * 100);
            else
                return (int)(MyStatSheet.PercentageCalculator(MyStatSheet.FairWayMissRight, MyStatSheet.TotalFairwayStrokes) * 100);
        }

        public int GreenHit()
        {
            return (int)(MyStatSheet.PercentageCalculator(MyStatSheet.GreenHit, MyStatSheet.TotalGreenStrokes) * 100);
        }

        public int GreenMiss(bool left)
        {
            if (left)
                return (int)(MyStatSheet.PercentageCalculator(MyStatSheet.GreenMissLeft, MyStatSheet.TotalGreenStrokes) * 100);
            else
                return (int)(MyStatSheet.PercentageCalculator(MyStatSheet.GreenMissRight, MyStatSheet.TotalGreenStrokes) * 100);
        }

        public int Scramble(bool hit)
        {
            if (hit)
                return (int)(MyStatSheet.PercentageCalculator(MyStatSheet.ScrambleHit, MyStatSheet.TotalScrambleStrokes) * 100);
            else
                return (int)(MyStatSheet.PercentageCalculator(MyStatSheet.ScrambleMiss, MyStatSheet.TotalScrambleStrokes) * 100);
        }
    }
}
