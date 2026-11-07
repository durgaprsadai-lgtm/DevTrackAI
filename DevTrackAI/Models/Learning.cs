using System.ComponentModel.DataAnnotations;

namespace DevTrackAI.Models
{
    public class Learning
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string CourseName { get; set; }

        [Required]
        public string Platform { get; set; }

        [Range(0, 100)]
        public int ProgressPercentage { get; set; }

        public int HoursSpent { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}