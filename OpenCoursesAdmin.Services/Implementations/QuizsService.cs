namespace OpenCoursesAdmin.Services.Implementations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using OpenCoursesAdmin.Data;
    using OpenCoursesAdmin.Data.Models.QuizModels;
    using OpenCoursesAdmin.Services.Constants.RequestUrls;
    using OpenCoursesAdmin.Services.Models.RequestModels;
    using RestSharp;

    public class QuizsService : IQuizsService
    {
        private readonly OCADbContext dbcontext;
        private readonly IExternalRequester externalRequester;

        public QuizsService(OCADbContext dbcontext, IExternalRequester externalRequester)
        {
            this.dbcontext = dbcontext;
            this.externalRequester = externalRequester;
        }

        public List<Quiz> GetAllQuizzes() => this.dbcontext
                .Quizs
                .ToList();

        public void CreateQuiz(Quiz quiz)
        {
            quiz.ExternalId = this.externalRequester.CreateRecordReturnId(quiz, new[] { "Name", "Description" });

            this.dbcontext.Add(quiz);
            dbcontext.SaveChanges();
        }
        
        public bool PublishQuestions(Quiz quiz)
        {
            //TODO Reflection Send Requests
            foreach (QuizQuestion quizQuestion in quiz.Questions)
            {
                try
                {
                    quizQuestion.ExternalId = this.externalRequester
                        .CreateRecordReturnId(quizQuestion, new []{ $"Content, CorrectAnswerPoints, TestId:{quiz.ExternalId}, Type:{(int)quizQuestion.Type}" });

                    //IRequestService requester = new RequestService(String.Format(RequestUrls.CreateQuizQuestion, quiz.ExternalId));
                    //IRestResponse<DataList<QuizQuestion>> response = requester.SendRequest<DataList<QuizQuestion>>(Method.POST,
                    //    "Content", quizQuestion.Content,
                    //    "CorrectAnswerPoints", "1", //TODO magic number 
                    //    "TestId", quiz.ExternalId.ToString(),
                    //    "Type", type.ToString());

                    //quizQuestion.ExternalId = response.Data.Data[0].Id;
                }
                catch (Exception e)
                {
                    //TODO throw;
                    return false;
                }

                if (!this.AddAnswers(quizQuestion))
                {
                    return false;
                }
            }

            this.dbcontext.Update(quiz);
            this.dbcontext.SaveChanges();

            return true;
        }

        private bool AddAnswers(QuizQuestion quizQuestion)
        {
            try
            {
                IRequestService requestService = new RequestService(String.Format(RequestUrls.CreateQuizAnswer, quizQuestion.ExternalId));

                foreach (QuizAnswer quizAnswer in quizQuestion.Answers)
                {
                    //TODO reflection
                    IRestResponse<DataList<QuizAnswer>> response = requestService.SendRequest<DataList<QuizAnswer>>(
                        Method.POST,
                        "Content", quizAnswer.Text,
                        "IsCorrect", quizAnswer.Correct.ToString(),
                        "QuestionId", quizQuestion.ExternalId.ToString());

                    quizAnswer.ExternalId = response.Data.Data[0].Id;
                }
            }
            catch (Exception e)
            {
                //TODO Error log
                return false;
            }

            return true;
        }
    }
}
