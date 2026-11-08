using DevTrackAI.Data;
using DevTrackAI.Models;
using Microsoft.AspNetCore.Mvc;

namespace DevTrackAI.Controllers
{
    public class InterviewQuestionController : Controller
    {
        private readonly AppDbContext _context;

        public InterviewQuestionController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(
                _context.InterviewQuestions.ToList());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(InterviewQuestion model)
        {
            if (ModelState.IsValid)
            {
                _context.InterviewQuestions.Add(model);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var question =
                _context.InterviewQuestions.Find(id);

            if (question == null)
                return NotFound();

            return View(question);
        }

        [HttpPost]
        public IActionResult Edit(InterviewQuestion model)
        {
            if (ModelState.IsValid)
            {
                _context.InterviewQuestions.Update(model);

                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        public IActionResult Delete(int id)
        {
            var question =
                _context.InterviewQuestions.Find(id);

            if (question != null)
            {
                _context.InterviewQuestions.Remove(question);

                _context.SaveChanges();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}