using System;
using System.IO;

namespace Lab_02_LineNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader demoFileRead = new StreamReader("../../../demoFile.txt"))
            {
                using (var demoFileOutput = new StreamWriter("../../../demoFileOutput.txt"))
                {
                    var line = demoFileRead.ReadLine();
                    int index = 1;

                    while (line != null)
                    {
                        demoFileOutput.WriteLine($"{index}. {line}");
                        Console.WriteLine($"{index}. {line}");
                        index++;
                        line = demoFileRead.ReadLine();
                    }
                }
            }
        } 
    }
}
