using Tengella.Survey.Data.Models;

namespace Tengella.Survey.WebApp.ServiceInterface
{
    public interface IQuestionService
    {
        Task<Question> GetQuestionAsync(int? id);
        Task<List<Question>> GetAllQuestionAsync();
        Task SubmitQuestionAsync(Question question);
        void UpdateQuestion(Question question);
        Task SaveQuestionAsync();
    }
}
