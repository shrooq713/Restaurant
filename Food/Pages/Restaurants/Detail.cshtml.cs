using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Food.core;
using Food.data;

namespace Food.Pages.Restaurants
{
    public class DetailModel : PageModel
    {
        public Restaurant restaurant { get; set; }
        public readonly IRestaurantData restaurantData ;
        public DetailModel(IRestaurantData restaurantData){
            this.restaurantData = restaurantData;
        }
        public IActionResult OnGet(int restaurantId)
        {
            restaurant = restaurantData.GetRestaurantsById(restaurantId);
            
            // if the restaurant is not found return NotFound page
            if(restaurant == null){
                return RedirectToPage("./NotFound");
            }
            // otherwise rerender this page
            return Page();
        }
    } 
}