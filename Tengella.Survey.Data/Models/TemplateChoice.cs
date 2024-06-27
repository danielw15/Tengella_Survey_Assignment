using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tengella.Survey.Data.Models
{
    public class TemplateChoice
    {
        public int TemplateChoiceId { get; set; }
        public int? TemplateQuestionId { get; set; }
        public string? ChoiceText { get; set; }
        public int? ChoicePosition { get; set; }
        public TemplateQuestion? TemplateQuestion {  get; set; }   
    }
}
