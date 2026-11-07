using DevTrackAI.Data;
using Microsoft.AspNetCore.Mvc;

namespace DevTrackAI.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            ViewBag.TotalCourses = _context.Learnings.Count();

            ViewBag.TotalHours =
                _context.Learnings.Sum(x => x.HoursSpent);

            ViewBag.AverageProgress =
                _context.Learnings.Any()
                ? _context.Learnings.Average(x => x.ProgressPercentage)
                : 0;

            return View();
        }
    }
}