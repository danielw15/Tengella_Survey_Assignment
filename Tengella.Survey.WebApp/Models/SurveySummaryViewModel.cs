namespace Tengella.Survey.WebApp.Models
{
    public class SurveySummaryViewModel
    {
        public int SurveyObjectId { get; set; }
        public string SurveyTitle { get; set; }
        public string SurveyDescription { get; set; }
        public int TotalSubmissions { get; set; }
        public double AverageAnswersPerSubmission { get; set; }
    }
}