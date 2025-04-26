using System.Text;
using Data_models;

namespace CLIrecipes
{
    public static class Export
    {
        private static readonly string ExportDirectory = Path.Combine(Directory.GetCurrentDirectory(), "exports");

        public static void ToTextFile(List<Recipe> meals)
        {
            Console.Write("\nEnter a file name to export (default: recipes.txt): ");
            string? fileName = Console.ReadLine()?.Trim();

            if (string.IsNullOrWhiteSpace(fileName))
                fileName = "recipes.txt";
            else if (!fileName.EndsWith(".txt", StringComparison.OrdinalIgnoreCase))
                fileName += ".txt";

            if (!Directory.Exists(ExportDirectory))
            {
                Utilities.ShowError($"Export folder not found: {ExportDirectory}");
                return;
            }

            string fullPath = Path.Combine(ExportDirectory, fileName);

            var sb = new StringBuilder();

            foreach (var meal in meals)
            {
                sb.AppendLine($"🍽 {meal.Title}");
                sb.AppendLine($"📂 Category: {meal.Category}");
                sb.AppendLine($"🌍 Origin: {meal.Area}");
                sb.AppendLine($"Video: {meal.Youtube}");
                sb.AppendLine("\n📋 Ingredients:\n");
                foreach (var ing in meal.Ingredients!)
                {
                    sb.AppendLine($"  - {ing}");
                }
                sb.AppendLine($"\n📖 Instructions:\n {meal.Instructions}");
                sb.AppendLine("\n⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯\n");
            }

            try
            {
                File.WriteAllText(fullPath, sb.ToString());
                Utilities.ShowSuccess($"\nRecipes exported to: {Path.GetFullPath(fullPath)}");
            }
            catch (Exception e)
            {
                Utilities.ShowError($"Failed to export: {e.Message}");
            }
        }
    }
}
