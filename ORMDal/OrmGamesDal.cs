using Entities;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ORMDal
{
    public class OrmGamesDal : IGamesDal
    {
        public void AddGame(Entities.Game game)
        {
            var context = new DefaultDbContext();
            try
            {
                context.Games.Add(new Games()
                {
                    UserId = game.UserId,
                    Score = game.Score,
                    GameDate = DateTime.Now
                });
                context.SaveChanges();
            }
            finally
            { context.Dispose(); }
        }

        public Game GetByUserId(int id)
        {
            var context = new DefaultDbContext();
            try
            {
                var game = context.Games.FirstOrDefault(item => item.UserId == id);

                if (game == null)
                {
                    return null;
                }
                var entity = new Game()
                {
                    Id = game.Id,

                    UserId = game.UserId,

                    Score = game.Score,
                };
                return entity;
            }
            finally { context.Dispose(); }
        }
    }
}
