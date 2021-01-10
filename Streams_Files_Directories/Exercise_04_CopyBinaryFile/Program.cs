using System.IO;

namespace Exercise_04_CopyBinaryFile
{
    class Program
    {
        static void Main(string[] args)
        {
            using (FileStream read = new FileStream("../../../IMG_7350.JPG", FileMode.Open))
            {
                using (FileStream writer = new FileStream("../../../ready_1.JPG", FileMode.CreateNew))
                {
                    byte[] buffer = new byte[4096];

                    while (read.CanRead)
                    {
                        int byteRead = read.Read(buffer, 0, buffer.Length);

                        if (byteRead==0)
                        {
                            break;
                        }

                        writer.Write(buffer, 0, buffer.Length);
                    }
                }
            }
        }
    }
}
