using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tengella.Survey.Data.Models;
using Microsoft.EntityFrameworkCore.Design;

namespace Tengella.Survey.Data
{
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<SurveyDbContext>
    {
        public SurveyDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<SurveyDbContext>();
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=SurveyTengella;Trusted_Connection=True;MultipleActiveResultSets=true");
            
            return new SurveyDbContext(optionsBuilder.Options);
        }
    }


}
