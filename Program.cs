using System;
using System.Linq;

namespace BullsAndCows
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var enigma = GetEnigma(); //Получение загаданного числа
            while (true)
            {
                var input = Console.ReadLine(); // Ввод числа
                // Проверка введенного числа, если ввод некоректен, запрашивается новый ввод
                if (!InputValidation(input)) continue;
                // Преобразование введеного числа в массив цифр
                var answer = input.Select(n => (int)char.GetNumericValue(n)).ToArray();
                // Сравнение загаданного числа и числа введенного пользователем
                if (ComparisonNumber(enigma, answer)[0] == 4) break;
                Console.WriteLine("{0} бык., {1} кор.",
                    ComparisonNumber(enigma, answer)[0], ComparisonNumber(enigma, answer)[1]);
            }
            Console.WriteLine("Число угадано!");
            Console.ReadKey();
        }

        /// <summary>
        /// Проверка введеного пользователем числа
        /// </summary>
        /// <param name="answer">Запрос пользователя</param>
        /// <returns></returns>
        public static bool InputValidation(string input)
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
                for (int j = i+1; j < input.Count(); j++)
                {
                    if (input[i] == input[j])
                    {
                        Console.WriteLine("Некорректный запрос. Не должно быть повторяющихся цифр");
                        return false;
                    }
                }
            return true;
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
                int numeral = random.Next(1, 10);
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
