using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tengella.Survey.Data.Models
{
    public class Answer
    {
        public int AnswerId { get; set; }
        //FK
        public int? QuestionId { get; set; }
        //FK
        public int SubmissionId { get; set; }
        
        public string? AnswerValue { get; set; }
        //Navigation
        public Question? Question { get; set; }
        public Submission? Submission { get; set; }
    }
}
