using System.ComponentModel.DataAnnotations;

namespace PreezieInterview.Api.Models.Dtos
{
    public class RegisterAnswerDto
    {
        [Required]
        public string QuestionId { get; set; }

        [Required]
        public string Answer { get; set; }
    }
}
