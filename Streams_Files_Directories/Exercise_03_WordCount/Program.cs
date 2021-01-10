using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Exercise_03_WordCount
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = File.ReadAllLines("../../../words.txt");
            string text = File.ReadAllText("../../../text.txt");
            string[] textArr = text
                .Split(new char[] { '-', ',', '.', '!', '?', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            Dictionary<string, int> wordCount = new Dictionary<string, int>();

            for (int i = 0; i < words.Length; i++)
            {
                int count = textArr.Where(x => x.ToLower() == words[i].ToLower()).Count();
                wordCount.Add(words[i] + " - ", count);
            }

            int counter = 0;
            foreach (var word in wordCount)
            {
                words[counter] = word.Key.ToString() + word.Value.ToString();
                counter++;
            }

            File.WriteAllLines("../../../actualResult.txt", words);

            counter = 0;
            foreach (var word in wordCount.OrderByDescending(x => x.Value))
            {
                words[counter] = word.Key.ToString() + word.Value.ToString();
                counter++;
            }

            File.WriteAllLines("../../../expectedResult.txt", words);

        }
    }
}
