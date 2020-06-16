using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Entity;
using FrameworkTricks.Application.Models;
using System.Linq;

namespace FrameworkTricks.Application.Services
{
    public class FrameworkTricksDbContext : DbContext
    {
        public DbSet<Restaurant> Restaurants { get; set; }
    }

    public class SqlRestaurantData : IRestaurantData
    {
        private readonly FrameworkTricksDbContext db;

        public SqlRestaurantData(FrameworkTricksDbContext db)
        {
            this.db = db;
        }

        public void Add(Restaurant restaurant)
        {
            db.Restaurants.Add(restaurant);
            db.SaveChanges();
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return db.Restaurants.OrderBy(x => x.Name);
        }

        public Restaurant GetBy(int id)
        {
            return db.Restaurants.FirstOrDefault(x => x.Id == id);
        }

        public void Update(Restaurant restaurant)
        {
            var entry = db.Entry(restaurant);
            entry.State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
