using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;

namespace Task2
{
    public static class FileWorker
    {
        public static Dictionary<string, long> CompleteDictionaryFromFile()
        {
            Dictionary<string, long> words = new Dictionary<string, long>();

            Console.WriteLine("Введите путь к текстовому файлу:");
            string FileURL = Console.ReadLine() ?? "";

            //Заменяем слэши
            FileURL = NormalizeURL(FileURL);

            //Если получили некорректный путь - возврат
            if (!File.Exists(FileURL))
            {
                Console.WriteLine("Введен некорректнуй путь.");
                return words;
            }

            // Откроем файл и прочитаем его содержимое
            using (StreamReader sr = File.OpenText(FileURL))
            {
                string str = "";
                while ((str = sr.ReadLine()) != null) // Пока не кончатся строки - считываем из файла по одной
                {
                    string[] subStrings = str.Split(TextOperations.Delimiters, StringSplitOptions.RemoveEmptyEntries);

                    foreach(string currentWord in subStrings)
                    {
                        if (words.ContainsKey(currentWord.ToLower()))
                        {
                            words[currentWord.ToLower()] += 1;
                        }
                        else
                        {
                            words.Add(currentWord.ToLower(), 1);
                        }
                    }
                }
            }

            return words;

        }


        /// <summary>
        /// Заменяет символ '\' на '/'
        /// </summary>
        /// <param name="URL"></param>
        /// <returns></returns>
        private static string NormalizeURL(string URL)
        {
            string NormalizedURL = URL.Replace('\u005C', '\u002F');

            return NormalizedURL;
        }
    }
}
