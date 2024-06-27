using Microsoft.EntityFrameworkCore;
using Tengella.Survey.Data;
using Tengella.Survey.Data.Models;
using Tengella.Survey.WebApp.ServiceInterface;

namespace Tengella.Survey.WebApp.Service
{
    public class SubmissionService : ISubmissionService
    {
        private readonly SurveyDbContext _context;
        private readonly ISurveyService _surveyService;

        public SubmissionService(SurveyDbContext context, ISurveyService surveyService) 
        {
            _context = context;
            _surveyService = surveyService;
        }
        public async Task<List<Submission>> GetAllSubmissionAsync()
        {
            var submissionDbContext = _context.Submissions
                .Include(s => s.Answers);
            return await submissionDbContext.ToListAsync();
        }

        //public async Task<Submission> GetSubmissionAsync(int? id)
        //{
        //    var submissionObject = await _context.Submissions
        //        .Include(s => s.Answers)
        //        .FirstOrDefaultAsync(m => m.SubmissionId == id);

        //    return submissionObject;
        //}
        public async Task<Submission> GetSubmissionAsync(int? surveyId, string uniqueToken)
        {
            var submissionObject = await _context.Submissions
                .Include(s => s.Answers)
                .FirstOrDefaultAsync(m => m.SurveyObjectId == surveyId && m.UniqueToken == uniqueToken);

            return submissionObject;
        }

        public async Task SaveSubmissionAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task SubmitSubmissionAsync(Submission submission)
        {
            await _context.AddAsync(submission);
        }

        public void UpdateSubmission(Submission submission)
        {
            _context.Update(submission);
        }
        public string CreateSubmission(int surveyId)
        {
            var surveyObject = _context.SurveyObjects.Find(surveyId);
            if (surveyObject == null)
            {
                throw new ArgumentException($"SurveyObject with ID {surveyId} does not exist.");
            }
            var uniqueToken = Guid.NewGuid().ToString();

            var submission = new Submission
            {
                SurveyObjectId = surveyId,
                UniqueToken = uniqueToken
            };

            _context.Submissions.Add(submission);
            _context.SaveChanges();

            return uniqueToken;
        }
    }
}
