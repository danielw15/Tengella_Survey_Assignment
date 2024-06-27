using Tengella.Survey.Data.Models;

namespace Tengella.Survey.WebApp.Models
{
    public class SendSurveyViewModel
    {
        public int SurveyObjectId { get; set; }
        public string SurveyTitle { get; set; }
        public string SurveyDescription { get; set; }
        public AddChoiceViewModel AddChoice { get; set; }
        public List<UserViewModel> Users { get; set; } = new List<UserViewModel>();   
        public string Subject { get; set; }
        public string Message { get; set; }
        public string SurveyLink { get; set; } = "https://localhost:7128/SurveyObjects/";
    }
}
    