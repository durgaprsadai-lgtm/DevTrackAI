using DevTrackAI.Data;
using DevTrackAI.Models;
using Microsoft.AspNetCore.Mvc;

namespace DevTrackAI.Controllers
{
    public class JobApplicationController : Controller
    {
        private readonly AppDbContext _context;

        public JobApplicationController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var jobs = _context.JobApplications.ToList();
            return View(jobs);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(JobApplication job)
        {
            if (ModelState.IsValid)
            {
                _context.JobApplications.Add(job);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }

            return View(job);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var job = _context.JobApplications.Find(id);

            if (job == null)
                return NotFound();

            return View(job);
        }

        [HttpPost]
        public IActionResult Edit(JobApplication job)
        {
            if (ModelState.IsValid)
            {
                _context.JobApplications.Update(job);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }

            return View(job);
        }

        public IActionResult Delete(int id)
        {
            var job = _context.JobApplications.Find(id);

            if (job != null)
            {
                _context.JobApplications.Remove(job);
                _context.SaveChanges();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}