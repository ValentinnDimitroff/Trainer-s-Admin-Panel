namespace OpenCoursesAdmin.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using Models;
    using Models.QuizModels;
    using Models.QuizModels.ConfigurationModels;

    public class OCADbContext : IdentityDbContext<User>
    {
        public OCADbContext(DbContextOptions<OCADbContext> options)
            : base(options)
        {
        }

        public DbSet<Quiz> Quizs { get; set; }

        public DbSet<QuizQuestion> QuizQuestions { get; set; }

        public DbSet<QuizAnswer> QuizAnswers { get; set; }

        public DbSet<Configuration> Configurations { get; set; }

        public DbSet<ConfigSchedule> ConfigSchedules { get; set; }
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Entity<Quiz>()
                .HasKey(q => new { q.Id });

            builder
                .Entity<QuizQuestion>()
                .HasKey(qq => new {qq.Id});

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
                .HasKey(c => new {c.Id});

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

            base.OnModelCreating(builder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server = LAPTOP-0C47LQP1\SQLEXPRESS; Database = TrainingAdmin; Trusted_Connection = true;", b => b.MigrationsAssembly("OpenCoursesAdmin.Data"));
        }
    }
}
