using Entities;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BL
{
    public class GamesBL : IGamesBL
    {
        private IGamesDal _dal;

        public GamesBL(IGamesDal dal)
        {
            _dal = dal;
        }

        public Game GetByUserId(int id)
        {
            return _dal.GetByUserId(id);
        }
        public void AddGame(Game game)
        {
            _dal.AddGame(game);
        }
    }
}
