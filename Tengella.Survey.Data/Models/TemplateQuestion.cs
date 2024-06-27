using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tengella.Survey.Data.Models
{
    public class TemplateQuestion
    {
        public int TemplateQuestionId { get; set; }
        public int? SurveyTemplateId { get; set; }
        public string? QuestionText { get; set; }
        public int? QuestionPosition { get; set; }
        public string? QuestionType { get; set; } 
        public ICollection<TemplateChoice>? Choices { get; set; }
    }
}
