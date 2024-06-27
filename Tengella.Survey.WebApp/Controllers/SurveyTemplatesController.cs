using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tengella.Survey.Data;
using Tengella.Survey.Data.Models;
using Tengella.Survey.WebApp.Models;

public class SurveyTemplatesController : Controller
{
    private readonly SurveyDbContext _context;

    public SurveyTemplatesController(SurveyDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var templates = await _context.SurveyTemplates.Include(t => t.Questions).ThenInclude(q => q.Choices).ToListAsync();
        return View(templates);
    }

    public async Task<IActionResult> CreateFromTemplate(int templateId)
    {
        var template = await _context.SurveyTemplates.Include(t => t.Questions).ThenInclude(q => q.Choices).FirstOrDefaultAsync(t => t.SurveyTemplateId == templateId);

        if (template == null)
        {
            return NotFound();
        }

        var survey = new SurveyObject
        {
            SurveyTitle = template.TemplateName,
            SurveyDescription = template.Description,
            UserId = 1,
            Questions = template.Questions.Select(q => new Question
            {
                QuestionName = q.QuestionText,
                QuestionType = q.QuestionType,
                Choices = q.Choices.Select(c => new Choice
                {
                    ChoiceText = c.ChoiceText,
                    ChoicePosition = c.ChoicePosition // Ensure ChoicePosition is included
                }).ToList()
            }).ToList()
        };

        _context.SurveyObjects.Add(survey);
        await _context.SaveChangesAsync();

        return RedirectToAction("Edit", "SurveyObjects", new { id = survey.SurveyObjectId });
    }

    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var template = await _context.SurveyTemplates.Include(t => t.Questions).ThenInclude(q => q.Choices).FirstOrDefaultAsync(t => t.SurveyTemplateId == id);
        if (template == null)
        {
            return NotFound();
        }

        var model = new SurveyTemplateEditViewModel
        {
            SurveyTemplateId = template.SurveyTemplateId,
            TemplateName = template.TemplateName,
            Description = template.Description,
            UserId = 1,
            Questions = template.Questions.Select(q => new TemplateQuestionEditViewModel
            {
                TemplateQuestionId = q.TemplateQuestionId,
                QuestionText = q.QuestionText,
                QuestionType = q.QuestionType,
                Choices = q.Choices.Select(c => new TemplateChoiceEditViewModel
                {
                    TemplateChoiceId = c.TemplateChoiceId,
                    ChoiceText = c.ChoiceText,
                    ChoicePosition = c.ChoicePosition // Ensure ChoicePosition is included in the model
                }).ToList()
            }).ToList()
        };

        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(SurveyTemplateEditViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        var template = await _context.SurveyTemplates.Include(t => t.Questions).ThenInclude(q => q.Choices).FirstOrDefaultAsync(t => t.SurveyTemplateId == model.SurveyTemplateId);

        if (template == null)
        {
            return NotFound();
        }

        template.TemplateName = model.TemplateName;
        template.Description = model.Description;
        

        foreach (var questionModel in model.Questions)
        {
            var question = template.Questions.FirstOrDefault(q => q.TemplateQuestionId == questionModel.TemplateQuestionId);
            if (question == null)
            {
                question = new TemplateQuestion
                {
                    TemplateQuestionId = questionModel.TemplateQuestionId,
                    QuestionText = questionModel.QuestionText,
                    QuestionType = questionModel.QuestionType,
                    Choices = new List<TemplateChoice>()
                };
                template.Questions.Add(question);
            }
            else
            {
                question.QuestionText = questionModel.QuestionText;
                question.QuestionType = questionModel.QuestionType;
            }

            foreach (var choiceModel in questionModel.Choices)
            {
                var choice = question.Choices.FirstOrDefault(c => c.TemplateChoiceId == choiceModel.TemplateChoiceId);
                if (choice == null)
                {
                    choice = new TemplateChoice
                    {
                        TemplateChoiceId = choiceModel.TemplateChoiceId,
                        ChoiceText = choiceModel.ChoiceText,
                        ChoicePosition = choiceModel.ChoicePosition // Ensure ChoicePosition is included
                    };
                    question.Choices.Add(choice);
                }
                else
                {
                    choice.ChoiceText = choiceModel.ChoiceText;
                    choice.ChoicePosition = choiceModel.ChoicePosition; // Ensure ChoicePosition is updated
                }
            }
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
}