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
         Restaurant Update(Restaurant updatedRestaurant);
         int Commit();
         Restaurant Add(Restaurant newRestaurant);
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

        public Restaurant Update(Restaurant updatedRestaurant){
            var restaurant = restaurants.SingleOrDefault(r => r.Id == updatedRestaurant.Id);
            if(restaurant != null){
                restaurant.Name = updatedRestaurant.Name;
                restaurant.Location = updatedRestaurant.Location;
                restaurant.Cuisine = updatedRestaurant.Cuisine;
            }
            return restaurant;
        }
        public int Commit(){
            return 0;
        }
        public Restaurant Add(Restaurant newRestaurant){
            restaurants.Add(newRestaurant);
            newRestaurant.Id = restaurants.Max(r => r.Id) + 1;
            return newRestaurant;
        }
    }
}