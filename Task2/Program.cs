using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public static class Program
    {
        static void Main()
        {
            var ourTextDictionary = FileWorker.CompleteDictionaryFromFile();

            if(ourTextDictionary.Count == 0)
            {
                Console.WriteLine("Словарь не заполнен, работа программы завершена. Нажмите любую клавишу...");
                Console.ReadKey();
                return;
            }

            var ourSortedDictionary = ourTextDictionary.ToSortedDictionary();

            byte wordsCount = 10;
            Console.WriteLine($"{wordsCount} наиболее часто используемых слов в выбранном тексте:");

            
            foreach(var currentPair in ourSortedDictionary.Reverse())
            {
                wordsCount--;
                Console.WriteLine($"{10 - wordsCount}: " + ourSortedDictionary[currentPair.Key] + $" (встречается раз: {currentPair.Key})");

                if(wordsCount == 0)
                {
                    break;
                }
            }

            Console.WriteLine("Нажмите любую клавишу...");
            Console.ReadKey();
        }
    }
}