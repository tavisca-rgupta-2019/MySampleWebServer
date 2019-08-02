using System;
using System.Collections.Generic;
using System.Text;

namespace MySampleWebServer
{
    class ErrorHandler
    {
        public static Response MakeNullRequest()
        {
            String file = Environment.CurrentDirectory + HTTPServer.MSG_DIR + "400.html";
            Byte[] data = FileHandler.ConvertingFileToByteArray(file);
            return new Response("400 Bad Request", "text/html", data);
        }

        public static Response MakeMethodNotAllowed()
        {
            String file = Environment.CurrentDirectory + HTTPServer.MSG_DIR + "405.html";
            Byte[] data = FileHandler.ConvertingFileToByteArray(file);
            return new Response("405 Method Not Allowed", "text/html", data);


        }
        public  static Response MakePageNotFound()
        {

            String file = Environment.CurrentDirectory + HTTPServer.MSG_DIR + "404.html";
            Byte[] data = FileHandler.ConvertingFileToByteArray(file);
            return new Response("404 Page Not Found", "text/html", data);
        }


    }
}
