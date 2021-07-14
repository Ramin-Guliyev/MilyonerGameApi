using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Milyoner.Data;
using Milyoner.Models;

namespace Milyoner.Services
{
    public class QuestionService : IQuestionService
    {
        private readonly AppDbContext _context;

        public QuestionService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel> AddAsync(Question question,Answer answer)
        {
            if (question == null && answer ==null)
            {
                return new ResponseModel()
                {
                    IsSuccess = false,
                    Message = "Null question Model"
                };
            }
            await _context.Questions.AddAsync(question);
            await _context.Answers.AddAsync(answer);
            await  _context.SaveChangesAsync();
            return new ResponseModel()
            {
                IsSuccess = true,
                Message = "Successful add operation"
            };
        }

        public async Task<ResponseDataModel<QuestionAnswerModel>> GetAsync(int id)
        {
            var getQuestion = await _context.Questions.FindAsync(id);
            var getAnswer = await _context.Answers.FindAsync(id);
            if (getQuestion == null || getQuestion.IsChecked==false)
            {
                return new ResponseDataModel<QuestionAnswerModel>()
                {
                    Message = "Question not fount or isn't active",
                    IsSuccess = false,
                };
            }
            

            var responseQuestion = new QuestionAnswerModel()
            {
                Answer =getAnswer,
                Question = getQuestion
            };

            return new ResponseDataModel<QuestionAnswerModel>()
            {
               IsSuccess = true,
               Data = responseQuestion
            };
        }

        public async Task<ResponseDataModel<IEnumerable<QuestionAnswerModel>>> GetAllAsync()
        {
            var allQuestion = await _context.Questions.Where(q=>q.IsChecked==true).ToListAsync();
            var allAnswers = await _context.Answers.ToListAsync();
            if (!(allQuestion.Count > 0))
            {
                return new ResponseDataModel<IEnumerable<QuestionAnswerModel>>()
                {
                    IsSuccess = false,
                    Message = "No question"
                };
            }

            var responseQuestionsAnswerModel = new List<QuestionAnswerModel>();

            foreach (var item in allQuestion)
            {
                var item2 = new QuestionAnswerModel()
                {
                    Question = item,
                    Answer = allAnswers.First(p => p.Id == item.Id)
                };
                responseQuestionsAnswerModel.Add(item2);
            }
            return new ResponseDataModel<IEnumerable<QuestionAnswerModel>>()
            {
                IsSuccess = true,
                Data = responseQuestionsAnswerModel
            };
        }

        public async Task<ResponseDataModel<IEnumerable<QuestionAnswerModel>>> GetRandomListAsync()
        { 
            var allQuestions = await _context.Questions.Where(q => q.IsChecked == true).ToListAsync();
            var allAnswers = await _context.Answers.ToListAsync();
            if (!(allQuestions.Count > 0))
            {
                return new ResponseDataModel<IEnumerable<QuestionAnswerModel>>()
                {
                    IsSuccess = false,
                    Message = "No question"
                };
            }
            var rnd = new Random();
            var randomTen = allQuestions.OrderBy(q => rnd.Next()).Take(10);
            
            var responseQuestions = new List<QuestionAnswerModel>();
            foreach (var item in randomTen)
            {
                var item2 = new QuestionAnswerModel()
                {
                    Question = item,
                    Answer = allAnswers.First(p=>p.Id==item.Id)
                };
                responseQuestions.Add(item2);
            }
            return new ResponseDataModel<IEnumerable<QuestionAnswerModel>>()
            {
                IsSuccess = true,
                Data =responseQuestions
            };

        }

        public async Task<ResponseModel> QuestionActivationAsync(int id)
        {
            var question = await _context.Questions.FindAsync(id);
            if (question == null || question.IsChecked == true)
                return new ResponseModel()
                {
                    IsSuccess = false,
                    Message = "Question not fount or is active"
                };

            question.IsChecked = true;
            await _context.SaveChangesAsync();
            return new ResponseModel()
            {
                IsSuccess = true
            };

        }

        public async Task<ResponseModel> QuestionDeActivationAsync(int id)
        {
            var question = await _context.Questions.FindAsync(id);
            if (question == null || question.IsChecked == false)
                return new ResponseModel()
                {
                    IsSuccess = false,
                    Message = "Question not fount or is passive"
                };

            question.IsChecked = false;
            await _context.SaveChangesAsync();
            return new ResponseModel()
            {
                IsSuccess = true
            };
        }

        public async Task<ResponseDataModel<IEnumerable<QuestionAnswerModel>>> GetAllPassiveAsync()
        {
            var allQuestion = await _context.Questions.Where(q => q.IsChecked == false).ToListAsync();
            var allAnswers = await _context.Answers.ToListAsync();

            if (!(allQuestion.Count > 0))
            {
                return new ResponseDataModel<IEnumerable<QuestionAnswerModel>>()
                {
                    IsSuccess = false,
                    Message = "No passive question"
                };
            }

            var responseQuestions = new List<QuestionAnswerModel>();
            foreach (var item in allQuestion)
            {
                var item2 = new QuestionAnswerModel()
                {
                    
                    Question =item,
                    Answer = allAnswers.First(p => p.Id == item.Id)

                };
                responseQuestions.Add(item2);

            }
            return new ResponseDataModel<IEnumerable<QuestionAnswerModel>>()
            {
                IsSuccess = true,
                Data = responseQuestions
            };
        }
    }
}
