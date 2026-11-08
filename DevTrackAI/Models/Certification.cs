using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DevTrackAI.Models
{
    public class Certification
    {
        public int Id { get; set; }

        [Required]
        public string CertificationName { get; set; } = string.Empty;

        public string Provider { get; set; } = string.Empty;

        public DateTime ExamDate { get; set; }

        public int ProgressPercentage { get; set; }

        public string Status { get; set; } = string.Empty;

        [NotMapped]
        public int DaysRemaining => (ExamDate.Date - DateTime.Today).Days;
    }
}