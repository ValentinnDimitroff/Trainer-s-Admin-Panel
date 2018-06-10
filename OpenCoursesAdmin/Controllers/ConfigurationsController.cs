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
    using TAS.DTO;

    public class ConfigurationsController : Controller
    {
        private readonly OCADbContext dbContext;
        private readonly IConfigurationService configurationService;

        public ConfigurationsController(OCADbContext context, IConfigurationService configurationService)
        {
            this.dbContext = context;
            this.configurationService = configurationService;
        }

        public async Task<IActionResult> All(int quizId)
        {
            ViewData["QuizName"] = this.dbContext.Quizs.Find(quizId).Name;

            return View(await this.dbContext
                .Configurations
                .Include(c => c.Quiz)
                .Where(c => c.QuizId == quizId)
                .ToListAsync());
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ConfigurationViewModel configViewModel)
        {
            if (this.ModelState.IsValid)
            {
                this.configurationService.CreateConfiguration(configViewModel);

                return this.RedirectToAction(nameof(this.All), new { quizId = configViewModel.Configuration.QuizId });
            }
            
            this.ViewData["QuizId"] = new SelectList(this.dbContext.Quizs, "Id", "Name", configViewModel.Configuration.QuizId);
            return this.View(configViewModel);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Configuration configuration = await this.dbContext
                .Configurations
                .Include(c => c.Quiz)
                .SingleOrDefaultAsync(m => m.Id == id);
            //TODO minutes not loaded
            if (configuration == null)
            {
                return NotFound();
            }

            ViewData["QuizId"] = new SelectList(this.dbContext.Quizs, "Id", "Name", configuration.QuizId);
            return View(configuration);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Configuration configuration)
        {
            if (id != configuration.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    dbContext.Update(configuration); //Shoud be loaded fully
                    await dbContext.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConfigurationExists(configuration.Id))
                    {
                        return NotFound();
                    }

                    throw;
                }

                configuration.Quiz = this.dbContext.Quizs.Find(configuration.QuizId);
                //TODO uncomment
                //this.configurationService.UpdateRecordReturnId(configuration, configuration.Quiz.ExternalId.ToString(),
                //    new[] { "AllowMultipleParticipations", "DurationInSeconds", "KeepQuestionsOrder" });
                return RedirectToAction(nameof(All), new { quizId = configuration.QuizId });
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
            return RedirectToAction(nameof(All)); //TODO add quizID
        }

        private bool ConfigurationExists(int id) => dbContext.Configurations.Any(e => e.Id == id);
    }
}
