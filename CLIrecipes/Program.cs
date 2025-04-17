using CLIrecipes;
using Data_models;

class Program
{
    static async Task Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        while (true)
        {
            Console.Write("\n🔍 Search for recipes: ");
            string search = Console.ReadLine()?.Trim();

            if (string.IsNullOrWhiteSpace(search)) continue;

            var meals = await RecipeFetch.FetchRecipesAsync(search);

            if (meals == null || meals.Count == 0)
            {
                Console.WriteLine($"No recipes found ...");
                continue;
            }

            DisplayMeals($"🔢 {meals.Count} recipe(s) found :", meals);

            Console.WriteLine("\nWhat would you like to do?");
            Console.WriteLine("1. Filter the search results");
            Console.WriteLine("2. Export all results");
            Console.WriteLine("3. Go back to recipe search");

            string actionChoice = Console.ReadLine()?.Trim();

            switch (actionChoice)
            {
                case "1":
                    var filteredMeals = MealFilter.ApplyFilter(meals);
                    DisplayMeals($"📑 Filtered recipe(s) : {filteredMeals.Count}", filteredMeals);

                    if (Utilities.PromptYesNo("Do you want to export the filtered results?"))
                    {
                        ExportGenerator.ExportToTextFile(filteredMeals);
                    }
                    break;

                case "2":
                    if (Utilities.PromptYesNo("Do you want to export the full search results?"))
                    {
                        ExportGenerator.ExportToTextFile(meals);
                    }
                    break;

                case "3":
                    break;

                default:
                    Utilities.ShowError("Invalid option");
                    break;
            }
        }
    }

    static void DisplayMeals(string message, List<Meal> meals)
    {
        Console.Clear();
        Console.WriteLine($"\n{message}\n");

        foreach (var meal in meals)
        {
            Console.WriteLine($"🍽  {meal.Title}");
            Console.WriteLine($"📂 Category : {meal.Category}");
            Console.WriteLine($"🌍 Origin : {meal.Area}");
            if (!string.IsNullOrWhiteSpace(meal.Youtube)) Console.WriteLine(meal.Youtube);
            Console.WriteLine("\n⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯\n");
        }
    }
}