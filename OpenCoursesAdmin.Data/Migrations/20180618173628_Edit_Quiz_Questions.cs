namespace OpenCoursesAdmin.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Metadata;
    using Microsoft.EntityFrameworkCore.Migrations;
    using System;

    public partial class EditQuizQuestions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Text",
                table: "QuizQuestions",
                newName: "Content");

            migrationBuilder.AlterColumn<int>(
                name: "Type",
                table: "QuizQuestions",
                maxLength: 1,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 1,
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CorrectAnswerPoints",
                table: "QuizQuestions",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.CreateTable(
                name: "LearningModulеs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LearningModulеs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SurveyQuestions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    QuestionType = table.Column<int>(nullable: false),
                    Text = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SurveyQuestions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Surveys",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CourseAverageScore = table.Column<double>(nullable: true),
                    EndDate = table.Column<DateTime>(nullable: true),
                    ExternalId = table.Column<int>(nullable: true),
                    HasEnded = table.Column<bool>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: true),
                    SurveyType = table.Column<int>(nullable: false),
                    TrainerAverageScore = table.Column<double>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Surveys", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LearningCourses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ModuleId = table.Column<int>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LearningCourses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LearningCourses_LearningModulеs_ModuleId",
                        column: x => x.ModuleId,
                        principalTable: "LearningModulеs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SurveyAnswers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    QuestionId = table.Column<int>(nullable: false),
                    Score = table.Column<int>(nullable: false),
                    Starred = table.Column<bool>(nullable: true),
                    StudentId = table.Column<int>(nullable: true),
                    SurveyId = table.Column<int>(nullable: false),
                    SurveyQuestionId = table.Column<int>(nullable: true),
                    Text = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SurveyAnswers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SurveyAnswers_Surveys_SurveyId",
                        column: x => x.SurveyId,
                        principalTable: "Surveys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SurveyAnswers_SurveyQuestions_SurveyQuestionId",
                        column: x => x.SurveyQuestionId,
                        principalTable: "SurveyQuestions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CourseInstances",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CourseId = table.Column<int>(nullable: true),
                    ExternalId = table.Column<int>(nullable: false),
                    FinalSurveyId = table.Column<int>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    MiddleSurveyId = table.Column<int>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    OnlineStudentsCount = table.Column<int>(nullable: true),
                    OnsiteStudentsCount = table.Column<int>(nullable: true),
                    SpectatorsCount = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseInstances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourseInstances_LearningCourses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "LearningCourses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CourseInstances_Surveys_FinalSurveyId",
                        column: x => x.FinalSurveyId,
                        principalTable: "Surveys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CourseInstances_Surveys_MiddleSurveyId",
                        column: x => x.MiddleSurveyId,
                        principalTable: "Surveys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CourseTopics",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CourseInstanceId = table.Column<int>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseTopics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourseTopics_CourseInstances_CourseInstanceId",
                        column: x => x.CourseInstanceId,
                        principalTable: "CourseInstances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CourseInstances_CourseId",
                table: "CourseInstances",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseInstances_FinalSurveyId",
                table: "CourseInstances",
                column: "FinalSurveyId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseInstances_MiddleSurveyId",
                table: "CourseInstances",
                column: "MiddleSurveyId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseTopics_CourseInstanceId",
                table: "CourseTopics",
                column: "CourseInstanceId");

            migrationBuilder.CreateIndex(
                name: "IX_LearningCourses_ModuleId",
                table: "LearningCourses",
                column: "ModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_SurveyAnswers_SurveyId",
                table: "SurveyAnswers",
                column: "SurveyId");

            migrationBuilder.CreateIndex(
                name: "IX_SurveyAnswers_SurveyQuestionId",
                table: "SurveyAnswers",
                column: "SurveyQuestionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseTopics");

            migrationBuilder.DropTable(
                name: "SurveyAnswers");

            migrationBuilder.DropTable(
                name: "CourseInstances");

            migrationBuilder.DropTable(
                name: "SurveyQuestions");

            migrationBuilder.DropTable(
                name: "LearningCourses");

            migrationBuilder.DropTable(
                name: "Surveys");

            migrationBuilder.DropTable(
                name: "LearningModulеs");

            migrationBuilder.DropColumn(
                name: "CorrectAnswerPoints",
                table: "QuizQuestions");

            migrationBuilder.RenameColumn(
                name: "Content",
                table: "QuizQuestions",
                newName: "Text");

            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "QuizQuestions",
                maxLength: 1,
                nullable: true,
                oldClrType: typeof(int),
                oldMaxLength: 1);
        }
    }
}
