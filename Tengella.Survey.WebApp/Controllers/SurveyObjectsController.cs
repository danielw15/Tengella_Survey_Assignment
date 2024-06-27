using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Options;
using Tengella.Survey.Data;
using Tengella.Survey.Data.Models;
using Tengella.Survey.WebApp.Models;
using Tengella.Survey.WebApp.Service;
using Tengella.Survey.WebApp.ServiceInterface;
using Tengella.Survey.WebApp.Settings;
using static Tengella.Survey.WebApp.Models.SurveyStatisticsViewModel;


namespace Tengella.Survey.WebApp.Controllers
{
    public class SurveyObjectsController : Controller
    {
        private readonly SurveyDbContext _context;
        private readonly ISurveyService _surveyService;
        private readonly ISubmissionService _submissionService;
        private readonly IQuestionService _questionService;
        private readonly IMailSender _mailSender;
        private readonly IMapper _mapper;

        public SurveyObjectsController(SurveyDbContext context,
            ISurveyService surveyService,
            ISubmissionService submissionService,
            IMapper mapper,
            IMailSender mailSender,
            IQuestionService questionService)
        {
            _context = context;
            _surveyService = surveyService;
            _submissionService = submissionService;
            _questionService = questionService;
            _mapper = mapper;
            _mailSender = mailSender;
        }

        // GET: SurveyObjects
        public async Task<IActionResult> Index()
        {
            
            var surveys = await _surveyService.GetAllSurveyAsync();
            var surveyViewModels = _mapper.Map<IEnumerable<SurveyViewModel>>(surveys);
            return View(surveyViewModels);
        }

        // GET: SurveyObjects/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var surveyObject = await _surveyService.GetSurveyAsync(id);
            if (surveyObject == null)
            {
                return NotFound();
            }
            var surveyViewModel = new SurveyViewModel
            {
                SurveyObjectId = surveyObject.SurveyObjectId,
                SurveyTitle = surveyObject.SurveyTitle,
                SurveyDescription = surveyObject.SurveyDescription,
                SurveyQuestions = surveyObject.Questions.Select(q => new QuestionViewModel
                {
                    QuestionId = q.QuestionId,
                    QuestionName = q.QuestionName,
                    QuestionPosition = q.QuestionPosition,
                    QuestionChoices = q.Choices.Select(a => new ChoiceViewModel
                    {
                        ChoiceId = a.ChoiceId,
                        ChoicePosition = a.ChoicePosition,
                        ChoiceText = a.ChoiceText
                    }).ToList()
                }).ToList()
            };
            
            return View(surveyViewModel);
        }

        [HttpGet("/SurveyObjects/CreateSubmission/{surveyId}")]
        public IActionResult CreateSubmission(int surveyId)
        {
            
            
                var uniqueToken = _submissionService.CreateSubmission(surveyId);

                // Redirect to the survey page with surveyId and uniqueToken
                return RedirectToAction("DoSurvey", "SurveyObjects", new { surveyId = surveyId, uniqueToken = uniqueToken });
            
            
        }

        // GET: SurveyObjects/DoSurvey/1
        [HttpGet("/SurveyObjects/DoSurvey/{surveyId}/{uniqueToken}")]
        public async Task<IActionResult> DoSurvey(int? surveyId, string uniqueToken)
        {
            if (surveyId == null)
            {
                return NotFound();
            }
            var submission = await _submissionService.GetSubmissionAsync(surveyId, uniqueToken);

            if (submission == null)
            {
                return NotFound();
            }

            var surveyObject = await _surveyService.GetSurveyAsync(surveyId);
            
            if (surveyObject == null)
            {
                return NotFound();
            }
            var viewModel = new DoSurveyViewModel
            {
                SubmissionId = submission.SubmissionId,
                SurveyObjectId = surveyObject.SurveyObjectId,
                UniqueToken = submission.UniqueToken,
                SurveyTitle = surveyObject.SurveyTitle,
                SurveyDescription = surveyObject.SurveyDescription,
                SurveyQuestions = surveyObject.Questions.Select(q => new QuestionViewModel
                {
                    QuestionId = q.QuestionId,
                    QuestionName = q.QuestionName,
                    QuestionType = q.QuestionType,
                    QuestionPosition = q.QuestionPosition,
                    SurveyObjectId = q.SurveyObjectId,
                    QuestionChoices = q.Choices.Select(c => new ChoiceViewModel
                    {
                        ChoiceId = c.ChoiceId,
                        ChoicePosition = c.ChoicePosition,
                        ChoiceText = c.ChoiceText,
                        QuestionId = c.QuestionId,
                    }).ToList(),
                }).ToList(),
                SurveyAnswers = _mapper.Map<List<AnswerViewModel>>(submission.Answers).ToList()
            };
            if(viewModel.SurveyQuestions.Count > viewModel.SurveyAnswers.Count)
            {
                for (int i = viewModel.SurveyAnswers.Count; i < viewModel.SurveyQuestions.Count; i++)
                {
                    viewModel.SurveyAnswers.Add(new AnswerViewModel());
                }
            }
            
            return View(viewModel);
        }
        
        [HttpPost("/SurveyObjects/DoSurvey/{surveyId}/{uniqueToken}")]
        public async Task<IActionResult> DoSurvey(int? surveyId, string uniqueToken, DoSurveyViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                var surveyObject = await _surveyService.GetSurveyAsync(surveyId);
                viewModel = _mapper.Map<DoSurveyViewModel>(surveyObject);
               
                return View(viewModel);
            }
            var submissionDb = await _submissionService.GetSubmissionAsync(surveyId, uniqueToken);
            
            submissionDb.Answers = _mapper.Map<List<Answer>>(viewModel.SurveyAnswers);
            submissionDb.SubmissionDate = DateTime.Now;
            
            _submissionService.UpdateSubmission(submissionDb);
            await _submissionService.SaveSubmissionAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: SurveyObjects/Create
        public IActionResult Create()
        {
            SurveyObject survey = new SurveyObject();
            survey.UserId = 1;
            SurveyViewModel viewModel = new SurveyViewModel();
            viewModel = _mapper.Map<SurveyViewModel>(survey);
            var question = new QuestionViewModel();
            
            return View(viewModel);
        }

        // POST: SurveyObjects/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SurveyViewModel model)
        {
            var survey = _mapper.Map<SurveyObject>(model);
            for(int i = 0; i < model.SurveyQuestions.Count; i++)
            {
                var question = _mapper.Map<Question>(model.SurveyQuestions[i]);
                
                survey.Questions.Add(question);
            }
            
            
            survey.UserId = 1;
            await _surveyService.SubmitSurveyAsync(survey);
            await _surveyService.SaveSurveyAsync();

            
            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var surveyObject = await _context.SurveyObjects.FindAsync(id);
            if (surveyObject == null)
            {
                return NotFound();
            }
            var viewModel = _mapper.Map<SurveyViewModel>(surveyObject);
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, SurveyViewModel viewModel)
        {
            if (id != viewModel.SurveyObjectId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var survey = _mapper.Map<SurveyObject>(viewModel);
                    survey.UserId = 1;
                    _context.Update(survey);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SurveyObjectExists(viewModel.SurveyObjectId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Details", new { id = viewModel.SurveyObjectId });
            }
            
            return View(viewModel);
        }

        // GET: SurveyObjects/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var surveyObject = await _context.SurveyObjects
                .Include(s => s.User)
                .FirstOrDefaultAsync(m => m.SurveyObjectId == id);
            if (surveyObject == null)
            {
                return NotFound();
            }

            return View(surveyObject);
        }

        // POST: SurveyObjects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var surveyObject = await _context.SurveyObjects.FindAsync(id);
            if (surveyObject != null)
            {
                _context.SurveyObjects.Remove(surveyObject);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<ActionResult> AddQuestion([Bind("SurveyObjectId, SurveyTitle, SurveyDescription, SurveyType, SurveyQuestions, QuestionChoices")] SurveyViewModel viewModel)
        {
            var question = new QuestionViewModel();
            question.QuestionPosition = viewModel.SurveyQuestions.Count() + 1;
            viewModel.SurveyQuestions.Add(question);
            return PartialView("_QuestionRowPartial", viewModel);
        }

        [HttpGet("/SurveyObjects/AddChoice/{surveyId}")]
        public async Task<IActionResult> AddChoice(int surveyId)
        {
            
            var survey = await _surveyService.GetSurveyAsync(surveyId);
            var questionList = _mapper.Map<List<QuestionViewModel>>(survey.Questions.ToList());
            int i = 0;
            foreach(var question in survey.Questions) 
            {
                questionList[i].QuestionChoices = _mapper.Map<List<ChoiceViewModel>>(question.Choices).ToList();
                i++;
            }

            var viewModel = new AddChoiceViewModel
            {
                SurveyObjectId = surveyId,
                Questions = questionList
            };
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> SaveChoices(AddChoiceViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var questionList = _mapper.Map<List<Question>>(model.Questions).ToList();
                    for (int i = 0; i < questionList.Count; i++)
                    {
                        questionList[i].Choices = _mapper.Map<List<Choice>>(model.Questions[i].QuestionChoices).ToList();
                        _questionService.UpdateQuestion(questionList[i]);
                        await _questionService.SaveQuestionAsync();
                    }
                    
                    

                    // Redirect to a confirmation page or survey details page
                    return RedirectToAction("Details", new { id = model.SurveyObjectId });
                }
                catch (Exception ex)
                {
                    // Handle exceptions
                    ViewBag.ErrorMessage = "Failed to save choices: " + ex.Message;
                    return View("Error");
                }
            }

            // If model state is invalid, return the same view with the current model to show validation errors
            return View("AddChoices", model);
        }



        public async Task MailSurvey(int id, string email = "danielwallen1233@gmail.com", string subject = "Gör min enkät", string message = "https://localhost:7128/SurveyObjects/CreateSubmission/")
        {
            message += id;
            var survey = await _surveyService.GetSurveyAsync(id);
            
            await _mailSender.SendEmailAsync(email, subject, message);
        }

        [HttpGet("/SurveyObjects/SendSurvey/{surveyId}")]
        public async Task<IActionResult> SendSurvey(int surveyId)
        {

            var survey = await _surveyService.GetSurveyAsync(surveyId);
            var questionList = _mapper.Map<List<QuestionViewModel>>(survey.Questions.ToList());
            int i = 0;
            foreach (var question in survey.Questions)
            {
                questionList[i].QuestionChoices = _mapper.Map<List<ChoiceViewModel>>(question.Choices).ToList();
                i++;
            }
            var addChoiceiewModel = new AddChoiceViewModel
            {
                SurveyObjectId = surveyId,
                Questions = questionList
            };
            var userList = new List<UserViewModel>();
            userList.Add(new UserViewModel());
            var viewModel = new SendSurveyViewModel
            {
                SurveyObjectId = surveyId,
                SurveyTitle = survey.SurveyTitle,
                SurveyDescription = survey.SurveyDescription,
                AddChoice = addChoiceiewModel,
                Subject = "",
                Message = "",
                Users = userList
            };
            
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> MailSurveyToList(SendSurveyViewModel model)
        {
            
            return RedirectToAction(nameof(Index));
        }


        [HttpGet("/SurveyObjects/GenerateSurveyUrl/{surveyId}")]
        public IActionResult GenerateSurveyUrl(int surveyId)
        {
            var surveyUrl = _submissionService.CreateSubmission(surveyId);

            var viewModel = new SurveyViewModel
            {
                SurveyUrl = surveyUrl
            };

            return View("DoSurvey", viewModel);
        }

        private bool SurveyObjectExists(int id)
        {
            return _context.SurveyObjects.Any(e => e.SurveyObjectId == id);
        }

        public async Task<IActionResult> StatisticsIndex()
        {
            var submissions = await _context.Submissions
            .Include(s => s.Answers)
            .Include(s => s.SurveyObject)
            .ToListAsync();

            var groupedSubmissions = submissions
                .GroupBy(s => s.SurveyObject)
                .Select(g => new SurveySummaryViewModel
                {
                    SurveyObjectId = g.Key.SurveyObjectId,
                    SurveyTitle = g.Key.SurveyTitle,
                    SurveyDescription = g.Key.SurveyDescription,
                    TotalSubmissions = g.Count(),
                    AverageAnswersPerSubmission = g.Average(s => s.Answers.Count)
                }).ToList();

            return View(groupedSubmissions);
        }
            public async Task<IActionResult> Statistics(int id)
        {
            var survey = await _context.SurveyObjects
                .Include(s => s.Questions)
                .ThenInclude(q => q.Choices)
                .FirstOrDefaultAsync(s => s.SurveyObjectId == id);
            
            if (survey == null)
            {
                return NotFound();
            }

            var submissionList = _context.Submissions
                .Include(s => s.Answers)
                .Where(s => s.SurveyObjectId == id);
            if (submissionList == null)
            {
                return NotFound();
            }


            var model = new SurveyStatisticsViewModel
            {
                SurveyTitle = survey.SurveyTitle,
                SurveyDescription = survey.SurveyDescription,
                Submissions = submissionList.Select(s => new SubmissionViewModel 
                {
                    SubmissionId = s.SubmissionId,
                    SurveyObjectId = s.SurveyObjectId,
                    SubmissionDate = s.SubmissionDate,
                    Answers = s.Answers.Select(a => new AnswerViewModel
                    {
                        AnswerId = a.AnswerId,
                        AnswerValue = a.AnswerValue,
                        QuestionId = a.QuestionId,
                        SubmissionId = a.SubmissionId
                    }).ToList()
                }).ToList(),
                Questions = survey.Questions.Select(q => new QuestionViewModel
                {
                    QuestionId = q.QuestionId,
                    QuestionName = q.QuestionName,
                    QuestionChoices = q.Choices.Select(c => new ChoiceViewModel
                    {
                        ChoiceText = c.ChoiceText,
                        
                    }).ToList()
                }).ToList()
            };

            return View(model);
        }

        
    }

    

}

