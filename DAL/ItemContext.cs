using Narcosis101.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Narcosis101.DAL
{
    public class ItemContext : DbContext
    {
        public ItemContext()
            : base("ItemContext") 
        {
        }

        public DbSet<Item> Items { get; set; }
        public DbSet<Camera> Cameras { get; set; }
        public DbSet<Lense> Lenses { get; set; }
        public DbSet<Flash> Flashes { get; set; }
        public DbSet<Review> Reviews { get; set; }

    }
}