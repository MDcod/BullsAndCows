using System;

namespace BullsAndCows
{
    public class Menu
    {
        /// <summary>
        /// Главное меню
        /// </summary>
        public static void MainMenu()
        {
            ConsoleKeyInfo cki;
            do
            {
                DisplayMainMenu();
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

        public static void DisplayMainMenu()
        {
            Console.WriteLine("Игра \"Быки и коровы\" \n");
            Console.WriteLine("Выбор режима игры: \n");
            Console.WriteLine("1. Пользователь отгадывает, загаданное компьютером, число.");
            Console.WriteLine("2. Компьютер отгадывает, загаданное пользователем, число.");
            Console.WriteLine("\nДля выхода нажмите ESC");
        }

        /// <summary>
        /// Меню при завершении игры
        /// </summary>
        public static void GameMenu()
        {
            ConsoleKeyInfo cki;
            DisplayGameMenu();
            cki = Console.ReadKey(false);
            while (cki.Key != ConsoleKey.Escape)
                cki = Console.ReadKey(false);
            Console.Clear();
        }

        public static void DisplayGameMenu()
        {
            Console.WriteLine("\nДля возврата в меню нажмите ESC");
            Console.WriteLine("Для выхода закройте консоль");
        }


    }
}
