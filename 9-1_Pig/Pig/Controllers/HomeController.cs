using Microsoft.AspNetCore.Mvc;
using Pig.Models;
using Microsoft.AspNetCore.Http;
using System;

namespace Pig.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            // get game object from session
            var gameSession = HttpContext.Session.GetString("Game");
            var game = !string.IsNullOrEmpty(gameSession) ? Newtonsoft.Json.JsonConvert.DeserializeObject<Game>(gameSession) : new Game() { Player1 = new Player() { Name = "Player 1", Score = 0 }, Player2 = new Player() { Name = "Player 2", Score = 0 }, CurrentPlayerName = "Player 1", CurrentTurnScore = 0, LastRoll = 0};

            // notify if there's a winner 
            if (game.Player1.Score == Game.WinningNumber || game.Player2.Score > Game.WinningNumber)
            {
                //player 1 wins
                TempData["message"] = game.Player1.Name + " wins!";
            }

            else if (game.Player2.Score == Game.WinningNumber || game.Player1.Score > Game.WinningNumber)
            {
                //player 2 wins
                TempData["message"] = game.Player2.Name + " wins!";
            }

            else if (game.LastRoll == 1)
            {
                //end player turn
                bool isPlayer1Turn = game.CurrentPlayerName == game.Player1.Name;
                game.CurrentTurnScore = isPlayer1Turn ? game.Player2.Score : game.Player1.Score;
                game.CurrentPlayerName = isPlayer1Turn ? game.Player2.Name : game.Player1.Name;
                game.LastRoll = 0;
            }

            // pass game object to view
            HttpContext.Session.SetString("Game", Newtonsoft.Json.JsonConvert.SerializeObject(game));

            return View(game);

        }

        [HttpPost]
        public IActionResult NewGame()
        {
            var gameSession = HttpContext.Session.GetString("Game");
            if (string.IsNullOrEmpty(gameSession))
            {
                return RedirectToAction("Index");
            }
            // get game object from session
            var player1 = new Player()
            {
                Name = "Player 1",
                Score = 0
            };
            var player2 = new Player()
            {
                Name = "Player 2",
                Score = 0
            };
            var newGame = new Game()
            {
                Player1 = player1,
                Player2 = player2,
                CurrentPlayerName = player1.Name,
                CurrentTurnScore = player1.Score,
                LastRoll = 0
            };

            // store game object in session and redirect (PRG pattern)
            HttpContext.Session.SetString("Game", Newtonsoft.Json.JsonConvert.SerializeObject(newGame));

            return RedirectToAction("Index");
        }

        [HttpPost]
        public RedirectToActionResult Roll()
        {
            var gameSession = HttpContext.Session.GetString("Game");
            if (string.IsNullOrEmpty(gameSession))
            {
                return RedirectToAction("Index");
            }
            // get game object from session
            var game = Newtonsoft.Json.JsonConvert.DeserializeObject<Game>(HttpContext.Session.GetString("Game"));

            Random rand = new Random();
            int roll = rand.Next(1, 7);
            game.CurrentTurnScore = game.CurrentTurnScore + roll;
            game.LastRoll = roll;
            bool isPlayer1Turn = game.CurrentPlayerName == game.Player1.Name;
            if (isPlayer1Turn)
            {
                game.Player1.Score = game.CurrentTurnScore;
            } else
            {
                game.Player2.Score = game.CurrentTurnScore;
            }

            // store game object in session and redirect (PRG pattern)
            HttpContext.Session.SetString("Game", Newtonsoft.Json.JsonConvert.SerializeObject(game));

            return RedirectToAction("Index");
        }

        [HttpPost]
        public RedirectToActionResult Hold()
        {
            var gameSession = HttpContext.Session.GetString("Game");
            if (string.IsNullOrEmpty(gameSession))
            {
                return RedirectToAction("Index");
            }
            // get game object from session
            var game = Newtonsoft.Json.JsonConvert.DeserializeObject<Game>(HttpContext.Session.GetString("Game"));
            bool isPlayer1Turn = game.CurrentPlayerName == game.Player1.Name;
            game.CurrentTurnScore = isPlayer1Turn ? game.Player2.Score : game.Player1.Score;
            game.CurrentPlayerName = isPlayer1Turn ? game.Player2.Name : game.Player1.Name;
            game.LastRoll = 0;

            // store game object in session and redirect (PRG pattern)
            HttpContext.Session.SetString("Game", Newtonsoft.Json.JsonConvert.SerializeObject(game));

            return RedirectToAction("Index");
        }
    }
}
