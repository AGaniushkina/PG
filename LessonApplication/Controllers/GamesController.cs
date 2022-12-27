using BL;
using Entities;
using Interfaces;
using pacmanGame.Models.Users;
using pacmanGame.Models.Games;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;



namespace pacmanGame.Controllers
{
    public class GamesController : Controller
    {
        private IGamesBL _bl;
        public GamesController(IGamesBL bl)
        {
            _bl = bl;
        }
        //public IActionResult Index()
        //{
        //    return View();
        //}

        //public IActionResult Get(int id)
        //{
        //    var game = _bl.GetByUserId(id);

        //    if (game != null)
        //    {
        //        return View(new GameModel() { Id = game.Id, UserId = game.UserId, Score = game.Score });
        //    }
        //    else
        //    {
        //        return View();
        //    }

        //}



        [HttpGet]
        public IActionResult SaveGameResult()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SaveGameResult(GameModel model)
        {
            Game game = new Game()
            {
                UserId = model.UserId,
                Score = model.Score,
            };
            // добавляем игру
            _bl.AddGame(game);
            
            return RedirectToAction("SaveGameResult", "Games");

        }
    }
}
