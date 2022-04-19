using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Food.data;
using Food.core;
namespace Food.Pages.Restaurants
{
    public class ListModel : PageModel
    {
        public IEnumerable<Restaurant> restaurants { get; set; }
        // public readonly IConfiguration config;
        public readonly IRestaurantData restaurantData;

        // bind data (SearchTerm) from form in List.cshtml
        [BindProperty(SupportsGet =true)] 
        public string SearchTerm { get; set; }
        public ListModel(IRestaurantData restaurantData){
            // this.config = config;
            this.restaurantData = restaurantData;
        }
        public void OnGet()
        {
            // returns all restaurant from restaurant Data
            restaurants = restaurantData.GetAll();

            // using GetRestaurantsByName() to search by restaurant name
            restaurants = restaurantData.GetRestaurantsByName(SearchTerm);
        }
    }
}