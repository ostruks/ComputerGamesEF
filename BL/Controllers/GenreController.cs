using BL.MoldesDTO;
using DAL;
using DAL.Models;
using System.Collections.Generic;

namespace BL.Controllers
{
    public class GenreController : IController<GenreDTO>
    {
        private GameRepository _gameRepository = new GameRepository();
        public GenreDTO Create(GenreDTO genre)
        {
            var result = _gameRepository.CreateGenre(Mapping.GenreFromBlToDal(genre));
            return Mapping.GenreFromDalToBl(result);
        }

        public void Delete(GenreDTO genre)
        {
            _gameRepository.DeleteGenre(Mapping.GenreFromBlToDal(genre));
        }

        public void DeleteById(int id)
        {
            _gameRepository.DeleteGenre(id);
        }

        public ICollection<GenreDTO> GetAll(int license = 0)
        {
            List<GenreDTO> result = new List<GenreDTO>();
            foreach (Genre genre in _gameRepository.GetGenres())
            {
                result.Add(Mapping.GenreFromDalToBl(genre));
            }
            return result;
        }

        public GenreDTO GetById(int Id)
        {
            return Mapping.GenreFromDalToBl(_gameRepository.GetGenre(Id));
        }

        public void Update(string name, GenreDTO genre)
        {
            _gameRepository.UpdateGenre(name, Mapping.GenreFromBlToDal(genre));
        }
    }
}
