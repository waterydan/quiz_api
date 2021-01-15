using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PreezieInterview.Api.Models.DbModels;
using PreezieInterview.Api.Models.Dtos;
using PreezieInterview.Api.Models.Exceptions;
using PreezieInterview.Api.Repositories;

namespace PreezieInterview.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class QuizController : ControllerBase
    {
        private readonly QuizService _quizService;

        public QuizController(QuizService quizService)
        {
            _quizService = quizService;
        }

        [HttpGet]
        public async Task<IEnumerable<Question>> Get()
        {
            // In real world this should be returned as a DTO to hide underlying data model from client.
            return await _quizService.GetQuestionsAsync();
        }

        [HttpPost]
        public async Task<IActionResult> Post(RegisterAnswerDto dto)
        {
            try
            {
                var result = await _quizService.RegisterAnswerAsync(dto.QuestionId, dto.Answer);
                return Ok(result);
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }
        }
    }
}
