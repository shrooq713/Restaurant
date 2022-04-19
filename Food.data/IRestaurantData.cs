using System.Collections.Generic;
using Food.core;
using System.Linq;

namespace Food.data
{
    public interface IRestaurantData
    {
         IEnumerable<Restaurant> GetAll();
         IEnumerable<Restaurant> GetRestaurantsByName(string name);
         Restaurant GetRestaurantsById(int id);
    }

    public class InMemoryRestaurantData : IRestaurantData
    {
        readonly List<Restaurant> restaurants;

        // Create in-memory data
        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>()
            {
                new Restaurant { Id = 1, Name = "Scott's Pizza", Location="Maryland", Cuisine=CuisineType.Italian},
                new Restaurant { Id = 2, Name = "Cinnamon Club", Location="London", Cuisine=CuisineType.Italian},
                new Restaurant { Id = 3, Name = "La Costa", Location = "California", Cuisine=CuisineType.Mexican}
            };
        }
        
        public IEnumerable<Restaurant> GetAll(){
            return from r in restaurants 
            orderby r.Name 
            select r;
    }
        // Method to return data 
        public IEnumerable<Restaurant> GetRestaurantsByName(string name)
        {
            return from r in restaurants 
            where string.IsNullOrEmpty(name) || r.Name.StartsWith(name)
            orderby r.Name 
            select r;
        }

        public Restaurant GetRestaurantsById(int id)
        {
            return restaurants.SingleOrDefault(r => r.Id == id);
        }
    }
}