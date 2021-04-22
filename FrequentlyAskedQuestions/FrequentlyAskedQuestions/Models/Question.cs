using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FrequentlyAskedQuestions.Models
{
    public class Question
    {
        public int QuestionId { get; set; }
        public string QuestionText { get; set; }
        public string Answer { get; set; }
        public string TopicId { get; set; }
        public string CategoryId { get; set; }
        public Category Category { get; set; }
        public Topic Topic { get; set; }

    }
}
