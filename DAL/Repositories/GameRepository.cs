using DAL.Models;
using System.Collections.Generic;
using System.Linq;

namespace DAL
{
    public class GameRepository
    {
        public List<Game> GetGames(int license = 0)
        {
            using (GameDBContext db = new GameDBContext())
            {
                return license == 0 ? db.Games.Include("Publisher").Include("Genre").ToList() : db.Games.Include("Publisher").Include("Genre").Where(s => s.Publisher.License == license).ToList();
            }
        }

        public List<Genre> GetGenres()
        {
            using (GameDBContext db = new GameDBContext())
            {
                return db.Genres.ToList();
            }
        }

        public List<Publisher> GetPublishers()
        {
            using (GameDBContext db = new GameDBContext())
            {
                return db.Publishers.ToList();
            }
        }

        public Game GetGame(int id)
        {
            using (GameDBContext db = new GameDBContext())
            {
                return id != 0 ? db.Games.Include("Publisher").Include("Genre").Where(game => game.Id == id).FirstOrDefault() : null;
            }
        }

        public Genre GetGenre(int id)
        {
            using (GameDBContext db = new GameDBContext())
            {
                return id != 0 ? db.Genres.Where(game => game.Id == id).FirstOrDefault() : null;
            }
        }

        public Publisher GetPublisher(int id)
        {
            using (GameDBContext db = new GameDBContext())
            {
                return id != 0 ? db.Publishers.Where(game => game.Id == id).FirstOrDefault() : null;
            }
        }

        public Game CreateGame(Game game)
        {
            using (GameDBContext db = new GameDBContext())
            {
                db.Games.Add(game);
                db.SaveChanges();
            }
            return game;
        }

        public Genre CreateGenre(Genre genre)
        {
            using (GameDBContext db = new GameDBContext())
            {
                db.Genres.Add(genre);
                db.SaveChanges();
            }
            return genre;
        }

        public Publisher CreatePublisher(Publisher publisher)
        {
            using (GameDBContext db = new GameDBContext())
            {
                db.Publishers.Add(publisher);
                db.SaveChanges();
            }
            return publisher;
        }

        public void UpdateGame(string name, Game game)
        {
            using (GameDBContext db = new GameDBContext())
            {
                var Upgame = db.Games.Where(g => g.Name == name).FirstOrDefault();
                Upgame.Name = game.Name;
                Upgame.YearOfIssue = game.YearOfIssue;
                Upgame.Genre_Id = game.Genre_Id;
                Upgame.Publisher_Id = game.Publisher_Id;
                db.SaveChanges();
            }
        }

        public void UpdateGenre(string name, Genre genre)
        {
            using (GameDBContext db = new GameDBContext())
            {
                var Upgenre = db.Genres.Where(g => g.Name == name).FirstOrDefault();
                Upgenre.Name = genre.Name;
                Upgenre.Description = genre.Description;
                db.SaveChanges();
            }
        }

        public void UpdatePublisher(string name, Publisher publisher)
        {
            using (GameDBContext db = new GameDBContext())
            {
                var Uppublisher = db.Publishers.Where(g => g.Name == name).FirstOrDefault();
                Uppublisher.Name = publisher.Name;
                Uppublisher.License = publisher.License;
                db.SaveChanges();
            }
        }

        public void DeleteGame(int id)
        {
            using (GameDBContext db = new GameDBContext())
            {
                if(db.Games.Any(g => g.Id == id))
                {
                    db.Games.Remove(db.Games.Where(g => g.Id == id).FirstOrDefault());
                    db.SaveChanges();
                }
            }
        }

        public void DeleteGame(Game game)
        {
            using (GameDBContext db = new GameDBContext())
            {
                if (db.Games.Any(g => g.Id == game.Id))
                {
                    db.Games.Remove(game);
                    db.SaveChanges();
                }
            }
        }

        public void DeleteGenre(int id)
        {
            using (GameDBContext db = new GameDBContext())
            {
                if (db.Genres.Any(g => g.Id == id))
                {
                    db.Genres.Remove(db.Genres.Where(g => g.Id == id).FirstOrDefault());
                    db.SaveChanges();
                }
            }
        }

        public void DeleteGenre(Genre genre)
        {
            using (GameDBContext db = new GameDBContext())
            {
                if (db.Games.Any(g => g.Id == genre.Id))
                {
                    db.Genres.Remove(genre);
                    db.SaveChanges();
                }
            }
        }

        public void DeletePublisher(int id)
        {
            using (GameDBContext db = new GameDBContext())
            {
                if (db.Publishers.Any(g => g.Id == id))
                {
                    db.Publishers.Remove(db.Publishers.Where(g => g.Id == id).FirstOrDefault());
                    db.SaveChanges();
                }
            }
        }

        public void DeletePublisher(Publisher publisher)
        {
            using (GameDBContext db = new GameDBContext())
            {
                if (db.Games.Any(g => g.Id == publisher.Id))
                {
                    db.Publishers.Remove(publisher);
                    db.SaveChanges();
                }
            }
        }
    }
}
