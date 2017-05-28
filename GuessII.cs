using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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
            Console.WriteLine("Игра \"Быки и коровы\"! Компьютер отгадывает число!");
            var allCombination = File.ReadLines("GenerationСombinationFourdigitNumbers.txt").ToArray();
            var flag = new bool[5040];
            for (int i = 0; i < 5040; i++)
                flag[i] = true;            
            string move;
            var input = new int[2];
            while (true)
            {
                move = SelectMove(allCombination, flag);
                Console.WriteLine("\n{0}", move);
                input = InputAnswer();
                if (input[0] == 4)
                {
                    Console.WriteLine("Число угадано!");
                    break;
                }
                for (int i = 0; i < 5040; i++)
                    if (!Analysis(input[0], input[1], allCombination[i], move)) flag[i] = false;
                if (flag.Count(x=>x==true) == 0)
                {
                    Console.WriteLine("Числа, удовлетворяющего вашим ответам, не существует");
                    break;
                }
            }
        }

        public static string SelectMove (string[] s, bool[] f)
        {
            Random random = new Random();
            int indexMove = random.Next(5040);
            while (true)
            {
                if (f[indexMove] == true) break;
                indexMove = random.Next(5040);                  
            }
            return s[indexMove];
        }

        private static int[] InputAnswer()
        {
            string bulls;
            string cows;
            while (true)
            {
                Console.Write("\nКоличество быков: ");
                bulls = Console.ReadLine();
                if (!ValidationInput.Bulls(bulls)) continue;
                Console.Write("Количество коров: ");
                cows = Console.ReadLine();
                if (!ValidationInput.Cows(bulls,cows)) continue;
                break;             
            }
            return new int[] { int.Parse(bulls), int.Parse(cows) };
        }

        public static bool Analysis(int bulls, int cows, string a, string b)
        {
            int countBulls = 0;
            int countCows = 0;
            for (int i = 0; i < 4; i++)
                if (a[i] == b[i]) countBulls++;
            for (int i = 0; i < 4; i++)
                if (a[i] != b[i] && b.IndexOf(a[i])!=-1) countCows++;
            return countBulls == bulls && countCows == cows;
        }
    }
}
