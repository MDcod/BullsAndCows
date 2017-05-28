using System;
using System.Linq;

namespace BullsAndCows
{
    public class ValidationInput
    {
        /// <summary>
        /// Проверка введеного пользователем числа
        /// </summary>
        /// <param name="answer">Запрос пользователя</param>
        /// <returns></returns>
        public static bool UserAnswer(string input)
        {
            if (input.All(x => char.IsNumber(x)) && input.Count() != 4)
            {
                Console.WriteLine("Некорректный запрос. Число должно быть четырехзначным");
                return false;
            }
            if (!input.All(c => char.IsNumber(c)))
            {
                Console.WriteLine("Некорректный запрос. Запрос должен состоять только из цифр");
                return false;
            }
            for (int i = 0; i < input.Count(); i++)
                for (int j = i + 1; j < input.Count(); j++)
                {
                    if (input[i] == input[j])
                    {
                        Console.WriteLine("Некорректный запрос. Не должно быть повторяющихся цифр");
                        return false;
                    }
                }
            return true;
        }

        public static bool Bulls(string bulls)
        {
            if (bulls.Length > 1)
            {
                Console.WriteLine("Некорректный ввод. Запрос должен состоять из одной цифры");
                return false;
            }
            if (!char.IsNumber(Convert.ToChar(bulls)))
            {
                Console.WriteLine("Некорректный ввод. Запрос должен состоять только из цифр");
                return false;
            }
            if (int.Parse(bulls) > 4)
            {
                Console.WriteLine("Некорректный ввод. Количество быков должно быть в диапозоне от 0 до 4");
                return false;
            }
            return true;
        }

        public static bool Cows(string bulls, string cows)
        {
            if (cows.Length > 1)
            {
                Console.WriteLine("Некорректный ввод. Запрос должен состоять из одной цифры");
                return false;
            }
            if (!char.IsNumber(Convert.ToChar(cows)))
            {
                Console.WriteLine("Некорректный ввод. Запрос должен состоять только из цифр");
                return false;
            }
            if (int.Parse(cows) + int.Parse(bulls) > 4)
            {
                Console.WriteLine("Некорректный ввод. Количество быков и коров в сумме должно быть не больше 4");
                return false;
            }
            return true;
        }
    }
}
