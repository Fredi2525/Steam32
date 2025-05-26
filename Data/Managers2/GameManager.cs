using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Managers2.Interfaces2;
using Entities.Account;
using Entities.Games;
using Microsoft.Extensions.DependencyInjection;
using Models.Managers;

namespace Data.Managers2
{
    public class GameManager : IGameManager
    {
        private readonly IServiceProvider _service;

        public GameManager(IServiceProvider service)
        {
            _service = service;
        }
        public ManagerResult<Game> Add(Game game)
        {
            var result = new ManagerResult<Game>();

            try
            {
                var dbContext = _service.GetRequiredService<SteamDbContext>();

              game.Created = DateTime.Now;

                dbContext.Games.Add(game);
                dbContext.SaveChanges();
                result.Data = game;
                result.Success = true;
            }
            catch (Exception e)
            {
                result.Message = e.Message;
            }
            return result;
        }
        public ManagerResult<Game> GetById(Guid id)
        {
            var result = new ManagerResult<Game>();

            var dbContext = _service.GetRequiredService<SteamDbContext>();

            var game = dbContext.Games.FirstOrDefault(x =>x.Id == id);
            if (game == null)
            {
                result.Message = "Game not foud";
                return result;
            }

            result.Data = game;
            result.Success = true;

            return result;


        }
        public ManagerResult<IQueryable<Game>> GetAll()
        {
            var result = new ManagerResult<IQueryable<Game>>();

            var dbContext = _service.GetRequiredService<SteamDbContext>();

            var games = dbContext.Games.Where(x =>!x.IsDelete);
            if (games.Any())
            {
                result.Message = "Game not foud";
                return result;
            }

            result.Data = games;
            result.Success = true;

            return result;
        }
    }
}
        
