using FrameworkTricks.Application.Models;
using System.Collections.Generic;
using System.Linq;

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
    }
}
