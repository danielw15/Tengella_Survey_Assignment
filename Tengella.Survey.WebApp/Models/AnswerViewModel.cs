namespace Tengella.Survey.WebApp.Models
{
    public class AnswerViewModel
    {
        public int AnswerId { get; set; }
        public int? QuestionId { get; set; }
        public int SubmissionId { get; set; }
        public string? AnswerValue { get; set; } = string.Empty;

    }
}
