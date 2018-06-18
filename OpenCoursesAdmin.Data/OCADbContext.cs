namespace OpenCoursesAdmin.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using Models;
    using Models.QuizModels;
    using Models.QuizModels.ConfigurationModels;
    using Models.CourseModels;
    using OpenCoursesAdmin.Data.Models.SurveyModels;

    public class OCADbContext : IdentityDbContext<User>
    {
        public OCADbContext(DbContextOptions<OCADbContext> options)
            : base(options)
        {
        }

        #region DBSets
        public DbSet<Quiz> Quizs { get; set; }

        public DbSet<QuizQuestion> QuizQuestions { get; set; }

        public DbSet<QuizAnswer> QuizAnswers { get; set; }

        public DbSet<Configuration> Configurations { get; set; }

        public DbSet<ConfigSchedule> ConfigSchedules { get; set; }

        public DbSet<Survey> Surveys { get; set; }

        public DbSet<SurveyQuestion> SurveyQuestions { get; set; }

        public DbSet<SurveyAnswer> SurveyAnswers { get; set; }

        public DbSet<Module> LearningModulеs { get; set; }

        public DbSet<Course> LearningCourses { get; set; }

        public DbSet<CourseInstance> CourseInstances { get; set; }

        public DbSet<CourseTopic> CourseTopics { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder builder)
        {
            #region Quizzes builder

            builder
                .Entity<Quiz>()
                .HasKey(q => new { q.Id });

            builder
                .Entity<QuizQuestion>()
                .HasKey(qq => new { qq.Id });

            builder
                .Entity<QuizAnswer>()
                .HasKey(qa => new { qa.Id });

            builder
                .Entity<QuizQuestion>()
                .HasOne(qq => qq.Quiz)
                .WithMany(q => q.Questions)
                .HasForeignKey(q => q.QuizId);

            builder
                .Entity<QuizAnswer>()
                .HasOne(qa => qa.QuizQuestion)
                .WithMany(q => q.Answers)
                .HasForeignKey(qa => qa.QuizQuiestionId);

            builder
                .Entity<Configuration>()
                .HasKey(c => new { c.Id });

            builder
                .Entity<ConfigSchedule>()
                .HasKey(c => new { c.Id });

            builder
                .Entity<Configuration>()
                .HasOne(c => c.Quiz)
                .WithMany(q => q.Configurations)
                .HasForeignKey(c => c.QuizId);

            builder
                .Entity<ConfigSchedule>()
                .HasOne(cs => cs.Configuration)
                .WithMany(c => c.ConfigSchedules)
                .HasForeignKey(cs => cs.ConfigurationId);

            builder
                .Entity<QuizQuestion>()
                .Property(b => b.CorrectAnswerPoints)
                .HasDefaultValue(1);

            #endregion

            #region Courses builder

            builder
                .Entity<Module>()
                .HasKey(a => new { a.Id });

            builder
                .Entity<Course>()
                .HasKey(a => new { a.Id });

            builder
                .Entity<Course>()
                .HasOne(a => a.Module)
                .WithMany(a => a.Courses);

            builder
                .Entity<CourseInstance>()
                .HasKey(a => new { a.Id });

            builder
                .Entity<CourseInstance>()
                .HasOne(a => a.Course)
                .WithMany(a => a.CourseInstances);

            #endregion

            //TODO Course Lessons

            base.OnModelCreating(builder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server = LAPTOP-0C47LQP1\SQLEXPRESS; Database = TrainingAdmin; Trusted_Connection = true;", b => b.MigrationsAssembly("OpenCoursesAdmin.Data"));
        }
    }
}
