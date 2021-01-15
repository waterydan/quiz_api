using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PreezieInterview.Api.Models.DbModels;
using PreezieInterview.Api.Models.Exceptions;

namespace PreezieInterview.Api.Repositories
{
    public class QuizService
    {
        private readonly ApiContext _context;

        public QuizService(ApiContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Question>> GetQuestionsAsync()
        {
            return await _context.Questions.AsQueryable().ToListAsync();
        }

        public async Task<Question> RegisterAnswerAsync(string questionId, string quizAnswer)
        {
            var question = await _context.Questions.FirstOrDefaultAsync(q => q.Id == questionId);
            if (question == null)
            {
                throw new NotFoundException($"QuestionID not found: {questionId}.");
            }

            question.UserAnswer = quizAnswer;
            question.IsCorrect = question.CorrectAnswer.ToLower() == quizAnswer.ToLower();

            _context.Questions.Update(question);

            await _context.SaveChangesAsync();
            return question;
        }
    }
}
