using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

class Program
{
    static void Main(string[] args)
    {

        string filePath = @"D:\input.txt";

        string[] lines = File.ReadAllLines(filePath);

        Console.WriteLine($"Всего строк в файле: {lines.Length}");

        // Тестирование производительности для List<string>
        TestPerformance(lines, new List<string>());

        // Тестирование производительности для LinkedList<string>
        TestPerformance(lines, new LinkedList<string>());
    }

    private static void TestPerformance(string[] lines, ICollection<string> collection)
    {
        var stopwatch = new Stopwatch();

        stopwatch.Start();

        foreach (var line in lines)
        {
            collection.Add(line);
        }

        stopwatch.Stop();

        if (collection is List<string>)
        {
            Console.WriteLine("Время вставки в List<string>: " + stopwatch.ElapsedMilliseconds + " мс");
        }
        else if (collection is LinkedList<string>)
        {
            Console.WriteLine("Время вставки в LinkedList<string>: " + stopwatch.ElapsedMilliseconds + " мс");
        }
    }
}
