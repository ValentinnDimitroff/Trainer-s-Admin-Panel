namespace OpenCoursesAdmin.Services.Implementations
{
    using System;
    using OpenCoursesAdmin.Data;
    using OpenCoursesAdmin.Data.Models.QuizModels;
    using OpenCoursesAdmin.Services.Constants.RequestUrls;
    using OpenCoursesAdmin.Services.Models.RequestModels;
    using RestSharp;

    public class QuizsService : ExternalRequester, IQuizsService
    {
        private readonly OCADbContext dbcontext;

        public QuizsService(OCADbContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }
        
        public bool PublishQuestions(Quiz quiz)
        {
            //TODO Reflection Send Requests
            foreach (QuizQuestion quizQuestion in quiz.Questions)
            {
                try
                {
                    int type = this.GetQuestionType(quizQuestion.Type);
                    IRequestService requester = new RequestService(String.Format(RequestUrls.CreateQuizQuestion, quiz.ExternalId));
                    IRestResponse<DataList<QuizQuestion>> response = requester.SendRequest<DataList<QuizQuestion>>(Method.POST,
                        "Content", quizQuestion.Text,
                        "CorrectAnswerPoints", "1", //TODO magic number 
                        "TestId", quiz.ExternalId.ToString(),
                        "Type", type.ToString());

                    quizQuestion.ExternalId = response.Data.Data[0].Id;
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

        private int GetQuestionType(string qType)
        { 
            //TODO ENUM
            int questionType;
            switch (qType)
            {
                case "S":
                    questionType = 1;
                    break;
                case "M":
                    questionType = 2;
                    break;
                default:
                    questionType = 3;
                    break;
            }

            return questionType;
        }
    }
}
