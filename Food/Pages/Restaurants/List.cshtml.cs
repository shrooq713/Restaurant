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
        public string Message { get; set; }
        public IEnumerable<Restaurant> restaurants { get; set; }
        // public readonly IConfiguration config;
        public readonly IRestaurantData restaurantData;

        [BindProperty(SupportsGet =true)] 
        public string SearchTerm { get; set; }
        public ListModel(IRestaurantData restaurantData){
            // this.config = config;
            this.restaurantData = restaurantData;
        }
        public void OnGet()
        {
            // Message = config["Message"];
            Message = "helloooooo!!!!!!!";
            restaurants = restaurantData.GetAll();

            restaurants = restaurantData.GetRestaurantsByName(SearchTerm);
        }
    }
}