using System.ComponentModel.DataAnnotations;

namespace DevTrackAI.Models
{
    public class JobApplication
    {
        public int Id { get; set; }

        [Required]
        public string CompanyName { get; set; } = string.Empty;

        [Required]
        public string Position { get; set; } = string.Empty;

        [Required]
        public string Status { get; set; } = string.Empty;

        public DateTime AppliedDate { get; set; } = DateTime.Now;
    }
}