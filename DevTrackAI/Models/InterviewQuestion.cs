using System.ComponentModel.DataAnnotations;

namespace DevTrackAI.Models
{
    public class InterviewQuestion
    {
        public int Id { get; set; }

        [Required]
        public string Category { get; set; } = string.Empty;

        [Required]
        public string Question { get; set; } = string.Empty;

        public string Difficulty { get; set; } = string.Empty;

        public string Status { get; set; } = string.Empty;

        public string Notes { get; set; } = string.Empty;
    }
}