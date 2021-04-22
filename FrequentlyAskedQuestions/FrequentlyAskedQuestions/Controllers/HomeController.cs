using FrequentlyAskedQuestions.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace FrequentlyAskedQuestions.Controllers
{
    public class HomeController : Controller
    {
        private QuestionContext context { get; set; }

        public HomeController(QuestionContext ctx)
        {
            context = ctx;
        }

        public IActionResult Index()
        {
            var questions = context.Questions.Include(m => m.Topic).Include(_=> _.Category).OrderBy(m => m.TopicId).ToList();

            return View(questions);
        }
    }
}