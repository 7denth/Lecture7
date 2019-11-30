using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Lecture7
{
    class Program
    {
        static void Main(string[] args)
        {
            //Task 1
            if (!File.Exists(@"F:\test\data.txt"))
            {
                FileStream data = File.Create(@"F:\test\data.txt");
                data.Close();
            }
            FileInfo rez = new FileInfo(@"F:\test\rex.txt");
            if (!rez.Exists)
            {
                rez.Create();
            }
            string text = "";
            using (StreamReader read = new StreamReader(@"F:\test\lectures.txt", System.Text.Encoding.Default))
            {
                text = read.ReadToEnd();
            }
            using (StreamWriter write = new StreamWriter(@"F:\test\data.txt", false, System.Text.Encoding.Default))
            {
                write.WriteLine(text);
            }
            string text2 = File.ReadAllText(@"F:\test\data.txt");
            File.WriteAllText(@"F:\test\rex.txt", text);

            //Task 2
            if (!File.Exists(@"F:\test\DirectoryC.txt"))
            {
                FileStream data = File.Create(@"F:\test\DirectoryC.txt");
                data.Close();
            }
            string dirPath = "C:\\";
            if (Directory.Exists(dirPath))
            {
                string[] dirs = Directory.GetDirectories(dirPath);
                foreach (string x in dirs)
                {
                    using (StreamWriter copy = new StreamWriter(@"F:\test\DirectoryC.txt", true, System.Text.Encoding.Default))
                    {
                        copy.WriteLine(x);
                    }
                }
                string[] files = Directory.GetFiles(dirPath);
                foreach (string y in files)
                {
                    using (StreamWriter copy = new StreamWriter(@"F:\test\DirectoryC.txt", true, System.Text.Encoding.Default))
                    {
                        copy.WriteLine(y);
                    }
                }
            }

            //Task 3
            string path = @"E:\\";
            if (Directory.Exists(path))
            {
                string[] allFiles = Directory.GetFiles(path);
                List<string> paths = new List<string>();
                foreach (string line in allFiles)
                {
                    string[] txtFiles = line.Split('.');
                    for (int i = 0; i < txtFiles.Length; i++)
                    {
                        if (txtFiles[i] == "txt")
                        {
                            paths.Add(txtFiles[i - 1] + "." + txtFiles[i]);
                        }
                    }
                }

                List<string> data = new List<string>();
                foreach (string address in paths)
                {
                    data.Add(File.ReadAllText(address));
                }

                foreach (string line in data)
                {
                    Console.WriteLine(line);
                }
            }
            
            Console.ReadKey();
        }
    }
}
