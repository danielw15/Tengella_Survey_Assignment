namespace Tengella.Survey.WebApp.Models
{
    public class SubmissionViewModel
    {
        public int SubmissionId { get; set; }
        public int? SurveyObjectId { get; set; } = 0;
        public DateTime SubmissionDate { get; set; }
        public List<AnswerViewModel> Answers { get; set; }

    }
}
