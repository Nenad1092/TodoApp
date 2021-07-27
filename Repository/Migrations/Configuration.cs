using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Contex;

namespace Repository.Migrations
{
    internal class Configuration : DbMigrationsConfiguration<TrelloDBContex>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "GenericRepositoryPatern.Context.TrelloDbContex";
        }

        protected override void Seed(TrelloDBContex context)
        {
            base.Seed(context);
        }
    }
}
