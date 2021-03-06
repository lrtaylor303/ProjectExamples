// <auto-generated />
using FrequentlyAskedQuestions.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FrequentlyAskedQuestions.Migrations
{
    [DbContext(typeof(QuestionContext))]
    partial class QuestionContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FrequentlyAskedQuestions.Models.Category", b =>
                {
                    b.Property<string>("CategoryId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            CategoryId = "G",
                            Name = "General"
                        },
                        new
                        {
                            CategoryId = "H",
                            Name = "History"
                        },
                        new
                        {
                            CategoryId = "O",
                            Name = "Other"
                        });
                });

            modelBuilder.Entity("FrequentlyAskedQuestions.Models.Question", b =>
                {
                    b.Property<int>("QuestionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Answer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CategoryId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("QuestionText")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TopicId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("QuestionId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("TopicId");

                    b.ToTable("Questions");

                    b.HasData(
                        new
                        {
                            QuestionId = 1,
                            Answer = "A CSS framework for creating responsive web apps for multiple screen sizes.",
                            CategoryId = "G",
                            QuestionText = "What is Bootstrap?",
                            TopicId = "B"
                        },
                        new
                        {
                            QuestionId = 2,
                            Answer = "A general purpose object oriented language that uses a concise, Java-like syntax.",
                            CategoryId = "G",
                            QuestionText = "What is C#?",
                            TopicId = "C"
                        },
                        new
                        {
                            QuestionId = 3,
                            Answer = "A general purpose scripting language that executes in a web browser.",
                            CategoryId = "G",
                            QuestionText = "What is JavaScript?",
                            TopicId = "J"
                        },
                        new
                        {
                            QuestionId = 4,
                            Answer = "In 2011.",
                            CategoryId = "H",
                            QuestionText = "When was Bootstrap first release?",
                            TopicId = "B"
                        },
                        new
                        {
                            QuestionId = 5,
                            Answer = "In 2002",
                            CategoryId = "H",
                            QuestionText = "When was C# first released?",
                            TopicId = "C"
                        },
                        new
                        {
                            QuestionId = 6,
                            Answer = "In 1995.",
                            CategoryId = "H",
                            QuestionText = "When was JavaScript first released?",
                            TopicId = "J"
                        });
                });

            modelBuilder.Entity("FrequentlyAskedQuestions.Models.Topic", b =>
                {
                    b.Property<string>("TopicId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TopicId");

                    b.ToTable("Topics");

                    b.HasData(
                        new
                        {
                            TopicId = "B",
                            Name = "Bootstrap"
                        },
                        new
                        {
                            TopicId = "C",
                            Name = "C#"
                        },
                        new
                        {
                            TopicId = "J",
                            Name = "JavaScript"
                        });
                });

            modelBuilder.Entity("FrequentlyAskedQuestions.Models.Question", b =>
                {
                    b.HasOne("FrequentlyAskedQuestions.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId");

                    b.HasOne("FrequentlyAskedQuestions.Models.Topic", "Topic")
                        .WithMany()
                        .HasForeignKey("TopicId");

                    b.Navigation("Category");

                    b.Navigation("Topic");
                });
#pragma warning restore 612, 618
        }
    }
}
