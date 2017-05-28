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
            Console.WriteLine("Игра \"Быки и коровы\"! Компьютер отгадывает число!\n");

            //GenerationListNumber();

            var sochetanie = File.ReadLines("GENERATION.txt").ToArray();
            var flag = new bool[5040];
            for (int i = 0; i < 5040; i++)
                flag[i] = true;            
            string move;
            while (true)
            {
                move = SelectMove(sochetanie, flag);
                Console.WriteLine(move);
                var input = InputAnswer();
                if (input[0] == 4)
                {
                    Console.WriteLine("Число угадано!");
                    break;
                }
                for (int i = 0; i < 5040; i++)
                    if (!Analysis(input[0], input[1], sochetanie[i], move)) flag[i] = false;                
                Console.WriteLine("Осталось вариантов: {0}", flag.Count(x => x == true));
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
            Console.Write("\nКоличество быков: ");
            var bulls = Convert.ToInt32(Console.ReadLine());
            Console.Write("Количество коров: ");
            var cows = Convert.ToInt32(Console.ReadLine());
            return new int[] { bulls, cows };
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

        public static void GenerationListNumber()
        {
            var result = new string[5040];
            int count = 0;            
            for (int i = 0; i < 10; i++) // ПЕРВОЕ число                
                for (int j = 0; j < 10; j++) // ВТОРОЕ число
                {
                    if (j == i) continue;                    
                    for (int k = 0; k < 10; k++) // ТРЕТЬЕ число
                    {
                        if ((k == i || k == j)) continue;                        
                        for (int l = 0; l < 10; l++) // ЧЕТВЕРТОЕ число
                        {
                            if ((l == k || l == j || l == i)) continue;
                            result[count] = String.Format(i.ToString() + j.ToString() + k.ToString() + l.ToString());
                            count++;
                        }
                    }
                }
            File.WriteAllLines("GENERATION.txt", result);
            Console.WriteLine("\nЗапись закончена");
            Console.WriteLine("Количество комбинаций" + count);
        }
    }
}
