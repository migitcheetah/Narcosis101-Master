namespace Narcosis101.Migrations
{
    using Narcosis101.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Narcosis101.DAL.ItemContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(Narcosis101.DAL.ItemContext context)
        {
            var cameras = new List<Camera>
            {
            //new Camera{ID=00001,Picture = "nikonosV.jpg",Class = "c",Make="Nikonos",Model="V"},
            //new Camera{ID=00002,Picture = "nikonosV.jpg",Class = "c",Make="Nikonos",Model="V"},
            //new Camera{ID=00003,Picture = "nikonosV.jpg",Class = "c",Make="Nikonos",Model="V"}
           };

            cameras.ForEach(s => context.Cameras.Add(s));
            context.SaveChanges();

            var lenses = new List<Lense>
            {
            //new Lense{ID=00001,Picture = "lens.jpg",Class = "l",Make="Nikonos",Model="test 1"},
            //new Lense{ID=00002,Picture = "lens.jpg",Class = "l",Make="Nikonos",Model="test 2"},
            //new Lense{ID=00003,Picture = "lens.jpg",Class = "l",Make="Nikonos",Model="test 3"},
            };
            lenses.ForEach(s => context.Lenses.Add(s));
            context.SaveChanges();

            var flashes = new List<Flash>
            {
            //new Flash{ID=00001,Picture = "flash.jpg",Class = "f",Make="Nikonos",Model="test 1"},
            //new Flash{ID=00002,Picture = "flash.jpg",Class = "f",Make="Nikonos",Model="test 2"},
            //new Flash{ID=00003,Picture = "flash.jpg",Class = "f",Make="Nikonos",Model="test 3"}
           };
            flashes.ForEach(s => context.Flashes.Add(s));
            context.SaveChanges();


            var Reviews = new List<Review>
            {
            new Review{Name = "Ryan", ReviewText="This is a test Review", ItemID = 20,},
            new Review{Name = "Ryan", ReviewText="This is a test Review", ItemID = 52,},
            new Review{Name = "Ryan", ReviewText="This is a test Review", ItemID = 61,},
            };
            Reviews.ForEach(c => context.Reviews.Add(c));
            context.SaveChanges();
        }
    }
}
