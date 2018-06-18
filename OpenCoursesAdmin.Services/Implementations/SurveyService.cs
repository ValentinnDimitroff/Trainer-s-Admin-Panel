namespace OpenCoursesAdmin.Services.Implementations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using OpenCoursesAdmin.Data.Enums;
    using OpenCoursesAdmin.Data.Models.SurveyModels;
    using OpenCoursesAdmin.Services.Constants;
    using OpenCoursesAdmin.Services.Constants.RequestUrls;
    using OpenCoursesAdmin.Services.Interfaces;
    using TAS.Dto.RequestDtos;

    public class SurveyService : ISurveyService
    {
        private readonly IExternalRequester externalRequester;

        public SurveyService(IExternalRequester externalRequester)
        {
            this.externalRequester = externalRequester;
        }

        public Survey GetMiddleSurvey(string courseInstanceName) => this.GetSurvey(courseInstanceName, SurveyType.Middle);

        public Survey GetFinalSurvey(string courseInstanceName) => this.GetSurvey(courseInstanceName, SurveyType.Final);

        private Survey GetSurvey(string courseInstanceName, SurveyType surveyType)
        {
            int surveyId;
            try
            {
                surveyId = this.FindSurveyId(courseInstanceName, surveyType);
            }
            catch (Exception e)
            {
                return null;
            }

            Survey survey = new Survey
            {
                ExternalId = surveyId,
                SurveyType = surveyType
            };

            List<SurveyAnswerDto> answers = this.GetSurveyAnswers(survey.ExternalId);

            List<SurveyAnswer> convertedAnswers = this.GetConvertedAnswers(answers);

            List<SurveyQuestion> questions = this.CollectSurveyQuestions();

            survey.CourseAverageScore = this.GetCourseRating(survey, convertedAnswers, questions);
            survey.TrainerAverageScore = this.GetTrainersRating(survey, convertedAnswers, questions);

            return survey;
        }

        private double? GetCourseRating(Survey survey, List<SurveyAnswer> convertedAnswers, List<SurveyQuestion> questions) =>
            this.GetAverageRating(survey, convertedAnswers, questions, "CourseRating");

        private double? GetTrainersRating(Survey survey, List<SurveyAnswer> convertedAnswers, List<SurveyQuestion> questions) =>
            this.GetAverageRating(survey, convertedAnswers, questions, "TrainerRating");

        private double? GetAverageRating(Survey survey, List<SurveyAnswer> surveyAnswers, List<SurveyQuestion> questions, string questionType)
        {
            string constantName = questionType + (survey.SurveyType == 0 ? "" : survey.SurveyType.ToString());
            string question = this.GetConstantFieldValue(constantName, typeof(SurveyQuestions));
            
            int questionId = questions
                .SingleOrDefault(q => q.Text == question)
                .Id;

            double averageAnswerRating = surveyAnswers
                .Where(a => a.QuestionId == questionId)
                .Select(a => a.Score)
                .Average();

            return Math.Round(averageAnswerRating, 2);
        }

        private int FindSurveyId(string courseInstanceName, SurveyType surveyType)
        {
            string surveyTypeName = this.GetConstantFieldValue(surveyType + "Survey", typeof(SurveyNameEndings)) ?? "";
            string filterValue = $"Name~eq~'{courseInstanceName + surveyTypeName}'";

            return this.externalRequester
                .GetListOfItems<Survey>(RequestUrls.GetAllSurveys, new[] { "filter", filterValue })
                .FirstOrDefault()
                .Id; ;
        }

        private string GetConstantFieldValue(string constantName, Type constantsClass) => (string)constantsClass
                .GetField(constantName, BindingFlags.Public | BindingFlags.Static)
                ?.GetRawConstantValue();

        private List<SurveyAnswerDto> GetSurveyAnswers(int? surveyId, string questionFilter = "")
        {
            if (questionFilter != "")
            {
                questionFilter = "~and~Question~eq~'" + questionFilter + "'";
            }

            string filterValue = "SurveyId~eq~" + surveyId + questionFilter;

            return this.externalRequester.GetListOfItems<SurveyAnswerDto>(RequestUrls.GetSurveyAnswers, new[] { "filter", filterValue });
        }

        private List<SurveyAnswer> GetConvertedAnswers(List<SurveyAnswerDto> answers)
        {
            List<SurveyQuestion> questions = this.CollectSurveyQuestions();
            List<SurveyAnswer> convertedAnswers = new List<SurveyAnswer>();

            foreach (SurveyAnswerDto answer in answers)
            {
                convertedAnswers.Add(ConvertAnswer(answer, questions));
            }

            return convertedAnswers;
        }

        private List<SurveyQuestion> CollectSurveyQuestions()
        {
            List<SurveyQuestion> questions = new List<SurveyQuestion>();

            int countId = 1;
            foreach (KeyValuePair<int, List<string>> surveyQuestion in SurveyQuestions.AllSurveyQuestions)
            {
                foreach (string questionText in surveyQuestion.Value)
                {
                    questions.Add(new SurveyQuestion()
                    {
                        Id = countId,
                        QuestionType = (QuestionType)surveyQuestion.Key,
                        Text = questionText
                    });

                    countId++;
                }
            }

            return questions;
        }

        private SurveyAnswer ConvertAnswer(SurveyAnswerDto answer, List<SurveyQuestion> questions)
        {
            SurveyQuestion questionFound = questions
                .SingleOrDefault(q => q.Text == answer.Question);

            try
            {
                SurveyAnswer convAnswer = new SurveyAnswer()
                {
                    Id = answer.Id,
                    QuestionId = questionFound.Id,
                    SurveyId = answer.SurveyId
                };

                if (questionFound.QuestionType == QuestionType.Rating)
                {
                    convAnswer.Score = int.Parse(answer.Answer.Substring(0, 1));
                }
                else
                {
                    convAnswer.Text = answer.Answer;
                }

                return convAnswer; 
            }
            catch (Exception e)
            {
                throw new ArgumentException(answer.Question);
            }

            //TODO Add students from DB
            //convAnswer.StudentId = null 
            //?.SingleOrDefault(st => st.UserName == answer.UserName)
            //?.Id;
        }
    }
}
