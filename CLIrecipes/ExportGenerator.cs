using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Data_models;

namespace CLIrecipes
{
    public static class ExportGenerator
    {
        public static void ExportToTextFile(List<Meal> meals)
        {
            Console.Write("\nEnter a file name to export (default: recipes.txt): ");
            string fileName = Console.ReadLine()?.Trim();

            if (string.IsNullOrWhiteSpace(fileName))
                fileName = "recipes.txt";
            else if (!fileName.EndsWith(".txt", StringComparison.OrdinalIgnoreCase))
                fileName += ".txt";

            var sb = new StringBuilder();

            foreach (var meal in meals)
            {
                sb.AppendLine($"🍽 {meal.Title}");
                sb.AppendLine($"📂 Category: {meal.Category}");
                sb.AppendLine($"🌍 Origin: {meal.Area}");
                sb.AppendLine($"Video: {meal.Youtube}");
                sb.AppendLine("\n📋 Ingredients:\n");
                foreach (var ing in meal.Ingredients)
                {
                    sb.AppendLine($"  - {ing}");
                }
                sb.AppendLine($"\n📖 Instructions:\n {meal.Instructions}");
                sb.AppendLine("\n⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯\n");
            }

            try
            {
                File.WriteAllText(fileName, sb.ToString());
                Utilities.ShowSuccess($"\nRecipes exported to: {Path.GetFullPath(fileName)}");
            }
            catch (Exception ex)
            {
                Utilities.ShowError($"Failed to export: {ex.Message}");
            }
        }
    }
}
