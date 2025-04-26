namespace Data_models
{
    public class Recipe
    {
        public string? Title { get; set; }
        public string? Category { get; set; }
        public string? Area { get; set; }
        public string? Instructions { get; set; }
        public string? Youtube { get; set; }
        public List<string>? Ingredients { get; set; }
    }
}