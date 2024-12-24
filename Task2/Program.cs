using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.IO;

class WordFrequencyCounter
{
    static void Main()
    {

        string filePath = @"D:\input.txt";

        try
        {

            string text = File.ReadAllText(filePath);


            string[] words = Regex.Split(text, @"\W+")
                                  .Where(w => !string.IsNullOrEmpty(w))
                                  .Select(w => w.ToLower()) // Преобразуем каждое слово к нижнему регистру
                                  .ToArray();


            Dictionary<string, int> wordFrequencies = new Dictionary<string, int>();

            // Подсчет частоты слов
            foreach (string word in words)
            {
                if (!wordFrequencies.ContainsKey(word))
                {
                    wordFrequencies[word] = 0;
                }
                wordFrequencies[word]++;
            }

            // Сортируем слова по убыванию их частоты
            var topWords = wordFrequencies.OrderByDescending(kvp => kvp.Value).Take(10);

            // Выводим результат
            Console.WriteLine("Топ-10 наиболее часто встречающихся слов:");
            foreach (var item in topWords)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }
    }
}