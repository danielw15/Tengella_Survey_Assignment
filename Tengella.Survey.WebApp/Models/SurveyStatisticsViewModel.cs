namespace Tengella.Survey.WebApp.Models
{
    public class SurveyStatisticsViewModel
    { 
            public string SurveyTitle { get; set; }
            public string SurveyDescription { get; set; }
            public List<SubmissionViewModel> Submissions { get; set; }        
            public List<QuestionViewModel> Questions { get; set; }
        }
        
}


