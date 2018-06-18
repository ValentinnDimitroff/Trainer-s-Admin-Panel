namespace OpenCoursesAdmin.Controllers
{
    using System.IO;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.AspNetCore.Http;
    using OpenCoursesAdmin.Data;
    using OpenCoursesAdmin.Data.Models.QuizModels;
    using OpenCoursesAdmin.Services;

    public partial class QuizsController : Controller
    {
        private readonly OCADbContext dbcontext;
        private readonly IQuizsService quizsService;

        public QuizsController(OCADbContext dbcontext, IQuizsService quizsService)
        {
            this.dbcontext = dbcontext;
            this.quizsService = quizsService;
        }

        public virtual IActionResult All() => View(this.quizsService.GetAllQuizzes());

        public virtual IActionResult Create() => View();

        [HttpPost, ValidateAntiForgeryToken]
        public virtual IActionResult Create([Bind("Id, Name, Description")] Quiz quiz)
        {
            if (ModelState.IsValid)
            {
                this.quizsService.CreateQuiz(quiz);
                return RedirectToAction(nameof(this.All));
            }

            return View(quiz);
        }

        public async virtual Task<IActionResult> Questions(int? id)
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

        public virtual IActionResult Configurations(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            return RedirectToAction(nameof(MVC.Configurations.All), nameof(MVC.Configurations), new { quizId = id });
        }

        [HttpPost]
        public async virtual Task<IActionResult> UploadQuestions(int quizId, IFormFile file)
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

        public async virtual Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Quiz quiz = await dbcontext.Quizs.SingleOrDefaultAsync(m => m.Id == id);
            if (quiz == null)
            {
                return NotFound();
            }
            return View(quiz);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async virtual Task<IActionResult> Edit(int id, [Bind("Id,ExternalId,Name")] Quiz quiz)
        {
            if (id != quiz.Id)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return View(quiz);
            }

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

            return this.RedirectToAction(nameof(this.All));
        }

        // GET: Quizs/Delete/5
        public async virtual Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Quiz quiz = await dbcontext.Quizs
                .SingleOrDefaultAsync(m => m.Id == id);
            if (quiz == null)
            {
                return NotFound();
            }

            return View(quiz);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async virtual Task<IActionResult> DeleteConfirmed(int id)
        {
            var quiz = await dbcontext.Quizs.SingleOrDefaultAsync(m => m.Id == id);
            dbcontext.Quizs.Remove(quiz);
            await dbcontext.SaveChangesAsync();
            return RedirectToAction(nameof(All));
        }

        private bool QuizExists(int id) => this.dbcontext.Quizs.Any(e => e.Id == id);
    }
}
