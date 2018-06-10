﻿namespace OpenCoursesAdmin.Services.Models.RequestModels
{
    using System;

    public class UsersInOpenCourse
    {
        public int Id { get; set; }

        public string NameBg { get; set; }

        public bool IsActive { get; set; }

        public int SpectatorsCount { get; set; }

        public int OnlineUsersCount { get; set; }

        public int OnsiteUsersCount { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime ModifiedOn { get; set; }
    }
}
