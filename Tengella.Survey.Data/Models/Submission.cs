using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tengella.Survey.Data.Models
{
    public class Submission
    {
        public int SubmissionId { get; set; }
        //FK
        public int SurveyObjectId { get; set; }
        public DateTime SubmissionDate { get; set; }
        public string? UniqueToken { get; set; }
        //Navigation
        public ICollection<Answer>? Answers { get; set; }
        public SurveyObject? SurveyObject { get; set; }
    }
}
