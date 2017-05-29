using System;
using System.IO;
using System.Linq;

namespace BullsAndCows
{
    public class GuessUser
    {
        public static void GuessUserMain()
        {
            Console.Clear();
            Console.WriteLine("Игра \"Быки и коровы\"! Отгадывайте число!");
            var enigma = GetEnigma(); //Получение загаданного числа
            while (true)
            {
                var answer = Console.ReadLine(); // Ввод числа
                // Проверка введенного числа, если ввод некоректен, запрашивается новый ввод
                if (!ValidationInput.UserAnswer(answer)) continue;
                // Сравнение загаданного числа и числа введенного пользователем
                if (ComparisonNumber(enigma, answer)[0] == 4) break;
                Console.WriteLine("{0} бык., {1} кор.",
                    ComparisonNumber(enigma, answer)[0], ComparisonNumber(enigma, answer)[1]);
            }
            Console.WriteLine("Число угадано!");
            Menu.GameMenu();
        }

        /// <summary>
        /// Сравнение загаданного числа и числа введенного пользователем
        /// </summary>
        /// <param name="enigma">Загаданное число</param>
        /// <param name="answer">Ответ пользователя</param>
        /// <returns></returns>
        public static int[] ComparisonNumber(string enigma, string answer)
        {
            int bulls = 0;
            int cows = 0;
            // Посимвольное сравнение чисел
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                {
                    if (enigma[i] == answer[j])
                        if (i == j) bulls++;
                        else cows++;
                }
            return new int[] { bulls, cows };
        }

        /// <summary>
        /// Возвращает четырехзначное значное число с неповторяющимися цифрами
        /// </summary>
        /// <returns></returns>
        public static string GetEnigma()
        {
            var combinations = File.ReadLines("GenerationСombinationFourdigitNumbers.txt").ToArray();
            Random random = new Random();
            return combinations[random.Next(combinations.Count())];
        }
    }
}
