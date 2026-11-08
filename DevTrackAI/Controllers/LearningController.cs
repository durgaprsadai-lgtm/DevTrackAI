using DevTrackAI.Data;
using DevTrackAI.Models;
using Microsoft.AspNetCore.Mvc;

namespace DevTrackAI.Controllers
{
    public class LearningController : Controller
    {
        private readonly AppDbContext _context;

        public LearningController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var courses = _context.Learnings.ToList();
            return View(courses);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Learning learning)
        {
            if (ModelState.IsValid)
            {
                _context.Learnings.Add(learning);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }

            return View(learning);
        }

        // EDIT GET
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var course = _context.Learnings.Find(id);

            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        // EDIT POST
        [HttpPost]
        public IActionResult Edit(Learning learning)
        {
            if (ModelState.IsValid)
            {
                _context.Learnings.Update(learning);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }

            return View(learning);
        }
    }
}