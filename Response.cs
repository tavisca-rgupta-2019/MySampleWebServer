using System;
using System.Collections.Generic;
using System.IO;

namespace MySampleWebServer
{
    public class Response
    {
        private Byte[] _data = null;
        private string _status;
        private string _mime;

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

        public Response(String status, string mime, Byte[] data)
        {
            _data = data;
            _status = status;
            _mime = mime;
        }

        public static Response From(Request request)
        {
            if (request == null)
                return new ErrorHandler().MakeNullRequest();
            return ResponseHandler(request);
        }

       


       
       

        private static Response MakeFromFile(FileInfo f)
        {
            string mimetype = MimetypesDictionary[f.Extension];

            FileStream fs = f.OpenRead();
            BinaryReader reader = new BinaryReader(fs);
            Byte[] d = new Byte[fs.Length];
            reader.Read(d, 0, d.Length);
            fs.Close();
            return new Response("200 OK", mimetype, d);
        }

       
        public void Post(Stream stream)
        {
            StreamWriter writer = new StreamWriter(stream);
            writer.WriteLine(string.Format("{0} {1}\r\nServer: {2}\r\nContent-Type: {3}\r\nAccept-Ranges: bytes\r\nContent-Length: {4}\r\n", HTTPServer.VERSION, _status, HTTPServer.NAME, _mime, _data.Length));
            writer.Flush();
            stream.Write(_data, 0, _data.Length);
            
        }

        public static Response ResponseHandler(Request request)
        {
            if (request.Type != "GET")
                return ErrorHandler.MakeMethodNotAllowed();
            else
                return ResponseParser(request);

        }


        private static Response ResponseParser(Request request)
        {
            string filePath = Environment.CurrentDirectory + HTTPServer.WEB_DIR + request.URL;
            if (!IsValidFile(filePath))
                return GetResponseFile(filePath);
            else
            { FileInfo file = new FileInfo(filePath);
                return MakeFromFile(file);
            }
        }


        private static Response GetResponseFile(string filePath)
        { if (!IsValidDirectory(filePath + "/"))
                return ErrorHandler.MakePageNotFound();
            else
            {
                FileInfo file = FileHandler.GetFileFromDirectory(filePath + "/");
                return MakeFromFile(file);
            }
        }


        private static bool IsValidFile(string filePath)
        {
            FileInfo file = new FileInfo(filePath);
            return file.Exists;
        }

        private static bool IsValidDirectory(string directoryPath)
        {
            DirectoryInfo dir = new DirectoryInfo(directoryPath);
            return dir.Exists;
        }







       
    }
}



     
