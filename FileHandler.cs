using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MySampleWebServer
{
    class FileHandler
    {
        static readonly String pageNotFoundFile = Environment.CurrentDirectory + HTTPServer.MSG_DIR + "404.html";
        static readonly String methodNotAllowedfile = Environment.CurrentDirectory + HTTPServer.MSG_DIR + "405.html";
        static readonly String nullRequestfile = Environment.CurrentDirectory + HTTPServer.MSG_DIR + "400.html";
        public static Byte[] ConvertingFileToByteArray(string filePath)
        {
            FileInfo file = new FileInfo(filePath);
            FileStream fs = file.OpenRead();
            BinaryReader reader = new BinaryReader(fs);
            Byte[] d = new Byte[fs.Length];
            reader.Read(d, 0, d.Length);
            fs.Close();
            return d;
        }
        public static FileInfo GetFileFromDirectory(string directoryPath)
        {
            DirectoryInfo directory = new DirectoryInfo(directoryPath);
            FileInfo[] files = directory.GetFiles();
            foreach (FileInfo ff in files)
            {
                string n = ff.Name;
                if (n.Contains("index.html") || n.Contains("index.htm") || n.Contains("default.html") || n.Contains("default.htm"))
                    return ff;
            }
            return new FileInfo(pageNotFoundFile);
        }
    }
}
