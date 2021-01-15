using System;
using Microsoft.EntityFrameworkCore;
using PreezieInterview.Api.Models.DbModels;

namespace PreezieInterview.Api.Repositories
{
    public class ApiContext : DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> options)
             : base(options)
        {
        }

        public DbSet<Question> Questions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Question>()
                .Property(e => e.Options)
                .HasConversion(
                    v => string.Join(',', v),
                    v => v.Split(',', StringSplitOptions.RemoveEmptyEntries));

            base.OnModelCreating(modelBuilder);
        }
    }

    public static class TestData
    {
        public static void Seed(ApiContext context)
        {
            var question1 = new Question
            {
                Topic = "Select a characters who appear in every Star Wars movie.",
                Type = QuestionType.SelectOne,
                Options = new[] { "Luke Skywalker", "C-3PO", "Leia Organa", "Han Solo", "Obi-Wan Kenobi" },
                CorrectAnswer = "C-3PO",
            };
            context.Questions.Add(question1);

            var question2 = new Question
            {
                Topic = "Who played Princess Leia?",
                Type = QuestionType.Text,
                CorrectAnswer = "Carrie Fisher"
            };
            context.Questions.Add(question2);

            var question3 = new Question
            {
                Topic = "In what year the original Star Wars film was first released?",
                Type = QuestionType.SelectOne,
                Options = new[] { "1975", "1976", "1977", "1978", "1979" },
                CorrectAnswer = "1977"
            };
            context.Questions.Add(question3);

            var question4 = new Question
            {
                Topic = "How old was Yoda when he died?",
                Type = QuestionType.SelectOne,
                Options = new[] { "700", "800", "850", "900", "950" },
                CorrectAnswer = "900"
            };
            context.Questions.Add(question4);

            var question5 = new Question
            {
                Topic = "What does AT-AT stand for?",
                Type = QuestionType.Text,
                CorrectAnswer = "All Terrain Armored Transport"
            };
            context.Questions.Add(question5);

            context.SaveChanges();
        }
    }
}
