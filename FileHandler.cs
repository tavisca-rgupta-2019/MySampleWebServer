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
        private static readonly Dictionary<string, string> MimetypesDictionary = new Dictionary<string, string>
            {
            {".html","text/html"},
            {".htm","text/htm"},
            {".png","image/png"},
            {".jpeg","image/jpeg"},
            {".bmp","image/bmp"},
            {".jpg","image/jpg"},
            {".txt","text/txt"}
            };
        public static httpResponse GetResponse(RequestParser parsedRequest)
        { string filePath = Environment.CurrentDirectory + HTTPServer.WEB_DIR + parsedRequest.Url;
            FileInfo file = new FileInfo(filePath);
            if (!file.Exists)
                return GetFileFromDirectory(filePath + "/");
            return GetResponseMessage(file);
        }

        public static httpResponse GetResponseMessage(FileInfo f)
        { string mimetype = MimetypesDictionary[f.Extension];
            FileStream fs = f.OpenRead();
            BinaryReader reader = new BinaryReader(fs);
            Byte[] d = new Byte[fs.Length];
            reader.Read(d, 0, d.Length);
            fs.Close();
            return new httpResponse("200 OK", mimetype, d);
        }

        public static byte[] ConvertingFileToByteArray(string file)
        {
            FileInfo f = new FileInfo(file);
            FileStream fs = f.OpenRead();
            BinaryReader reader = new BinaryReader(fs);
            Byte[] d = new Byte[fs.Length];
            reader.Read(d, 0, d.Length);
            fs.Close();
            return d;
        }


        public static httpResponse GetFileFromDirectory(string directoryPath)
        {
            DirectoryInfo directory = new DirectoryInfo(directoryPath);
            FileInfo[] files = directory.GetFiles();
            foreach (FileInfo ff in files)
            {
                string n = ff.Name;
                if (n.Contains("index.html") || n.Contains("index.htm") || n.Contains("default.html") || n.Contains("default.htm"))
                    return GetResponseMessage(ff);
            }
            return null;
        }
    }
}
