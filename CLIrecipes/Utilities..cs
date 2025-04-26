using Data_models;

namespace CLIrecipes
{
    public static class Utilities
    {
        public static bool Prompt(string message)
        {
            Console.Write($"{message} (yes/no): ");
            string? input = Console.ReadLine()?.Trim().ToLower();
            return input == "yes" || input == "y";
        }

        public static void ShowSuccess(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        public static void ShowError(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        public static void Display(string message, List<Recipe> recipes)
        {
            Console.Clear();
            Console.WriteLine($"\n{message}\n");

            foreach (var recipe in recipes)
            {
                Console.WriteLine($"🍽  {recipe.Title}");
                Console.WriteLine($"📂 Category : {recipe.Category}");
                Console.WriteLine($"🌍 Origin : {recipe.Area}");
                if (!string.IsNullOrWhiteSpace(recipe.Youtube)) Console.WriteLine(recipe.Youtube);
                Console.WriteLine("\n⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯\n");
            }
        }
    }
}