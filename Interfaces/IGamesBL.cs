using System;
using System.Collections.Generic;
using System.Text;
using Entities;

namespace Interfaces
{
    public interface IGamesBL
    {
        Game GetByUserId(int id);
        void AddGame(Game game);
    }
}
