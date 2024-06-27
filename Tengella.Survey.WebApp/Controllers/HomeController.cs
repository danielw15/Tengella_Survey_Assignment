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

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly SurveyDbContext _context;
        private readonly ISurveyService _surveyService;
        private readonly ISubmissionService _submissionService;
        private readonly IQuestionService _questionService;
        private readonly IMailSender _mailSender;
        private readonly IMapper _mapper;

        public HomeController(SurveyDbContext context,
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

        public async Task<IActionResult> Index()
        {
            var surveys = await _context.SurveyObjects
                .Select(s => new SurveyViewModel
                {
                    SurveyObjectId = s.SurveyObjectId,
                    SurveyTitle = s.SurveyTitle,
                    SurveyDescription = s.SurveyDescription
                })
                .ToListAsync();
            return View(surveys);
        }
            

            public IActionResult Privacy()
        {
            return View();
        }

        
    }
}