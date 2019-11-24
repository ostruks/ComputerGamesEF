using BL.Controllers;
using BL.MoldesDTO;
using DAL;
using System;

namespace MyConsole
{
    class Program
    {
        static IController<GameDTO> dbGames = new GameController();
        static IController<GenreDTO> dbGenres = new GenreController();
        static IController<PublisherDTO> dbPublishers = new PublisherController();

        static void Main(string[] args)
        {
            Display("Games");
            Display("Games", 123456);
            Display("Genres");
            Display("Publishers");
            DisplayById("Games", 1);
            DisplayById("Genres", 1);
            DisplayById("Publishers", 1);

            Create("Games", new GameDTO()
            {
                Name = "Chuvak",
                YearOfIssue = 2018,
                Genre_Id = 1,
                Publisher_Id = 2
            });

            Update("MMORPG", "Genres", new GenreDTO() { Name = "MMORPG2", Description = "Description MMORPG" });
            Update("Man", "Publishers", new PublisherDTO() { Name = "Man2", License = 111333 });
            Update("Chuvak", "Games", new GameDTO()
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

            Create("Games", new GameDTO()
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
                    PublisherDTO publisher = tclass as PublisherDTO;
                    Console.WriteLine(dbPublishers.Create(publisher));
                    break;
                case "Genres":
                    GenreDTO genre = tclass as GenreDTO;
                    Console.WriteLine(dbGenres.Create(genre));
                    break;
                case "Games":
                    GameDTO game = tclass as GameDTO;
                    Console.WriteLine(dbGames.Create(game));
                    break;
            }
        }

        private static void Update<T>(string name, string table, T tclass)
        {
            switch (table)
            {
                case "Publishers":
                    PublisherDTO publisher = tclass as PublisherDTO;
                    dbPublishers.Update(name, publisher);
                    break;
                case "Genres":
                    GenreDTO genre = tclass as GenreDTO;
                    dbGenres.Update(name, genre);
                    break;
                case "Games":
                    GameDTO game = tclass as GameDTO;
                    dbGames.Update(name, game);
                    break;
            }
        }

        private static void Delete(string table, int id)
        {
            switch (table)
            {
                case "Games":
                    dbGames.DeleteById(id);
                    break;
                case "Genres":
                    dbGenres.DeleteById(id);
                    break;
                case "Publishers":
                    dbPublishers.DeleteById(id);
                    break;
            }
        }

        private static void Display(string table, int license = 0)
        {
            switch (table)
            {
                case "Games":
                    var games = license != 0 ? dbGames.GetAll(license) : dbGames.GetAll();

                    foreach (var game in games)
                    {
                        Console.WriteLine(game);
                    }
                    break;
                case "Genres":
                    foreach (var genre in dbGenres.GetAll())
                    {
                        Console.WriteLine(genre);
                    }
                    break;
                case "Publishers":
                    foreach (var publisher in dbPublishers.GetAll())
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
                    Console.WriteLine(dbGames.GetById(id));
                    break;
                case "Genres":
                    Console.WriteLine(dbGenres.GetById(id));
                    break;
                case "Publishers":
                    Console.WriteLine(dbPublishers.GetById(id));
                    break;
            }

            Console.WriteLine("=================================");
        }
    }
}
