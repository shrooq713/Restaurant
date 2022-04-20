using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Food.data;
using Food.core;
namespace Food.Pages.Restaurants
{
    public class EditModel : PageModel
    {
        // restaurant used to save data that comes from data class 
        [BindProperty]
        public Restaurant restaurant { get; set; }
        private readonly IHtmlHelper htmlHelper;
        public IEnumerable<SelectListItem> Cuisines { get; set; }
        public readonly IRestaurantData restaurantData;
        //  Constracter to inject the data servicve 
        public EditModel(IRestaurantData restaurantData, IHtmlHelper htmlHelper){
            // this.config = config;
            this.restaurantData = restaurantData;
            this.htmlHelper = htmlHelper;
        }
        public IActionResult OnGet(int? restaurantId)
        {
            Cuisines = htmlHelper.GetEnumSelectList<CuisineType>();
            if (restaurantId.HasValue)
            {
                restaurant = restaurantData.GetRestaurantsById(restaurantId.Value);
            }
            else
            {
                restaurant = new Restaurant();
            }
            if(restaurant == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }

        public IActionResult OnPost()
        {               
            if(!ModelState.IsValid){
                Cuisines = htmlHelper.GetEnumSelectList<CuisineType>();
                return Page();                
            }

            if (restaurant.Id > 0){
                restaurantData.Update(restaurant);
            }
            else
            {
                restaurantData.Add(restaurant);
            }
            
            restaurantData.Commit();
            TempData["Message"] = "Restaurant saved!";
            return RedirectToPage("./Detail", new { restaurantId = restaurant.Id });
        }
    }
}