using System.IO;
using System.Text.RegularExpressions;

namespace Exercise_02_Line_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader read = new StreamReader("../../../text.txt"))
            {
                using (StreamWriter write = new StreamWriter("../../../input.txt"))
                {
                    Regex symbols = new Regex(@"[-\,\!\?\.\']");
                    Regex letters = new Regex(@"[A-z]");
                    int counter = 1;
                    string textLine;

                    while ((textLine = read.ReadLine())!=null)
                    {
                        int letterCount = letters.Matches(textLine).Count;
                        int macthes = symbols.Matches(textLine).Count;
                        write.WriteLine($"Line {counter}: {textLine}({letterCount})/({macthes})");
                        counter++;
                    }
                }
            }
        }
    }
}
