using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tengella.Survey.Data;
using Tengella.Survey.Data.Models;
using Tengella.Survey.WebApp.Models;
using Tengella.Survey.WebApp.ServiceInterface;
using static System.Net.WebRequestMethods;

namespace Tengella.Survey.WebApp.Service
{
    public class SurveyService : ISurveyService
    {
        private readonly SurveyDbContext _context;
        private readonly string _baseUrl = "https://localhost:7128";
        public SurveyService(SurveyDbContext context)
        {
            _context = context;
            
        }
        public async Task<List<SurveyObject>> GetAllSurveyAsync()
        {
            var surveyDbContext = _context.SurveyObjects
                .Include(s => s.User)
                .Include(s => s.Questions);
            return await surveyDbContext.ToListAsync();
        }

        public async Task<SurveyObject> GetSurveyAsync(int? id)
        { 
            if (id == null)
            {
                return null;
            }
            var surveyObject = await _context.SurveyObjects
                .Include(s => s.Questions)
                .ThenInclude(q => q.Choices)
                .FirstOrDefaultAsync(m => m.SurveyObjectId == id);
            
            return surveyObject;
        }

        public async Task SaveSurveyAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task SubmitSurveyAsync(SurveyObject survey)
        {
            await _context.AddAsync(survey);
        }
        public void UpdateSurvey(SurveyObject survey)
        {
            _context.Update(survey);
        }

        public string GenerateSurveyUrl(int surveyId)
        {
            var uniqueToken = Guid.NewGuid().ToString();
            return $"{_baseUrl}/take_survey/{surveyId}/{uniqueToken}";
        }

        
    }
}
