using System.Data.Entity.Migrations;
using BusinessLogic.Controller;

namespace BusinessLogic.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<BusinessLogic.Controller.FitnessContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "BusinessLogic.Controller.FitnessContext";
        }

        protected override void Seed(BusinessLogic.Controller.FitnessContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}