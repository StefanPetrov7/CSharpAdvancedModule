using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Exercise_01_EvenLines
{
    class Program
    {
        static void Main(string[] args)
        {
            Regex symbols = new Regex(@"[-,\.\?\!]");

            using (StreamReader read = new StreamReader("../../../text.txt"))
            {
                using (StreamWriter write = new StreamWriter("../../../input.txt"))
                {
                    string line;
                    int counter = 0;

                    while ((line = read.ReadLine())!= null)
                    {
                        if (counter%2==0)
                        {
                            line = symbols.Replace(line, "@");
                            string[] result = line.Split().ToArray().Reverse().ToArray();
                            write.WriteLine(line);
                        }
                        counter++;

                    }
                }
            }
        }
    }
}
