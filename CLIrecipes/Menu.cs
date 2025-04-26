namespace CLIrecipes
{
    public class Menu(string title, string[] items)
    {
        public string Title { get; } = title;
        public string[] Items { get; } = items;
        private int _selectedIndex;

        public void Display()
        {
            Console.Clear();
            Console.CursorVisible = false;
            Console.WriteLine($"\n{Title}\n");

            for (int i = 0; i < Items.Length; i++)
            {
                if (i == _selectedIndex)
                {
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine($"❯ {Items[i]}");
                    Console.ResetColor();
                }
                else
                {
                    Console.WriteLine($"  {Items[i]}");
                }
            }
        }

        public string Input()
        {
            ConsoleKey key;

            do
            {
                Display();
                key = Console.ReadKey(true).Key;

                if (key == ConsoleKey.UpArrow)
                    _selectedIndex = (_selectedIndex == 0) ? Items.Length - 1 : _selectedIndex - 1;
                else if (key == ConsoleKey.DownArrow)
                    _selectedIndex = (_selectedIndex == Items.Length - 1) ? 0 : _selectedIndex + 1;

            } while (key != ConsoleKey.Enter);

            Console.CursorVisible = true;
            return Items[_selectedIndex];
        }
    }
}