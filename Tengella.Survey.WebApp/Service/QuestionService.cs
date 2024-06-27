using Tengella.Survey.Data.Models;
using Tengella.Survey.Data;
using Tengella.Survey.WebApp.ServiceInterface;
using Microsoft.EntityFrameworkCore;

namespace Tengella.Survey.WebApp.Service
{
    public class QuestionService : IQuestionService
    {
        private readonly SurveyDbContext _context;
        public QuestionService(SurveyDbContext context)
        {
            _context = context;
        }
        public async Task<List<Question>> GetAllQuestionAsync()
        {
            var questionObject = _context.Questions
                .Include(q => q.Choices);
            return await questionObject.ToListAsync();
        }

        public async Task<Question> GetQuestionAsync(int? id)
        {
            var questionObject = await _context.Questions
                .Include(q => q.Choices)
                .FirstOrDefaultAsync(m => m.QuestionId == id);

            return questionObject;
        }

        public async Task SaveQuestionAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task SubmitQuestionAsync(Question question)
        {
            await _context.AddAsync(question);
        }

        public void UpdateQuestion(Question question)
        {
            _context.Update(question);
        }


    }
}
