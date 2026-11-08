using DevTrackAI.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DevTrackAI.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Learning> Learnings { get; set; }
        public DbSet<JobApplication> JobApplications { get; set; }
        public DbSet<Certification> Certifications { get; set; }
        public DbSet<InterviewQuestion> InterviewQuestions { get; set; }
    }
}