namespace Tengella.Survey.WebApp.Models
{
    public class AddChoiceViewModel
    {
        public int SurveyObjectId { get; set; }
        public List<QuestionViewModel> Questions { get; set; }
    }
}
