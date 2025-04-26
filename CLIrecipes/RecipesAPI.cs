using Newtonsoft.Json.Linq;
using Data_models;

namespace CLIrecipes
{
    public static class RecipesAPI
    {
        private static readonly HttpClient client = new();

        public static async Task<List<Recipe>?> FetchData(string search)
        {
            try
            {
                string url = $"https://www.themealdb.com/api/json/v1/1/search.php?s={search}";
                string json = await client.GetStringAsync(url);
                var data = JObject.Parse(json);

                var meals = data["meals"];
                if (meals == null) return null;

                var result = meals.Select(recipe => new Recipe
                {
                    Title = (string?)recipe["strMeal"],
                    Category = (string?)recipe["strCategory"],
                    Area = (string?)recipe["strArea"],
                    Instructions = (string?)recipe["strInstructions"],
                    Youtube = (string?)recipe["strYoutube"],
                    Ingredients = ExtractIngredients(recipe)
                }).ToList();

                return result;
            }
            catch (Exception e)
            {
                Utilities.ShowError($"Error fetching data: {e.Message}");
                return null;
            }
        }

        private static List<string> ExtractIngredients(JToken recipe)
        {
            return Enumerable.Range(1, 20)
                .Select(i =>
                {
                    var ingredient = (string?)recipe[$"strIngredient{i}"];
                    var measure = (string?)recipe[$"strMeasure{i}"];

                    if (string.IsNullOrWhiteSpace(ingredient))
                        return null;

                    var combined = $"{measure?.Trim()} {ingredient.Trim()}".Trim();
                    return string.IsNullOrWhiteSpace(combined) ? null : combined;
                })
                .Where(ing => !string.IsNullOrWhiteSpace(ing))
                .ToList()!;
        }
    }
}