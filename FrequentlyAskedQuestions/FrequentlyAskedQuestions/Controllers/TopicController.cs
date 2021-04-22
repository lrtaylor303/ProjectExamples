using FrequentlyAskedQuestions.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrequentlyAskedQuestions.Controllers
{
    public class TopicController : Controller
    {
        private QuestionContext context { get; set; }

        public TopicController(QuestionContext ctx)
        {
            context = ctx;
        }

        [HttpGet]
        public IActionResult Bootstrap()
        {
            ViewBag.Action = "Bootstrap";
            ViewBag.Questions = context.Questions.Include(m => m.Topic).Include(_ => _.Category).Where(_ => _.Topic.Name == "Bootstrap").OrderBy(m => m.TopicId).ToList();
            return View(ViewBag.Questions);
        }

        [HttpGet]
        public IActionResult CSharp()
        {
            ViewBag.Action = "CSharp";
            ViewBag.Questions = context.Questions.Include(m => m.Topic).Include(_ => _.Category).Where(_ => _.Topic.Name == "C#").OrderBy(m => m.TopicId).ToList();
            return View(ViewBag.Questions);
        }

        [HttpGet]
        public IActionResult JavaScript()
        {
            ViewBag.Actions = "JavaScript";
            ViewBag.Questions = context.Questions.Include(m => m.Topic).Include(_ => _.Category).Where(_ => _.Topic.Name == "JavaScript").OrderBy(m => m.TopicId).ToList();
            return View(ViewBag.Questions);
        }
    }
}
