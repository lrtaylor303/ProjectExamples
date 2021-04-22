using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using TicTacToe.Models;

namespace TicTacToe.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ViewResult Index()
        {
            var modelJson = HttpContext.Session.GetString("Model");
            // create view model to pass to view
            var model = string.IsNullOrEmpty(modelJson) ? new TicTacToeViewModel { } : Newtonsoft.Json.JsonConvert.DeserializeObject<TicTacToeViewModel>(modelJson);
            model.Selected = model.Selected != null ? model.Selected : new Cell() { Id = "none", Mark = "X" };

            var newGame = new TicTacToeBoard();


            model.Cells = model.Cells != null && !model.IsGameOver ? model.Cells : newGame.GetCells();
            // add default for first time page loads
            model = model.IsGameOver ? GetDefaultTicTacToeViewModel(model) : model;

            // reset mark 
            if(string.IsNullOrEmpty(modelJson))
                model.Cells.ForEach(_ => _.Mark = string.Empty);

            // game continues - keep values in TempData
            HttpContext.Session.SetString("Model", Newtonsoft.Json.JsonConvert.SerializeObject(model));


            return View(model);
        }

        private TicTacToeViewModel GetDefaultTicTacToeViewModel(TicTacToeViewModel model)
        {
            if (model == null)
                model = new TicTacToeViewModel();

            model.IsGameOver = false;
            return model;
        }

        [HttpPost]
        public RedirectToActionResult Index(TicTacToeViewModel vm)
        {
            // store selected cell in TempData 
            TempData["Cell Selected"] = Newtonsoft.Json.JsonConvert.SerializeObject(vm.Selected);

                var modelJSON = HttpContext.Session.GetString("Model");
                var model = Newtonsoft.Json.JsonConvert.DeserializeObject<TicTacToeViewModel>(modelJSON);
            if (vm.Selected != null)
            {
                model.Cells.FirstOrDefault(_ => _.Id == vm.Selected.Id).Mark = vm.Selected.Mark;
            }
            var newGame = new TicTacToeBoard();
            if (model.Cells != null && model.Cells.Any())
                newGame.CheckForWinner(model.Cells);

            if (newGame.HasWinner)
            {
                TempData["message"] = $"{model.Selected.Mark} Wins!";
                model.IsGameOver = true;
            }
            else if (newGame.HasAllCellsSelected)
            {
                TempData["message"] = $"You filled out all of the options! No more plays possible! Why!?!?!?!?";
                model.IsGameOver = true;
            }
            else
            {
                model.IsGameOver = false;
                TempData["message"] = $"";
            }

            // determine next turn based on current mark and store in TempData 
            if (vm.Selected.Mark == "X")
            {
                model.Selected.Mark = "O";
            } if (vm.Selected.Mark == "O")
            {
                model.Selected.Mark = "X";
            } else if (vm.Selected.Mark == null)
            {
                model.Selected.Mark = "X";
            }
            HttpContext.Session.SetString("Model", Newtonsoft.Json.JsonConvert.SerializeObject(model));
            return RedirectToAction("Index");
        }


    }
}