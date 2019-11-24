using BL.MoldesDTO;
using DAL;
using DAL.Models;
using System.Collections.Generic;

namespace BL.Controllers
{
    public class GameController : IController<GameDTO>
    {
        private GameRepository _gameRepository = new GameRepository();
        public GameDTO Create(GameDTO game)
        {
            var result = _gameRepository.CreateGame(Mapping.GameFromBlToDal(game));
            return Mapping.GameFromDalToBl(result);
        }

        public void Delete(GameDTO game)
        {
            _gameRepository.DeleteGame(Mapping.GameFromBlToDal(game));
        }

        public void DeleteById(int id)
        {
            _gameRepository.DeleteGame(id);
        }

        public ICollection<GameDTO> GetAll(int license = 0)
        {
            List<GameDTO> result = new List<GameDTO>();
            foreach (Game game in _gameRepository.GetGames(license))
            {
                result.Add(Mapping.GameFromDalToBl(game));
            }
            return result;
        }

        public GameDTO GetById(int Id)
        {
            return Mapping.GameFromDalToBl(_gameRepository.GetGame(Id));
        }

        public void Update(string name, GameDTO game)
        {
            _gameRepository.UpdateGame(name, Mapping.GameFromBlToDal(game));
        }
    }
}
