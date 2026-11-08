using DevTrackAI.Data;
using DevTrackAI.Models;
using Microsoft.AspNetCore.Mvc;

namespace DevTrackAI.Controllers
{
    public class CertificationController : Controller
    {
        private readonly AppDbContext _context;

        public CertificationController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var certifications =
                _context.Certifications.ToList();

            return View(certifications);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Certification certification)
        {
            if (ModelState.IsValid)
            {
                _context.Certifications.Add(certification);

                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }

            return View(certification);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var certification =
                _context.Certifications.Find(id);

            if (certification == null)
                return NotFound();

            return View(certification);
        }

        [HttpPost]
        public IActionResult Edit(Certification certification)
        {
            if (ModelState.IsValid)
            {
                _context.Certifications.Update(certification);

                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }

            return View(certification);
        }

        public IActionResult Delete(int id)
        {
            var certification =
                _context.Certifications.Find(id);

            if (certification != null)
            {
                _context.Certifications.Remove(certification);

                _context.SaveChanges();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
