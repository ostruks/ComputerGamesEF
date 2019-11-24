using BL.MoldesDTO;
using DAL.Models;
using System.Collections.Generic;

namespace DAL
{
    public class PublisherController : IController<PublisherDTO>
    {
        private GameRepository _gameRepository = new GameRepository();
        public PublisherDTO Create(PublisherDTO publisher)
        {
            var result = _gameRepository.CreatePublisher(Mapping.PublisherFromBlToDal(publisher));
            return Mapping.PublisherFromDalToBl(result);
        }

        public void Delete(PublisherDTO publisher)
        {
            _gameRepository.DeletePublisher(Mapping.PublisherFromBlToDal(publisher));
        }

        public void DeleteById(int id)
        {
            _gameRepository.DeleteGenre(id);
        }

        public ICollection<PublisherDTO> GetAll(int license = 0)
        {
            List<PublisherDTO> result = new List<PublisherDTO>();
            foreach (Publisher publisher in _gameRepository.GetPublishers())
            {
                result.Add(Mapping.PublisherFromDalToBl(publisher));
            }
            return result;
        }

        public PublisherDTO GetById(int Id)
        {
            return Mapping.PublisherFromDalToBl(_gameRepository.GetPublisher(Id));
        }

        public void Update(string name, PublisherDTO publisher)
        {
            _gameRepository.UpdatePublisher(name, Mapping.PublisherFromBlToDal(publisher));
        }
    }
}
