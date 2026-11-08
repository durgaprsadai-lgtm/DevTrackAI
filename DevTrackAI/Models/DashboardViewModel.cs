namespace DevTrackAI.Models
{
    public class DashboardViewModel
    {
        public int TotalCourses { get; init; }

        public int TotalLearningHours { get; init; }

        public double AverageProgress { get; init; }

        public int TotalJobs { get; init; }

        public int TotalCertifications { get; init; }

        public int AppliedJobs { get; init; }

        public int InterviewingJobs { get; init; }

        public int SelectedJobs { get; init; }

        public int RejectedJobs { get; init; }
    }
}
