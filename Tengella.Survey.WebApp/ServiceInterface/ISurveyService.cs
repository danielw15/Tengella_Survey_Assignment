using Microsoft.AspNetCore.Mvc;
using Tengella.Survey.Data.Models;
using Tengella.Survey.WebApp.Models;

namespace Tengella.Survey.WebApp.ServiceInterface
{
    public interface ISurveyService
    {
        Task<SurveyObject> GetSurveyAsync(int? id);
        Task<List<SurveyObject>> GetAllSurveyAsync();
        Task SubmitSurveyAsync(SurveyObject survey);
        Task SaveSurveyAsync();
        void UpdateSurvey(SurveyObject survey);
        string GenerateSurveyUrl(int surveyId);
    }
}
