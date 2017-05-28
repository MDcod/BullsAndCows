using System;
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
                var input = Console.ReadLine(); // Ввод числа
                // Проверка введенного числа, если ввод некоректен, запрашивается новый ввод
                if (!ValidationInput.UserAnswer(input)) continue;
                // Преобразование введеного числа в массив цифр
                var answer = input.Select(n => (int)char.GetNumericValue(n)).ToArray();
                // Сравнение загаданного числа и числа введенного пользователем
                if (ComparisonNumber(enigma, answer)[0] == 4) break;
                Console.WriteLine("{0} бык., {1} кор.",
                    ComparisonNumber(enigma, answer)[0], ComparisonNumber(enigma, answer)[1]);
            }
            Console.WriteLine("Число угадано!\n");
        }

        /// <summary>
        /// Сравнение загаданного числа и числа введенного пользователем
        /// </summary>
        /// <param name="enigma">Загаданное число</param>
        /// <param name="answer">Ответ пользователя</param>
        /// <returns></returns>
        public static int[] ComparisonNumber(int[] enigma, int[] answer)
        {
            int bulls = 0;
            int cows = 0;
            // Посимвольное сравнение чисел
            for (int e = 0; e < 4; e++)
                for (int a = 0; a < 4; a++)
                {
                    if (enigma[e] == answer[a])
                        if (e == a) bulls++;
                        else cows++;
                }
            return new int[] { bulls, cows };
        }

        /// <summary>
        /// Возвращает четырехзначное значное число с неповторяющимися цифрами
        /// </summary>
        /// <returns></returns>
        public static int[] GetEnigma()
        {
            int[] enigma = new int[4];
            Random random = new Random();
            for (int i = 0; i < 4;)
            {
                int numeral = random.Next(0, 10);
                // Проверка на повторение цифр
                if (enigma.All(x => x != numeral))
                {
                    enigma[i] = numeral;
                    i++;
                }
            }
            return enigma;
        }
    }
}
