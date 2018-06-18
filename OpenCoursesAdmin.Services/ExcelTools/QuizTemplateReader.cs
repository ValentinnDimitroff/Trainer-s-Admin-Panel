namespace OpenCoursesAdmin.Services
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using OfficeOpenXml;
    using OpenCoursesAdmin.Data.Enums;
    using OpenCoursesAdmin.Data.Models.QuizModels;

    public class QuizTemplateReader
    {
        public List<QuizQuestion> ReadTemplate(string filepath)
        {
            using (ExcelPackage package = new ExcelPackage(new FileInfo(filepath)))
            {
                ExcelWorksheet sheet = package
                    .Workbook
                    .Worksheets[0];

                List<int> correctColumns = new List<int>();
                List<int> wrongColumns = new List<int>();

                for (int colIndex = 1; colIndex <= 10; colIndex++)
                {
                    if (sheet.Cells[1, colIndex].Value.ToString().Contains("Correct"))
                    {
                        correctColumns.Add(colIndex);
                    }
                    else if (sheet.Cells[1, colIndex].Value.ToString().Contains("Wrong"))
                    {
                        wrongColumns.Add(colIndex);
                    }
                }

                List<QuizQuestion> questions = new List<QuizQuestion>();

                for (int row = 2; row < sheet.Cells.Rows - 1; row++)
                {
                    if ((sheet.Cells[row, 1]?.Value?.ToString() ?? "") == "")
                    {
                        break;
                    }

                    //TODO
                    //if (quizQuestion.Text.Length > 500)
                    //{
                    //    throw new InvalidEnumArgumentException();
                    //}
                    //TODO throw exception for empty answers columns
                    //TODO throw general exception

                    SurveyQuestionType.TryParse(this.GetQuestionType(sheet.Cells[row, 2].Value.ToString()), out SurveyQuestionType surveyQuestionType);

                    QuizQuestion question = new QuizQuestion
                    {
                        Content = sheet.Cells[row, 1].Value.ToString(),
                        Type = surveyQuestionType
                    };

                    List<QuizAnswer> answers = new List<QuizAnswer>(
                        this.GetColumnsValues(sheet, row, correctColumns)
                        .Select(answerValue => new QuizAnswer
                        {
                            Text = answerValue,
                            Correct = true
                        }));

                    answers.AddRange(new List<QuizAnswer>(
                        this.GetColumnsValues(sheet, row, wrongColumns)
                            .Select(answerValue => new QuizAnswer
                            {
                                Text = answerValue,
                                Correct = false
                            })));

                    question.Answers.AddRange(answers);
                    questions.Add(question);
                }

                return questions;
            }
        }

        private IEnumerable<string> GetColumnsValues(ExcelWorksheet sheet, int row, IEnumerable<int> columns)
        {
            List<string> values = new List<string>();

            foreach (int col in columns)
            {
                string value = sheet.Cells[row, col]?.Value?.ToString();
                if (!string.IsNullOrWhiteSpace(value))
                {
                    values.Add(value);
                }
            }

            return values;
        }

        private string GetQuestionType(string qType)
        {
            switch (qType)
            {
                case "S":
                    return nameof(SurveyQuestionType.SingleCorrectAnswer);
                case "M":
                    return nameof(SurveyQuestionType.MultipleCorrectAnswers);
                default:
                    return nameof(SurveyQuestionType.OpenAnswer);
            }
        }
    }
}