namespace Tengella.Survey.WebApp.Models
{
    public class TemplateQuestionEditViewModel
    {
        public int TemplateQuestionId { get; set; }
        public string? QuestionText { get; set; }
        public string? QuestionType { get; set; } 
        public int? QuestionPosition { get; set; }
        public List<TemplateChoiceEditViewModel>? Choices { get; set; }
    }
}
