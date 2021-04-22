using Microsoft.EntityFrameworkCore;


namespace FrequentlyAskedQuestions.Models
{
    public class QuestionContext : DbContext
    {
        public QuestionContext(DbContextOptions<QuestionContext> options)
            : base(options) { }

        public DbSet<Question> Questions { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Topic> Topics { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = "G", Name = "General" },
                new Category { CategoryId = "H", Name = "History" },
                new Category { CategoryId = "O", Name = "Other" }
                );

            modelBuilder.Entity<Topic>().HasData(
                new Topic { TopicId = "B", Name = "Bootstrap" },
                new Topic { TopicId = "C", Name = "C#" },
                new Topic { TopicId = "J", Name = "JavaScript" }
                );

            modelBuilder.Entity<Question>().HasData(
                new Question
                {
                    QuestionId = 1,
                    QuestionText = "What is Bootstrap?",
                    Answer = "A CSS framework for creating responsive web apps for multiple screen sizes.",
                    TopicId = "B",
                    CategoryId = "G"
                },
                new Question
                {
                    QuestionId = 2,
                    QuestionText = "What is C#?",
                    Answer = "A general purpose object oriented language that uses a concise, Java-like syntax.",
                    TopicId = "C",
                    CategoryId = "G"
                },
                new Question
                {
                    QuestionId = 3,
                    QuestionText = "What is JavaScript?",
                    Answer = "A general purpose scripting language that executes in a web browser.",
                    TopicId = "J",
                    CategoryId = "G"
                },
                new Question
                {
                    QuestionId = 4,
                    QuestionText = "When was Bootstrap first release?",
                    Answer = "In 2011.",
                    TopicId = "B",
                    CategoryId = "H"
                },
                new Question
                {
                    QuestionId = 5,
                    QuestionText = "When was C# first released?",
                    Answer = "In 2002",
                    TopicId = "C",
                    CategoryId = "H"
                },
                new Question
                {
                    QuestionId = 6,
                    QuestionText = "When was JavaScript first released?",
                    Answer = "In 1995.",
                    TopicId = "J",
                    CategoryId = "H"
                }

                );


        }
    }
}
