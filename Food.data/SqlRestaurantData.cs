using System.Collections.Generic;
using Food.core;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Food.data
{
    public class SqlRestaurantData : IRestaurantData
    {

        private readonly RestaurantDBContext db;

        public SqlRestaurantData(RestaurantDBContext db)
        {
            this.db = db;
        }

        public Restaurant Add(Restaurant newRestaurant)
        {
            db.Add(newRestaurant);
            return newRestaurant;
        }

        public int Commit()
        {
            return db.SaveChanges();
        }

        public Restaurant Delete(int id)
        {
            Console.WriteLine("rsturnat id::::::::::::::::::::::::::::::::::::::::"+id);
            var restaurant = GetRestaurantsById(id);
            Console.WriteLine("rsturnat info?????????????????????????????????"+restaurant);
            if(restaurant != null)
            {
                db.Restaurants.Remove(restaurant);
            }
            return restaurant;
        }

        public Restaurant GetRestaurantsById(int id)
        {
            return db.Restaurants.Find(id);
        }

        public int GetCountOfRestaurants()
        {
            return db.Restaurants.Count();
        }

        public IEnumerable<Restaurant> GetRestaurantsByName(string name)
        {
            var query = from r in db.Restaurants
                        where r.Name.StartsWith(name) || string.IsNullOrEmpty(name)
                        orderby r.Name
                        select r;
            return query;
        }

        public Restaurant Update(Restaurant updatedRestaurant)
        {
            var entity = db.Restaurants.Attach(updatedRestaurant);
            entity.State = EntityState.Modified;
            return updatedRestaurant;
        }
        
    }
}