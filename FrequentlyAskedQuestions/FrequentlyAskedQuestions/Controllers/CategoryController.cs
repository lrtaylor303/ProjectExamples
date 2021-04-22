using FrequentlyAskedQuestions.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrequentlyAskedQuestions.Controllers
{
    public class CategoryController : Controller
    {
        private QuestionContext context { get; set; }

        public CategoryController(QuestionContext ctx)
        {
            context = ctx;
        }

        [HttpGet]
        public IActionResult General()
        {
            ViewBag.Action = "General";
            ViewBag.Questions = context.Questions.Include(m => m.Topic).Include(_ => _.Category).Where(_ => _.Category.Name == "General").OrderBy(m => m.TopicId).ToList();
            return View(ViewBag.Questions);
        }

        [HttpGet]
        public IActionResult History()
        {
            ViewBag.Action = "History";
            ViewBag.Questions = context.Questions.Include(m => m.Topic).Include(_ => _.Category).Where(_ => _.Category.Name == "History").OrderBy(m => m.TopicId).ToList();
            return View(ViewBag.Questions);
        }
    }
}
