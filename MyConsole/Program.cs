using Library.Entities;
using Repositories;
using System;

namespace MyConsole
{
    class Program
    {
        static GameRepository db = new GameRepository();

        static void Main(string[] args)
        {
            Display("Games");
            Display("Games", 123456);
            Display("Genres");
            Display("Publishers");
            DisplayById("Games", 1);
            DisplayById("Genres", 1);
            DisplayById("Publishers", 1);

            Create("Games", new Game()
            {
                Name = "Chuvak",
                YearOfIssue = 2018,
                Genre = new Genre() { Name = "MMORPG", Description = "Description MMORPG" },
                Publisher = new Publisher() { Name = "Man", License = 111222 }
            });

            Update("MMORPG", "Genres", new Genre() { Name = "MMORPG2", Description = "Description MMORPG" });
            Update("Man", "Publishers", new Publisher() { Name = "Man2", License = 111333 });
            Update("Chuvak", "Games", new Game()
            {
                Name = "Chuvak2",
                YearOfIssue = 2018,
                Genre_Id = 2,
                Publisher_Id = 2
            });

            Display("Games");
            Display("Genres");
            Display("Publishers");

            Delete("Games", 4);
            Delete("Publishers", 4);
            Delete("Genres", 4);

            Display("Games");
            Display("Genres");
            Display("Publishers");

            Create("Games", new Game()
            {
                Name = "Chuvak",
                YearOfIssue = 1965,
                Genre_Id = 1,
                Publisher_Id = 1
            });

            Console.ReadKey();
        }

        private static void Create<T>(string table, T tclass) where T : class
        {
            switch (table)
            {
                case "Publishers":
                    Publisher publisher = tclass as Publisher;
                    Console.WriteLine(db.CreatePublisher(publisher));
                    break;
                case "Genres":
                    Genre genre = tclass as Genre;
                    Console.WriteLine(db.CreateGenre(genre));
                    break;
                case "Games":
                    Game game = tclass as Game;
                    Console.WriteLine(db.CreateGame(game));
                    break;
            }
        }

        private static void Update<T>(string name, string table, T tclass)
        {
            switch (table)
            {
                case "Publishers":
                    Publisher publisher = tclass as Publisher;
                    db.UpdatePublisher(name, publisher);
                    break;
                case "Genres":
                    Genre genre = tclass as Genre;
                    db.UpdateGenre(name, genre);
                    break;
                case "Games":
                    Game game = tclass as Game;
                    db.UpdateGame(name, game);
                    break;
            }
        }

        private static void Delete(string table, int id)
        {
            switch (table)
            {
                case "Games":
                    db.DeleteGame(id);
                    break;
                case "Genres":
                    db.DeleteGenre(id);
                    break;
                case "Publishers":
                    db.DeletePublisher(id);
                    break;
            }
        }

        private static void Display(string table, int license = 0)
        {
            switch (table)
            {
                case "Games":
                    var games = license != 0 ? db.GetGames(license) : db.GetGames();

                    foreach (var game in games)
                    {
                        Console.WriteLine(game);
                    }
                    break;
                case "Genres":
                    foreach (var genre in db.GetGenres())
                    {
                        Console.WriteLine(genre);
                    }
                    break;
                case "Publishers":
                    foreach (var publisher in db.GetPublishers())
                    {
                        Console.WriteLine(publisher);
                    }
                    break;
            }
            
            Console.WriteLine("=================================");
        }

        private static void DisplayById(string table, int id)
        {
            switch (table)
            {
                case "Games":
                    Console.WriteLine(db.GetGame(id));
                    break;
                case "Genres":
                    Console.WriteLine(db.GetGenre(id));
                    break;
                case "Publishers":
                    Console.WriteLine(db.GetPublisher(id));
                    break;
            }

            Console.WriteLine("=================================");
        }
    }
}
