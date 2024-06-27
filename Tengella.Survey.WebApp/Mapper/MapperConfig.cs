using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Tengella.Survey.Data.Models;
using Tengella.Survey.WebApp.Models;


namespace Tengella.Survey.Data.Mapper
{
    public class MapperConfig : Profile
    {
        public MapperConfig() 
        {
            CreateMap<SurveyObject, SurveyViewModel>()
                .ForMember(dest => dest.UserEmail, opt => opt.MapFrom(src => src.User.Email));
            CreateMap<SurveyObject, SurveyViewModel> ().ReverseMap();

            CreateMap<QuestionViewModel, Question>();
            CreateMap<QuestionViewModel, Question>().ReverseMap();

            CreateMap<ChoiceViewModel, Choice>();
            CreateMap<ChoiceViewModel, Choice>().ReverseMap();

            CreateMap<AnswerViewModel, Answer>();
            CreateMap<AnswerViewModel, Answer>().ReverseMap();

            CreateMap<DoSurveyViewModel, SurveyObject>();
            CreateMap<DoSurveyViewModel, SurveyObject>().ReverseMap();
        }
    }
}
