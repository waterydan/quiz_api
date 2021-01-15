
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PreezieInterview.Api.Models.DbModels
{
    public enum QuestionType
    {
        SelectOne,
        Text
    }

    public class Question : DbModel
    {
        [Required]
        public string Topic { get; set; }

        [Required]
        public QuestionType Type { get; set; }

        [Required]
        [JsonIgnore]
        public string CorrectAnswer { get; set; }

        public string? UserAnswer { get; set; } = null;

        public bool? IsCorrect { get; set; } = null;

        public string[] Options { get; set; }
    }
}
