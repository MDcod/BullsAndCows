using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BullsAndCows
{
    public class GuessII
    {
        public static void GuessIIMain()
        {
            Console.Clear();
            Console.WriteLine("Игра \"Быки и коровы\"! Компьютер отгадывает число!\n");

            var number = GuessUser.GetEnigma();
            foreach (var n in number)
                Console.Write(n);

            var input = InputAnswer();

            Analysis(input[0], input[1], number);
        }

        private static int[] InputAnswer()
        {
            Console.Write("\nКоличество быков: ");
            var bulls = Convert.ToInt32(Console.ReadLine());
            Console.Write("Количество коров: ");
            var cows = Convert.ToInt32(Console.ReadLine());
            return new int[] { bulls, cows };
        }

        public static void Analysis(int b, int c, int[] n)
        {
            if (b == 4)
            {
                Console.WriteLine("Число угадано!");
                return;
            }
            var resultB = BullsNumeral(b, n);
            var resultC = CowsNumeral(b, n);
        }

        private static object CowsNumeral(int b, int[] n)
        {
            throw new NotImplementedException();
        }

        private static object BullsNumeral(int b, int[] n)
        {
            throw new NotImplementedException();
        }
    }
}
