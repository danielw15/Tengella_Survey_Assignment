namespace Tengella.Survey.WebApp.Models
{
    public class SurveyTemplateEditViewModel
    {
        public int SurveyTemplateId { get; set; }
        public string TemplateName { get; set; }
        public string Description { get; set; }
        public int UserId { get; set; } = 1;
        public List<TemplateQuestionEditViewModel> Questions { get; set; }
    }
}
