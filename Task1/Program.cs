using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Task1
{
    public static class Program
    {
        static void Main()
        {
            List<string> ourList = FileWorker.CompleteListFromFile();
            LinkedList<string> ourLinkedList = ourList.ToLinkedList();

            // запускаем новый таймер
            var stopWatch = Stopwatch.StartNew();

            // Добавим элемент в обычный список
            ourList.Add("случайное слово");

            // смотрим, сколько операция заняла, в миллисекундах
            Console.WriteLine("Добавление элемента в обычный список: " + stopWatch.Elapsed.TotalMilliseconds);

            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("Добавление элемента в связный список.");
            
            // запускаем новый таймер
            stopWatch = Stopwatch.StartNew();

            // Добавим элемент в начало связного списка
            ourLinkedList.AddFirst("случайное слово");

            // смотрим, сколько операция заняла, в миллисекундах
            Console.WriteLine("Добавление в начало списка: " + stopWatch.Elapsed.TotalMilliseconds);

            // запускаем новый таймер
            stopWatch = Stopwatch.StartNew();

            // Добавим элемент в произвольное место связного списка
            var currentElement = ourLinkedList.Find("и") ?? ourLinkedList.First;
            ourLinkedList.AddAfter(currentElement, "случайное слово");

            // смотрим, сколько операция заняла, в миллисекундах
            Console.WriteLine("Добавление в произвольное место списка: " + stopWatch.Elapsed.TotalMilliseconds);

            // запускаем новый таймер
            stopWatch = Stopwatch.StartNew();
            // Добавим элемент в конец связного списка
            ourLinkedList.AddLast("случайное слово");

            // смотрим, сколько операция заняла, в миллисекундах
            Console.WriteLine("Добавление элемента в конец списка: " + stopWatch.Elapsed.TotalMilliseconds);

            Console.WriteLine("--------------------------------------------------");

            // запускаем новый таймер
            stopWatch = Stopwatch.StartNew();

            // Добавим элемент в обычный список
            ourLinkedList.AddLast("случайное слово");

            // смотрим, сколько операция заняла, в миллисекундах
            Console.WriteLine("Добавление элемента в связный список: " + stopWatch.Elapsed.TotalMilliseconds);

            Console.WriteLine("Нажмите любую клавишу...");
            Console.ReadKey();
        }
    }
}