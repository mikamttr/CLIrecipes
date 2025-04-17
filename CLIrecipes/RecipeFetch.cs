using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Data_models;

namespace CLIrecipes
{
    public static class RecipeFetch
    {
        private static readonly HttpClient client = new HttpClient();

        public static async Task<List<Meal>> FetchRecipesAsync(string search)
        {
            try
            {
                string url = $"https://www.themealdb.com/api/json/v1/1/search.php?s={search}";
                string json = await client.GetStringAsync(url);
                var data = JObject.Parse(json);

                var meals = (from meal in data["meals"]
                             select new Meal
                             {
                                 Title = (string)meal["strMeal"],
                                 Category = (string)meal["strCategory"],
                                 Area = (string)meal["strArea"],
                                 Instructions = (string)meal["strInstructions"],
                                 Youtube = (string)meal["strYoutube"],
                                 Ingredients = Enumerable.Range(1, 20)
                                     .Select(i => $"{meal[$"strMeasure{i}"]} {meal[$"strIngredient{i}"]}".Trim())
                                     .Where(ing => !string.IsNullOrWhiteSpace(ing) && !ing.StartsWith(" "))
                                     .ToList()
                             }).ToList();

                return meals;
            }
            catch (Exception ex)
            {
                Utilities.ShowError($"Error fetching data: {ex.Message}");
                return null;
            }
        }
    }
}