using System;
using System.IO;

namespace BullsAndCows
{
    class CombinationGeneration
    {
        public static void GenerationСombinationFourdigitNumbers()
        {
            string nameFile = "GenerationСombinationFourdigitNumbers.txt";
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
            Console.WriteLine("Генерация сочетаний четырехзначных чисел закончена.");
            Console.WriteLine("Количество комбинаций: {0}", count);
            File.WriteAllLines(nameFile, result);
            Console.WriteLine("Запись в файл {0} закончена.", nameFile);
        }
    }
}
