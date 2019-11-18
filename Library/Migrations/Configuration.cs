using System.Data.Entity.Migrations;

namespace Library.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<GameDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "Library.GameDBContext";
        }

        protected override void Seed(GameDBContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
