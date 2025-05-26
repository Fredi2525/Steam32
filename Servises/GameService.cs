using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Data.Managers;
using Data.Managers.Interfaces;
using Data.Managers2.Interfaces2;
using Entities.Account;
using Entities.Games;
using Models.Accounts;
using Models.Managers;
using Services.Interfaces;

namespace Services
{
    public class GameService : IGameService
    {
        private readonly IGameManager _gameManager;
        private readonly IMapper _maper;

        public GameService(IGameManager gameManager, IMapper maper)
        {
            _gameManager = gameManager;
            _maper = maper;
        }
        public ManagerResult<GameDto> Add(GameDto game)
        {
            var result = new ManagerResult<GameDto>();
            try
            {
                
                var dbResult = _gameManager.Add(_maper.Map<Game>(game));

                result.Success = dbResult.Success;
                result.Data = _maper.Map<GameDto>(dbResult.Data);
            }
            catch (Exception e)
            {
                result.Message = e.Message;
            }
            return result;

        }

        public ManagerResult<GameDto> GetById(Guid id)
        {
            var result = new ManagerResult<GameDto>();
            try
            {

                var dbResult = _gameManager.GetById(id);

                result.Success = dbResult.Success;
                result.Data = _maper.Map<GameDto>(dbResult.Data);
            }
            catch (Exception e)
            {
                result.Message = e.Message;
            }
            return result;

        }
        public ManagerResult<List<GameDto>> GetAll()
        {
            var result = new ManagerResult<List<GameDto>>();
            try
            {

                var dbResult = _gameManager.GetAll();

                result.Success = dbResult.Success;
               
                foreach(var item in result.Data)
                {
                    result.Data.Add(_maper.Map<GameDto>(item));
                }
            }
            catch (Exception e)
            {
                result.Message = e.Message;
            }
            return result;

        }

    }
}
