using System.Collections.Generic;
using Food.core;
using System.Linq;

using Microsoft.EntityFrameworkCore;
namespace Food.data
{

    public class RestaurantDBContext : DbContext
    {

        public RestaurantDBContext(DbContextOptions<RestaurantDBContext> options)
            : base(options)
        {
                
        }

        public DbSet<Restaurant> Restaurants { get; set; }
    }
}
