namespace OpenCoursesAdmin.Services
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface IFileUploader
    {
        void UploadFile(string filepath);
    }
}
