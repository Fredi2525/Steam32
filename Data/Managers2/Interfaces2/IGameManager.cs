using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Games;
using Models.Managers;

namespace Data.Managers2.Interfaces2
{
    public interface IGameManager
    {        
        ManagerResult<Game> Add(Game game);
        ManagerResult<Game> GetById (Guid id);
    }
}
