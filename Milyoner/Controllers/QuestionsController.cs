using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Milyoner.Models;
using Milyoner.Security;
using Milyoner.Services;

namespace Milyoner.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionsController : ControllerBase
    {
        private readonly IQuestionService _questionService;

        public QuestionsController(IQuestionService questionService)
        {
            _questionService = questionService;
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddQuestionModel questionModel)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var result = await _questionService.AddAsync(new Question()
            {
                QuestionHeader = questionModel.QuestionHeader,
                TrueAnswerIndex = questionModel.TrueAnswer
            },new Answer(){
                AnsverA =questionModel.AnswerA,
                AnsverB =questionModel.AnswerB,
                AnsverC = questionModel.AnswerC,
                AnsverD = questionModel.AnswerD
                });

            if (result.IsSuccess == false)
                return BadRequest(result);

            return Ok(result);
        }
        
        [HttpGet("{id}")]
        [ApiKeyAuth]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _questionService.GetAsync(id);
            if (result.IsSuccess == false)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpGet("getall")]
        [ApiKeyAuth]
        public async Task<IActionResult> GetAll()
        {
            var result = await _questionService.GetAllAsync();
            if (result.IsSuccess == false)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpGet("getrandom")]
        [ApiKeyAuth]
        public async Task<IActionResult> GetRandom()
        {
            var result = await _questionService.GetRandomListAsync();
            if (result.IsSuccess == false)
                return BadRequest(result);

            return Ok(result);
        }    
    }
}
