using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Milyoner.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Milyoner.Security;

namespace Milyoner.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AdminApiKeyAuth]
    public class AdminController : ControllerBase
    {
        private readonly IQuestionService _questionService;

        public AdminController(IQuestionService questionService)
        {
            _questionService = questionService;
        }

        [HttpPost("activate")]
        public async Task<IActionResult> Activate(int id)
        {
            var result = await _questionService.QuestionActivationAsync(id);
            if (result.IsSuccess == false)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpGet("getallpassive")]
        public async Task<IActionResult> GetAllPassive()
        {
            var result = await _questionService.GetAllPassiveAsync();
            if (result.IsSuccess == false)
                return BadRequest(result);

            return Ok(result);
        }
        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _questionService.GetAllAsync();
            if (result.IsSuccess == false)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPost("deactivate")]
        public async Task<IActionResult> DeActivate(int id)
        {
            var result = await _questionService.QuestionDeActivationAsync(id);
            if (result.IsSuccess == false)
                return BadRequest(result);

            return Ok(result);
        }
    }
}
