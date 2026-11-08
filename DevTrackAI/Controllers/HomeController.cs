using DevTrackAI.Data;
using DevTrackAI.Models;
using Microsoft.EntityFrameworkCore;
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
            var jobStatuses = _context.JobApplications
                .AsNoTracking()
                .Select(job => job.Status)
                .ToList();

            var model = new DashboardViewModel
            {
                TotalCourses = _context.Learnings.Count(),
                TotalLearningHours = _context.Learnings
                    .Sum(learning => (int?)learning.HoursSpent) ?? 0,
                AverageProgress = _context.Learnings
                    .Average(learning => (double?)learning.ProgressPercentage) ?? 0,
                TotalJobs = jobStatuses.Count,
                TotalCertifications = _context.Certifications.Count(),
                AppliedJobs = jobStatuses.Count(status => HasStatus(status, "Applied")),
                InterviewingJobs = jobStatuses.Count(status =>
                    HasStatus(status, "Interviewing") || HasStatus(status, "Interview Scheduled")),
                SelectedJobs = jobStatuses.Count(status => HasStatus(status, "Selected")),
                RejectedJobs = jobStatuses.Count(status => HasStatus(status, "Rejected"))
            };

            return View(model);
        }

        private static bool HasStatus(string? status, string expectedStatus)
        {
            return string.Equals(
                status?.Trim(),
                expectedStatus,
                StringComparison.OrdinalIgnoreCase);
        }
    }
}