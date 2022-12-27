﻿using BL;
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
    public class UsersController : Controller
    {
        private IUsersBL _bl;
        public UsersController(IUsersBL bl)
        {
            _bl = bl;
        }
        //private IGamesBL _blg;
        //public UsersController(IGamesBL blg)
        //{
        //    _blg = blg;
        //}
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View("Login");
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            var user = _bl.GetByLogin(loginModel.Login);


            if (user != null && user.Password == loginModel.Password)
            {
                var identity = new CustomUserIdentity(user);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity));

                return RedirectToAction("GameStart", "Home");
                //return RedirectToAction("Index", "Home");
                //return View();
            }
            else return View("Login");
        }

        public IActionResult Get(int id)
        {
            var user = _bl.GetById(id);

            if (user != null)
            {
                return View(new UserModel() { Id = user.Id, Name = $"{user.Name}" });
            }
            else
            {
                return View();
            }

        }


        [HttpGet]
        public IActionResult Registration()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Registration(RegistrationModel model)
        {

            User user = new User()
            {
                Login = model.Login,
                Name = model.Name,
                Password = model.Password
            };
            // добавляем пользователя
            _bl.AddUser(user);
            var identity = new CustomUserIdentity(user);
            // установка куки
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity));
            return RedirectToAction("GameStart", "Home");
            //return RedirectToAction("Index", "Home");
            //return RedirectToAction("Game", "Home");

        }

        //[HttpPost]
        //public async Task<IActionResult> SaveGamesResult(GameModel model)
        //{
        //    Game game = new Game()
        //    {
        //        UserId = model.UserId,
        //        Score = model.Score,
        //    };
        //    // добавляем игру
        //    _blg.AddGame(game);
        //    User user = _bl.GetById(model.UserId);
        //    var identity = new CustomUserIdentity(user);
        //    // установка куки
        //    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity));
        //    return RedirectToAction("Index", "Home");
        //    //return RedirectToAction("Game", "Home");
        //}
    }
}