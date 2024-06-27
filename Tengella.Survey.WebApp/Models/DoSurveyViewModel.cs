namespace Tengella.Survey.WebApp.Models
{
    public class DoSurveyViewModel
    {
        public int SubmissionId { get; set; }
        public int SurveyObjectId { get; set; }
        public string UniqueToken { get; set; }
        public string SurveyTitle { get; set; }
        public string SurveyDescription { get; set; } = string.Empty;
        public List<AnswerViewModel>? SurveyAnswers { get; set; } = new List<AnswerViewModel>();
        public List<QuestionViewModel>? SurveyQuestions { get; set; } = new List<QuestionViewModel>();
    }
}
