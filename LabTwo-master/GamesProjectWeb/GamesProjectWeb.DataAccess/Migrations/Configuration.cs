namespace GamesProjectWeb.DataAccess.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<GamesProjectWeb.DataAccess.Context.GamesProjectContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migrations";
            ContextKey = "GamesProjectWeb.DataAccess.Context.GamesProjectContext";
        }

        protected override void Seed(GamesProjectWeb.DataAccess.Context.GamesProjectContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
