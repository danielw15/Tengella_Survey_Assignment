using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tengella.Survey.Data.Models
{
    public class SurveyTemplate
    {
        public int SurveyTemplateId { get; set; }
        public string? TemplateName { get; set; }
        public string? Description { get; set; }
        public ICollection<TemplateQuestion>? Questions { get; set; }
    }
}
