using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tengella.Survey.Data.Models
{
    public class SurveyObject
    {
        public SurveyObject() 
        {
            Questions = new HashSet<Question>();
        }
        public int SurveyObjectId { get; set; }
        //FK
        public int UserId { get; set; }
        public string? SurveyTitle { get; set; }
        public string? SurveyDescription { get; set; }
        public string? SurveyType { get; set; }
        //Navigation
        public User? User { get; set; }
        public ICollection<Question>? Questions { get; set; }

    }
}
