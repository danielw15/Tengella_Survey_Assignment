using Microsoft.EntityFrameworkCore;
using System.Configuration;
using Tengella.Survey.Data;
using Tengella.Survey.Data.Mapper;
using Tengella.Survey.WebApp.Service;
using Tengella.Survey.WebApp.ServiceInterface;
using Tengella.Survey.WebApp.Settings;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<SurveyDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add services to the container.
builder.Services.AddAutoMapper(typeof(MapperConfig));
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<ISurveyService, SurveyService>();
builder.Services.AddScoped<ISubmissionService, SubmissionService>();
builder.Services.AddScoped<IQuestionService, QuestionService>();

builder.Services.Configure<MailSettings>(builder.Configuration.GetSection("MailSettings"));
builder.Services.AddScoped<IMailSender, MailSender>();
//builder.Services.Configure<SurveyService>(builder.Configuration.GetSection("BaseUrl"));
builder.Services.AddRazorPages();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();


app.MapControllerRoute(
    name: "doSurvey",
    pattern: "SurveyObjects/DoSurvey/{surveyId}/{uniqueToken}",
    defaults: new { controller = "SurveyObjects", action = "DoSurvey" }
);

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
