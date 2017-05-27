using System;
using System.Collections.Generic;
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

            var sochetanie = File.ReadLines("GENERATION.txt").ToList<string>();
            //var number = GuessUser.GetEnigma();
            //foreach (var n in number)
            //    Console.Write(n);

            //var input = InputAnswer();

            //Analysis(input[0], input[1], number);
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
