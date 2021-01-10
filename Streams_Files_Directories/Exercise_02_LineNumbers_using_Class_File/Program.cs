using System.IO;
using System.Text.RegularExpressions;

namespace Exercise_02_LineNumbers_using_Class_File
{
    class Program
    {
        static void Main(string[] args)
        {
            Regex symbols = new Regex(@"[-\,\!\?\.\']");
            Regex letters = new Regex(@"[A-z]");
            string[] lines = File.ReadAllLines("../../../text.txt");
            int letterCount = 0;
            int symbolCOunt = 0; 

            for (int i = 0; i < lines.Length; i++)
            {
                letterCount = letters.Matches(lines[i]).Count;
                symbolCOunt = symbols.Matches(lines[i]).Count;
                lines[i] =  $"Line {i+1}: {lines[i]} ({letterCount})({symbolCOunt})";
            }

            File.WriteAllLines("../../../output.txt", lines);
        }
    }
}
