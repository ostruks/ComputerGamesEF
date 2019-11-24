using DAL.Models;
using System.Data.Entity;

namespace DAL
{
    public class GameDBContext : DbContext
    {
        public GameDBContext()
            : base("DefaultConnection")
        {
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<GameDBContext, Migrations.Configuration>());
            Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<Genre> Genres { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Game> Games { get; set; }

        protected override void OnModelCreating(DbModelBuilder dbModelBuilder)
        {
            base.OnModelCreating(dbModelBuilder);

            dbModelBuilder.Entity<Publisher>()
                .HasMany(c => c.Games)
                .WithRequired(c => c.Publisher)
                .HasForeignKey(c => c.Publisher_Id);

            dbModelBuilder.Entity<Genre>()
                .HasMany(c => c.Games)
                .WithRequired(c => c.Genre)
                .HasForeignKey(c => c.Genre_Id);
        }
    }
}
