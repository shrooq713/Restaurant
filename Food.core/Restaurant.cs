namespace Food.core
{
    // Entity class
    public class Restaurant
    {
        public string Name { get; set; }
        public string Location { get; set; }
        public int Id { get; set; }
        public CuisineType Cuisine { get; set; }
    }
}