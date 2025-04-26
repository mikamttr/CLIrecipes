using CLIrecipes;
using Data_models;

class Program
{
    static async Task Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.Write("\r\n\r\n██████╗ ███████╗ ██████╗██╗██████╗ ███████╗    ███████╗██╗███╗   ██╗██████╗ ███████╗██████╗ \r\n██╔══██╗██╔════╝██╔════╝██║██╔══██╗██╔════╝    ██╔════╝██║████╗  ██║██╔══██╗██╔════╝██╔══██╗\r\n██████╔╝█████╗  ██║     ██║██████╔╝█████╗      █████╗  ██║██╔██╗ ██║██║  ██║█████╗  ██████╔╝\r\n██╔══██╗██╔══╝  ██║     ██║██╔═══╝ ██╔══╝      ██╔══╝  ██║██║╚██╗██║██║  ██║██╔══╝  ██╔══██╗\r\n██║  ██║███████╗╚██████╗██║██║     ███████╗    ██║     ██║██║ ╚████║██████╔╝███████╗██║  ██║\r\n╚═╝  ╚═╝╚══════╝ ╚═════╝╚═╝╚═╝     ╚══════╝    ╚═╝     ╚═╝╚═╝  ╚═══╝╚═════╝ ╚══════╝╚═╝  ╚═╝\r\n                                                                                            \r\n\r\n");

        while (true)
        {
            Console.Write("\n🔎︎ Search for recipes: ");
            string? search = Console.ReadLine()?.Trim();

            if (string.IsNullOrWhiteSpace(search)) continue;

            var searchResults = await RecipesAPI.FetchData(search);

            if (searchResults == null || searchResults.Count == 0)
            {
                Console.WriteLine($"No recipes found ...");
                continue;
            }

            Utilities.Display($"🔢 {searchResults.Count} recipes found :", searchResults);

            Console.WriteLine("\nPress a key to continue...");
            Console.ReadKey(true);

            var menu = new Menu(
                "What do you want to do ?", 
                ["Filter search results", "Export all results", "Make a new search", "Quit application"]
            );

            switch (menu.Input())
            {
                case "Filter search results":
                    var filtered = Filter(searchResults);
                    Utilities.Display($"📑 Filtered recipes : {filtered.Count}", filtered);
                    if (Utilities.Prompt("Do you want to export filtered search results?"))
                        Export.ToTextFile(filtered);
                    break;

                case "Export all results":
                    if (Utilities.Prompt("Do you want to export full search results?"))
                        Export.ToTextFile(searchResults);
                    break;

                case "Quit application":
                    Console.WriteLine("\nExiting application...");
                    Environment.Exit(0);
                    break;

                default:
                    // Back to search for recipes
                    Console.Clear();
                    break;
            }
        }
    }

    public static List<Recipe> Filter(List<Recipe> searchResults)
    {
        var filterMenu = new Menu(
            "Filter search results by:", 
            ["Category", "Origin", "No filter"]
        );

        switch (filterMenu.Input())
        {
            case "Category":
                var categories = searchResults
                    .Select(m => m.Category)
                    .Where(c => !string.IsNullOrWhiteSpace(c))
                    .Distinct()
                    .OrderBy(c => c)
                    .ToArray();

                var categoryMenu = new Menu("📂 Choose recipe category:", categories);
                string selectedCategory = categoryMenu.Input();

                return [.. searchResults.Where(m => string.Equals(m.Category, selectedCategory, StringComparison.OrdinalIgnoreCase))];

            case "Origin":
                var origins = searchResults
                    .Select(m => m.Area)
                    .Where(a => !string.IsNullOrWhiteSpace(a))
                    .Distinct()
                    .OrderBy(a => a)
                    .ToArray();

                var originMenu = new Menu("🌍 Choose recipe origin:", origins);
                string selectedOrigin = originMenu.Input();

                return [.. searchResults.Where(m => string.Equals(m.Area, selectedOrigin, StringComparison.OrdinalIgnoreCase))];

            default:
                return searchResults;
        }
    }
}