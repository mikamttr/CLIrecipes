using Data_models;

namespace CLIrecipes
{
    public static class MealFilter
    {
        public static List<Meal> ApplyFilter(List<Meal> meals)
        {
            Console.WriteLine("\nFilter Options:");
            Console.WriteLine("1. Category");
            Console.WriteLine("2. Origin");
            Console.WriteLine("3. No Filter");

            Console.Write("Choose an option (1-3): ");
            int.TryParse(Console.ReadLine(), out int choice);

            switch (choice)
            {
                case 1:
                    Console.Write("Enter Category: ");
                    string? category = Console.ReadLine();
                    return meals.Where(m => m.Category?.Contains(category, StringComparison.OrdinalIgnoreCase) ?? false).ToList();
                case 2:
                    Console.Write("Enter Origin (Area): ");
                    string? area = Console.ReadLine();
                    return meals.Where(m => m.Area?.Contains(area, StringComparison.OrdinalIgnoreCase) ?? false).ToList();
                default:
                    return meals;
            }
        }
    }
}