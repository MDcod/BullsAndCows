using System;

namespace BullsAndCows
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ConsoleKeyInfo cki;
            do
            {
                DisplayMenu();
                cki = Console.ReadKey(false);
                switch (cki.KeyChar.ToString())
                {
                    case "1":
                        GuessUser.GuessUserMain();
                        break;
                    case "2":
                        GuessII.GuessIIMain();
                        break;
                }
            } while (cki.Key != ConsoleKey.Escape);
        }

        public static void DisplayMenu()
        {
            Console.WriteLine("Игра \"Быки и коровы\" \n");
            Console.WriteLine("Выбор режима игры: \n");
            Console.WriteLine("1. Пользователь отгадывает, загаданное компьютером, число.");
            Console.WriteLine("2. Компьютер отгадывает, загаданное пользователем, число.");
            Console.WriteLine("\nДля выхода нажмите ESC");
        }
    }
}
