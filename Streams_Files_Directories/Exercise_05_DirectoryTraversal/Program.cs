using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace Exercise_05_DirectoryTraversal
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, double>> fileInfo = new Dictionary<string, Dictionary<string, double>>();
            string directoryPath = @"/Users/stefanpetrov/Softuni/Demo/";
            DirectoryInfo directoryInfo = new DirectoryInfo(directoryPath);

            FileInfo[] files = directoryInfo.GetFiles();

            foreach (var file in files)
            {
                string extention = file.Extension.ToString();

                if (fileInfo.ContainsKey(file.Extension) == false)
                {
                    fileInfo.Add(extention, new Dictionary<string, double>());
                }
                fileInfo[file.Extension].Add(file.Name, file.Length / 1000);
            }

            string saveLocationPath =
                "/Users/stefanpetrov/Softuni/VS2019/Streams_Files_Directories/Exercise_05_DirectoryTraversal/report.txt";

            using (StreamWriter write = new StreamWriter(saveLocationPath))
            {
                foreach (var ext in fileInfo.OrderByDescending(x => x.Value.Count))
                {
                    write.WriteLine(ext.Key);

                    foreach (var file in ext.Value.OrderBy(x=>x.Value))
                    {
                        write.WriteLine($"--{file.Key} - {file.Value}kb");
                    }
                }
            }
        }
    }
}
