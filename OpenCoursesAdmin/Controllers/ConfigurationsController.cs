namespace OpenCoursesAdmin.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.EntityFrameworkCore;
    using OpenCoursesAdmin.Data;
    using OpenCoursesAdmin.Data.Models.QuizModels.ConfigurationModels;
    using OpenCoursesAdmin.Services;
    using OpenCoursesAdmin.ViewModels;

    public class ConfigurationsController : Controller
    {
        private readonly OCADbContext dbContext;
        private readonly IConfigurationService configurationService; 

        public ConfigurationsController(OCADbContext context, IConfigurationService configurationService)
        {
            this.dbContext = context;
            this.configurationService = configurationService;
        }

        public async Task<IActionResult> All()
        {
            var oCADbContext = dbContext.Configurations.Include(c => c.Quiz);
            return View(await oCADbContext.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var configuration = await dbContext.Configurations
                .Include(c => c.Quiz)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (configuration == null)
            {
                return NotFound();
            }

            return View(configuration);
        }

        public IActionResult Create()
        {
            ViewData["QuizId"] = new SelectList(dbContext.Quizs, "Id", "Name");
            return View();
        }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ConfigurationViewModel configViewModel)
        //"Id,QuizId,DurationInMinutes,KeepQuestionsOrder,AllowMultipleParticipations", "StartAfter", "EndBefore", "Password"
        {
            if (ModelState.IsValid)
            {
                Configuration configuration = configViewModel.Configuration;
                this.configurationService.AddQuizInfo(configuration);

                configuration.ExternalId = this.configurationService
                    .CreateRecordReturnId(configuration, configuration.Quiz.ExternalId.ToString() , new [] {"Name",
                    "AllowMultipleParticipations", "DurationInSeconds", "KeepQuestionsOrder", 
                    "PossibleAnswersCount", "QuestionsCount"});
                
                this.dbContext.Add(configuration);
                await this.dbContext.SaveChangesAsync();

                ConfigSchedule configSchedule = configViewModel.ConfigSchedule;
                configuration.ConfigSchedules.Add(configSchedule);

                configSchedule.ExternalId = this.configurationService
                    .CreateRecordReturnId(configSchedule, configSchedule.Configuration.ExternalId.ToString(), new[] {"StartAfter",
                        "EndBefore", "Password"});

                this.dbContext.Add(configSchedule);
                await this.dbContext.SaveChangesAsync();

                return RedirectToAction(nameof(All));
            }

            ViewData["QuizId"] = new SelectList(dbContext.Quizs, "Id", "Name", configViewModel.Configuration.QuizId);
            return View(configViewModel);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var configuration = await dbContext.Configurations.SingleOrDefaultAsync(m => m.Id == id);
            if (configuration == null)
            {
                return NotFound();
            }
            ViewData["QuizId"] = new SelectList(dbContext.Quizs, "Id", "Name", configuration.QuizId);
            return View(configuration);
        }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,QuizId,DurationInSeconds,Name,PollQuestionsCount,PossibleAnswersCount,QuestionsCount,KeepQuestionsOrder,AllowMultipleParticipations,TestId")] Configuration configuration)
        {
            if (id != configuration.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    dbContext.Update(configuration);
                    await dbContext.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConfigurationExists(configuration.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(All));
            }
            ViewData["QuizId"] = new SelectList(dbContext.Quizs, "Id", "Name", configuration.QuizId);
            return View(configuration);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var configuration = await dbContext.Configurations
                .Include(c => c.Quiz)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (configuration == null)
            {
                return NotFound();
            }

            return View(configuration);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var configuration = await dbContext.Configurations.SingleOrDefaultAsync(m => m.Id == id);
            dbContext.Configurations.Remove(configuration);
            await dbContext.SaveChangesAsync();
            return RedirectToAction(nameof(All));
        }

        private bool ConfigurationExists(int id) => dbContext.Configurations.Any(e => e.Id == id);
    }
}
