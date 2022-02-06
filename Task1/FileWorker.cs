using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;

namespace Task1
{
    public static class FileWorker
    {
        public static List<string> CompleteListFromFile()
        {
            List<string> words = new List<string>();

            StreamReader FileStream = OpenFileToStream();

            string str = "";
            while ((str = FileStream.ReadLine()) != null) // Пока не кончатся строки - считываем из файла по одной
            {
                string[] subStrings = str.Split(TextOperations.Delimiters, StringSplitOptions.RemoveEmptyEntries);

                foreach(string currentWord in subStrings)
                {
                    if (!words.Contains(currentWord.ToLower()))
                    {
                        words.Add(currentWord.ToLower());
                    }
                }
            }

            return words;

        }

        public static StreamReader OpenFileToStream()
        {
            // Откроем файл и прочитаем его содержимое

            InputPath(out string FileURL);
            StreamReader sr = File.OpenText(FileURL);

            return sr;

        }

        private static void InputPath(out string FileURL)
        {
            Console.WriteLine("Введите путь к текстовому файлу:");
            FileURL = Console.ReadLine() ?? "";

            //Заменяем слэши
            FileURL = NormalizeURL(FileURL);

            //Если получили некорректный путь - возврат
            if (!File.Exists(FileURL))
            {
                Console.WriteLine("Введен некорректнуй путь.");
                InputPath(out FileURL);
            }

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
