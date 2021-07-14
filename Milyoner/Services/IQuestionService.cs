using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Milyoner.Models;

namespace Milyoner.Services
{
   public interface IQuestionService
    {
        Task<ResponseModel> AddAsync(Question question, Answer answer);
        Task<ResponseModel> QuestionActivationAsync(int id);
        Task<ResponseModel> QuestionDeActivationAsync(int id);
        Task<ResponseDataModel<QuestionAnswerModel>> GetAsync(int id);
        Task<ResponseDataModel<IEnumerable<QuestionAnswerModel>>> GetAllAsync();
        Task<ResponseDataModel<IEnumerable<QuestionAnswerModel>>> GetRandomListAsync();
        Task<ResponseDataModel<IEnumerable<QuestionAnswerModel>>> GetAllPassiveAsync();

    }
}
