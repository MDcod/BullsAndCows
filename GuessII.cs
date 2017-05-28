using System;
using System.IO;
using System.Linq;

namespace BullsAndCows
{
    public class GuessII
    {
        public static void GuessIIMain()
        {
            Console.Clear();
            Console.WriteLine("Игра \"Быки и коровы\"! Компьютер отгадывает число!");
            var combinations = File.ReadLines("GenerationСombinationFourdigitNumbers.txt").ToArray();
            // Массив флагов "подход/неподходит" для массива комбинаций
            var flag = new bool[5040];
            for (int i = 0; i < 5040; i++)
                flag[i] = true;
            while (true)
            {
                var move = SelectMove(combinations, flag);
                var input = InputAnswer();
                // Если пользователь ввёл 4 быка
                if (input[0] == 4)
                {
                    Console.WriteLine("Число угадано!");
                    break;
                }
                // Сравнение всех комбинаций с предпологаемым ответов на основе кол-ва быков и коров от пользователя
                for (int i = 0; i < 5040; i++)
                    if (!Analysis(input[0], input[1], combinations[i], move)) flag[i] = false;
                // Если ни одна из комбинаций не подходит
                if (flag.Count(x => x == true) == 0)
                {
                    Console.WriteLine("Числа, удовлетворяющего вашим ответам, не существует");
                    break;
                }
            }
            Menu.GameMenu();
        }

        /// <summary>
        /// Выбор числа, которое подходит предедущим условиям, которые ввел пользователь
        /// </summary>
        /// <param name="combinations">Массив всех кобминаций</param>
        /// <param name="flag">Массив флагов для комбинаций</param>
        /// <returns></returns>
        public static string SelectMove (string[] combinations, bool[] flag)
        {
            Random random = new Random();
            int indexMove = random.Next(5040);
            while (true)
            {
                if (flag[indexMove] == true) break;
                indexMove = random.Next(5040);                  
            }
            Console.WriteLine("\n{0}", combinations[indexMove]);
            return combinations[indexMove];
        }

        /// <summary>
        /// Ввод пользоватлем количества быков и коров в ответе компьютера
        /// </summary>
        /// <returns></returns>
        private static int[] InputAnswer()
        {
            string bulls;
            string cows;
            while (true)
            {
                Console.Write("\nКоличество быков: ");
                bulls = Console.ReadLine();
                // Проверка корректности введеных данных
                if (!ValidationInput.Bulls(bulls)) continue;
                Console.Write("Количество коров: ");
                cows = Console.ReadLine();
                // Проверка корректности введеных данных
                if (!ValidationInput.Cows(bulls,cows)) continue;
                break;             
            }
            return new int[] { int.Parse(bulls), int.Parse(cows) };
        }

        /// <summary>
        /// Исключение неподходящих комбинаций
        /// </summary>
        /// <param name="bulls">Количество, введеных пользователем, быков</param>
        /// <param name="cows">Количество, введеных пользователем, коров</param>
        /// <param name="combination">Сравниваемая комбинация</param>
        /// <param name="move">Вариант числа, который предлагает компьютер</param>
        /// <returns></returns>
        public static bool Analysis(int bulls, int cows, string combination, string move)
        {
            int countBulls = 0;
            int countCows = 0;
            // Сравнение варианта компьютера и комбинации на подходящее число быков
            for (int i = 0; i < 4; i++)
                if (combination[i] == move[i]) countBulls++;
            // Сравнение варианта компьютера и комбинации на подходящее число коров
            for (int i = 0; i < 4; i++)
                if (combination[i] != move[i] && move.IndexOf(combination[i])!=-1) countCows++;
            return countBulls == bulls && countCows == cows;
        }
    }
}
