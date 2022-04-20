using System.ComponentModel.DataAnnotations;
namespace Food.core
{
    // Entity class
    public class Restaurant
    {
        [Required, StringLength(100)]
        public string Name { get; set; }
        [Required, StringLength(200)]
        public string Location { get; set; }
        public int Id { get; set; }
        public CuisineType Cuisine { get; set; }
    }
}