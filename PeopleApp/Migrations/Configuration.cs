namespace PeopleApp.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using PeopleApp.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<PeopleApp.Models.PeopleAppContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(PeopleApp.Models.PeopleAppContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            context.People.AddOrUpdate(x => x.Id,
                new Person()
                {
                    Id = 1,
                    FirstName = "Joe",
                    LastName = "Clem",
                    Address = "8665 E 300 N",
                    City = "Huntsville",
                    State = "UT",
                    Age = 70,
                    Interests = "Skiing",
                    PictureFile = "images/TappanSmall.jpg",
                    ZipCode = "84317"
                },
                new Person()
                {
                    Id = 2,
                    FirstName = "Hawkeye",
                    LastName = "Pierce",
                    Address = "1345 Lobster St",
                    City = "Crab Apple Cove",
                    State = "MA",
                    Age = 32,
                    Interests = "Doctoring",
                    PictureFile = "images/Hawkeye.jpg",
                    ZipCode = "47563"
                },
                new Person()
                {
                    Id = 3,
                    FirstName = "Dana",
                    LastName = "Scully",
                    Address = "56 K Street",
                    City = "Washington",
                    State = "DC",
                    Age = 27,
                    Interests = "FBI Forensics Alien Hunter",
                    PictureFile = "images/Scully.jpg",
                    ZipCode = "76887"
                },
                new Person()
                {
                    Id = 4,
                    FirstName = "Gregory",
                    LastName = "House",
                    Address = "4657 Franklin Street",
                    City = "Princeton",
                    State = "NJ",
                    Age = 48,
                    Interests = "Diagnostics, Puzzles",
                    PictureFile = "images/House.jpg",
                    ZipCode = "998364"
                }
                );
        }
    }
}
