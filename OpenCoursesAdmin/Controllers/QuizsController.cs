namespace OpenCoursesAdmin.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using OpenCoursesAdmin.Data;
    using OpenCoursesAdmin.Data.Models.QuizModels;
    using OpenCoursesAdmin.Services;
    using Microsoft.AspNetCore.Http;
    using System.IO;
    using System.Collections.Generic;

    public class QuizsController : Controller
    {
        private readonly OCADbContext dbcontext;
        private readonly IQuizsService quizsService;

        public QuizsController(OCADbContext dbcontext, IQuizsService quizsService)
        {
            this.dbcontext = dbcontext;
            this.quizsService = quizsService;
        }

        public async Task<IActionResult> All() => View(await dbcontext.Quizs.ToListAsync());
        
        public async Task<IActionResult> Questions(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Quiz quiz = await dbcontext.Quizs
                .Include(q => q.Questions)
                .ThenInclude(qq => qq.Answers)
                .SingleOrDefaultAsync(q => q.Id == id);

            if (quiz == null)
            {
                return NotFound();
            }

            return View(quiz);
        }

        public IActionResult Configurations(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            return RedirectToAction(nameof(All), nameof(ConfigurationsController).Replace("Controller", ""), null);
        }

        public IActionResult Create() => View();

        // To protect from overposting attacks, please enable the specific properties you want to bind to http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id, Name, Description")] Quiz quiz)
        {
            if (ModelState.IsValid)
            {
                quiz.ExternalId = this.quizsService.CreateRecordReturnId(quiz, new [] {"Name", "Description"});

                this.dbcontext.Add(quiz);
                await dbcontext.SaveChangesAsync();
                return RedirectToAction(nameof(All));
            }

            return View(quiz);
        }

        [HttpPost]
        public async Task<IActionResult> UploadQuestions(int quizId, IFormFile file)
        {
            if (!file.FileName.ToLowerInvariant().EndsWith(".xls") || !file.FileName.ToLowerInvariant().EndsWith(".xlsx"))
            {
                //TODO Еrror
            }

            string filePath = Path.GetTempFileName().Replace(".tmp", ".xlsx");
            //TODO store files in SVN with author and course name

            if (file.Length > 0)
            {
                using (FileStream stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
            }

            List<QuizQuestion> questions = new QuizTemplateReader().ReadTemplate(filePath);

            this.dbcontext
                .RemoveRange(this.dbcontext
                                 .QuizQuestions
                                 .Where(qq => qq.QuizId == quizId));

            Quiz quiz = this.dbcontext.Quizs
                .First(q => q.Id == quizId);
            quiz.Questions.AddRange(questions);
            await this.dbcontext.SaveChangesAsync();

            this.quizsService.PublishQuestions(quiz);

            return this.RedirectToAction(nameof(this.Questions), new { id = quizId });
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var quiz = await dbcontext.Quizs.SingleOrDefaultAsync(m => m.Id == id);
            if (quiz == null)
            {
                return NotFound();
            }
            return View(quiz);
        }

        // POST: Quizs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ExternalId,Name")] Quiz quiz)
        {
            if (id != quiz.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    dbcontext.Update(quiz);
                    await dbcontext.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QuizExists(quiz.Id))
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
            return View(quiz);
        }

        // GET: Quizs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var quiz = await dbcontext.Quizs
                .SingleOrDefaultAsync(m => m.Id == id);
            if (quiz == null)
            {
                return NotFound();
            }

            return View(quiz);
        }

        // POST: Quiz/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var quiz = await dbcontext.Quizs.SingleOrDefaultAsync(m => m.Id == id);
            dbcontext.Quizs.Remove(quiz);
            await dbcontext.SaveChangesAsync();
            return RedirectToAction(nameof(All));
        }

        private bool QuizExists(int id) => dbcontext.Quizs.Any(e => e.Id == id);
    }
}
