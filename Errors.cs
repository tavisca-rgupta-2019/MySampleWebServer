
using System;
using System.IO;

namespace MySampleWebServer
{
    class MakeNullRequest : IError
    {
        public httpResponse GetResponse()
        {
            String file = Environment.CurrentDirectory + HTTPServer.MSG_DIR + "400.html";
            Byte[] data = FileHandler.ConvertingFileToByteArray(file);
            return new httpResponse("400 Bad Request", "text/html", data);
            //throw new NotImplementedException();
        }
    }
  
    class MakeMethodNotAllowed : IError
    {
        public httpResponse GetResponse()
        {
            String file = Environment.CurrentDirectory + HTTPServer.MSG_DIR + "405.html";
            Byte[] data = FileHandler.ConvertingFileToByteArray(file);
            return new httpResponse("405 Method Not Allowed", "text/html", data);
           
        }
    }

    class MakePageNotFound : IError
    {
        public httpResponse GetResponse()
        {
            String file = Environment.CurrentDirectory + HTTPServer.MSG_DIR + "404.html";
            Byte[] data = FileHandler.ConvertingFileToByteArray(file);
            return new httpResponse("404 Page Not Found", "text/html", data);
            //throw new NotImplementedException();
        }
    }


}