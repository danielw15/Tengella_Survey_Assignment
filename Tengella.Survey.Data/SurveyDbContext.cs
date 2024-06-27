using Tengella.Survey.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace Tengella.Survey.Data;

public class SurveyDbContext : DbContext
{
    public SurveyDbContext(DbContextOptions<SurveyDbContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<SurveyObject> SurveyObjects { get; set; }
    public DbSet<Question> Questions { get; set; }
    public DbSet<Answer> Answers { get; set; }
    public DbSet<Choice> Choices { get; set; }
    public DbSet<Submission> Submissions { get; set; }
    public DbSet<SurveyTemplate> SurveyTemplates { get; set; }
    public DbSet<TemplateQuestion> TemplateQuestions { get; set; }
    public DbSet<TemplateChoice> TemplateChoices { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Seed data
        //modelBuilder.Entity<User>().HasData(SeedUsers());
        //modelBuilder.Entity<SurveyTemplate>().HasData(SeedSurveyTemplates());
        //modelBuilder.Entity<TemplateQuestion>().HasData(SeedTemplateQuestions());
        //modelBuilder.Entity<TemplateChoice>().HasData(SeedTemplateChoices());
        //modelBuilder.Entity<SurveyObject>().HasData(SeedSurveyObjects());
        //modelBuilder.Entity<Question>().HasData(SeedQuestions());
        //modelBuilder.Entity<Choice>().HasData(SeedChoices());
        //modelBuilder.Entity<Submission>().HasData(SeedSubmissions());
        //modelBuilder.Entity<Answer>().HasData(SeedAnswers());
    }

    public void TruncateAllTables()
    {
        var tableNames = new List<string>
    {
        "Answers",
        "Choices",
        "Questions",
        "Submissions",
        "TemplateChoices",
        "TemplateQuestions",
        "SurveyObjects",
        "SurveyTemplates",
        "Users"
    };

        using (var transaction = this.Database.BeginTransaction())
        {
            foreach (var tableName in tableNames)
            {
                this.Database.ExecuteSqlRaw($"DELETE FROM [{tableName}]");
                this.Database.ExecuteSqlRaw($"DBCC CHECKIDENT ('[{tableName}]', RESEED, 0)");
            }
            transaction.Commit();
        }
    }

    private List<User> SeedUsers()
    {
        var users = new List<User>();
        for (int i = 1; i <= 100; i++)
        {
            users.Add(new User
            {
                UserId = i,
                FirstName = $"FirstName{i}",
                LastName = $"LastName{i}",
                Email = $"user{i}@example.com",
                Password = $"Password{i}",
                PhoneNumber = $"123-456-789{i % 10}",
                CreationDate = DateTime.Now.AddDays(-i),
                UserType = (i % 3 == 0) ? "private_person" : (i % 3 == 1) ? "company_person" : "government_person",
                OrgNumber = (i % 3 == 0) ? null : $"OrgNumber{i}",
                OrgName = (i % 3 == 0) ? null : $"OrgName{i}"
            });
        }
        return users;
    }

    private List<SurveyTemplate> SeedSurveyTemplates()
    {
        var templates = new List<SurveyTemplate>();
        for (int i = 1; i <= 10; i++)
        {
            templates.Add(new SurveyTemplate
            {
                SurveyTemplateId = i,
                TemplateName = $"TemplateName{i}",
                Description = $"Description of Template {i}"
            });
        }
        return templates;
    }

    private List<TemplateQuestion> SeedTemplateQuestions()
    {
        var templateQuestions = new List<TemplateQuestion>();
        for (int i = 1; i <= 50; i++)
        {
            templateQuestions.Add(new TemplateQuestion
            {
                TemplateQuestionId = i,
                SurveyTemplateId = (i % 10) + 1,
                QuestionText = $"Template Question {i}",
                QuestionType = (i % 2 == 0) ? "single_choice" : "free_text_choice",
                QuestionPosition = i
            });
        }
        return templateQuestions;
    }

    private List<TemplateChoice> SeedTemplateChoices()
    {
        var templateChoices = new List<TemplateChoice>();
        for (int i = 1; i <= 200; i++)
        {
            templateChoices.Add(new TemplateChoice
            {
                TemplateChoiceId = i,
                TemplateQuestionId = (i % 50) + 1,
                ChoiceText = $"Choice {i}",
                ChoicePosition = i
            });
        }
        return templateChoices;
    }

    private List<SurveyObject> SeedSurveyObjects()
    {
        var surveyObjects = new List<SurveyObject>();
        for (int i = 1; i <= 20; i++)
        {
            surveyObjects.Add(new SurveyObject
            {
                SurveyObjectId = i,
                SurveyTitle = $"Survey Title {i}",
                SurveyDescription = $"Description of Survey {i}",
                SurveyType = (i % 2 == 0) ? "type1" : "type2",
                UserId = (i % 100) + 1
            });
        }
        return surveyObjects;
    }

    private List<Question> SeedQuestions()
    {
        var questions = new List<Question>();
        for (int i = 1; i <= 100; i++)
        {
            questions.Add(new Question
            {
                QuestionId = i,
                SurveyObjectId = (i % 20) + 1,
                QuestionName = $"Question {i}",
                QuestionType = (i % 2 == 0) ? "single_choice" : "free_text_choice",
                QuestionPosition = i
            });
        }
        return questions;
    }

    private List<Choice> SeedChoices()
    {
        var choices = new List<Choice>();
        for (int i = 1; i <= 200; i++)
        {
            choices.Add(new Choice
            {
                ChoiceId = i,
                QuestionId = (i % 100) + 1,
                ChoiceText = $"Choice {i}",
                ChoicePosition = i
            });
        }
        return choices;
    }

    private List<Submission> SeedSubmissions()
    {
        var submissions = new List<Submission>();
        for (int i = 1; i <= 200; i++)
        {
            submissions.Add(new Submission
            {
                SubmissionId = i,
                SurveyObjectId = (i % 20) + 1,
                SubmissionDate = DateTime.Now.AddDays(-i),
                UniqueToken = Guid.NewGuid().ToString()
            });
        }
        return submissions;
    }

    private List<Answer> SeedAnswers()
    {
        var answers = new List<Answer>();
        for (int i = 1; i <= 500; i++)
        {
            answers.Add(new Answer
            {
                AnswerId = i,
                SubmissionId = (i % 200) + 1,
                QuestionId = (i % 100) + 1,
                AnswerValue = $"Answer {i}"
            });
        }
        return answers;
    }
}