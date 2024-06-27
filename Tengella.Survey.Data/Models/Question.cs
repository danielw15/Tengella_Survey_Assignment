using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tengella.Survey.Data.Models
{
    public class Question
    {
        public Question() 
        {
            Choices = new HashSet<Choice>();
        }
        public int QuestionId { get; set; }
        //FK
        public int? SurveyObjectId { get; set; }
        public string? QuestionName { get; set; }
        public int? QuestionPosition { get; set; }
        public string? QuestionType { get; set; }
        //Navigation
        public SurveyObject? SurveyObject { get; set; }
        public ICollection<Choice>? Choices { get; set; }


    }
}
