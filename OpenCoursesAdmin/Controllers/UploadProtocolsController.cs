namespace OpenCoursesAdmin.Controllers
{
    using System.IO;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    public partial class UploadProtocolsController : Controller
    {
        public virtual IActionResult Index()
        {
            return View();
        }

        public async virtual Task<IActionResult> UploadProtocol(int quizId, IFormFile file)
        {
            if (!file.FileName.ToLowerInvariant().EndsWith(".xls") ||
                !file.FileName.ToLowerInvariant().EndsWith(".xlsx"))
            {
                //TODO Еrror
            }

            string filePath = Path.GetTempFileName().Replace(".tmp", ".xls");
            //TODO store files in SVN with author and course name

            if (file.Length > 0)
            {
                using (FileStream stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
            }

            //TODO call service to upload the protocol

            return this.RedirectToAction(nameof(this.Index));
        }

    }
}