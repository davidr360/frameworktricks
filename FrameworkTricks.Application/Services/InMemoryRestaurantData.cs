using FrameworkTricks.Application.Models;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace FrameworkTricks.Application.Services
{
    public class InMemoryRestaurantData : IRestaurantData
    {
        private List<Restaurant> restaurants;

        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>
            {
                new Restaurant { Id = 1, Name = "Dave's Pizza", Cuisine = CuisineType.Italian },
                new Restaurant { Id = 2, Name = "Chickitas", Cuisine = CuisineType.Mexican },
                new Restaurant { Id = 3, Name = "Bengal Spice", Cuisine = CuisineType.Indian }
            };
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return restaurants.OrderBy(x => x.Name);
        }

        public Restaurant GetBy(int id)
        {
            return restaurants.FirstOrDefault(x => x.Id == id);
        }

        public void Add(Restaurant restaurant)
        {
            restaurants.Add(restaurant);
            restaurant.Id = restaurants.Max(x => x.Id) + 1;
        }

        public void Update(Restaurant restaurant)
        {
            var existing = GetBy(restaurant.Id);

            if (existing != null)
            {
                existing.Name = restaurant.Name;
                existing.Cuisine = restaurant.Cuisine;
            }
        }

        public void Delete(int id)
        {
            var restaurant = GetBy(id);

            if (restaurant != null)
                restaurants.Remove(restaurant);
        }
    }
}
