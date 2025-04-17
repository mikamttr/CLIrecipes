using System;

namespace CLIrecipes
{
    public static class Utilities
    {
        public static bool PromptYesNo(string message)
        {
            Console.Write($"{message} (yes/no): ");
            string input = Console.ReadLine()?.Trim().ToLower();
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
    }
}