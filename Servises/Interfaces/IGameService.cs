using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Accounts;
using Models.Managers;

namespace Services.Interfaces
{
    public interface IGameService
    {
        ManagerResult<GameDto> Add(GameDto game);
        ManagerResult<GameDto> GetById(Guid id);
        ManagerResult<List<GameDto>> GetAll(); 

    }
}
