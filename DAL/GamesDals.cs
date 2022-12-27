using Entities;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;


namespace DAL
{
    internal class GamesDals : IGamesDal
    {
        private List<Game> games = new List<Game>();

        public Game GetByUserId(int userId)
        {
            return games.FirstOrDefault(item => item.UserId == userId);
        }
        public void AddGame(Game game)
        {
            games.Add(game);
        }

    }
}
