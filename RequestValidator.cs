using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MySampleWebServer
{
    class RequestValidator
    {public static bool IsValidRequest(RequestParser parsedRequest,out int statusCode)
        {
            if (parsedRequest.Host == null)
            {
                statusCode = 400;
                return false;
            }
            else if(parsedRequest.Method!="GET")
            {
                statusCode = 405;
                return false;
            }
            return IsValidFile(parsedRequest,out statusCode);
        }

        public static bool IsValidFile(RequestParser parsedRequest, out int statusCode)
        {
            string filePath = Environment.CurrentDirectory + HTTPServer.WEB_DIR + parsedRequest.Url;
            FileInfo file = new FileInfo(filePath);
            if (file.Exists)
            {   statusCode = 200;
                return true; }
            return IsValidDirectory(filePath,out statusCode);

        }
        public static bool IsValidDirectory(string recievedfilePath,out int statusCode)
        { string directoryPath = recievedfilePath + "/";
            DirectoryInfo directory = new DirectoryInfo(directoryPath);
            if (!directory.Exists)
            {   statusCode = 404;
                return false;
            }
            return checkForDefaultFileInDirectory(directory,out statusCode);
        }

        public static bool checkForDefaultFileInDirectory(DirectoryInfo directoryPath,out int statusCode)
        {   FileInfo[] files = directoryPath.GetFiles();
            foreach (FileInfo ff in files)
            {   string n = ff.Name;
                if (n.Contains("index.html") || n.Contains("index.htm") || n.Contains("default.html") || n.Contains("default.htm"))
                {
                    statusCode = 200;
                    return true;
                }
            }
            statusCode = 404;
            return false;
        }








    }
}

