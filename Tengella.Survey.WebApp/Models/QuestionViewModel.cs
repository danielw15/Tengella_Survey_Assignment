namespace Tengella.Survey.WebApp.Models
{
    public class QuestionViewModel
    {
        public int QuestionId { get; set; }
        public int? SurveyObjectId { get; set; }
        public string? QuestionName { get; set; } = string.Empty;
        public int? QuestionPosition { get; set; } = 0;
        public string? QuestionType { get; set; } = string.Empty;
        public List<ChoiceViewModel>? QuestionChoices { get; set; } = new List<ChoiceViewModel>();

    }
}
