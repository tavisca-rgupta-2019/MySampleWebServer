using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace MySampleWebServer
{
    class HTTPServer
    {
        public const string MSG_DIR = "/root/msg/";
        public const string WEB_DIR = "/root/web/";
        public const string VERSION = "HTTP/1.1";
        public const string NAME = "HTTP WebServer v0.1";
        private bool running = false;
        private TcpListener server;

        public HTTPServer(int port)
        {
            server = new TcpListener(IPAddress.Any, port);
        }

        public void Start()
        {   server.Start();
            Console.WriteLine("Waiting for connection....");
            while (true)
            {   TcpClient client = server.AcceptTcpClient();
                Thread clientThread = new Thread(new ThreadStart(() => new Httplistener(client)));
                clientThread.Start();
            }
        }
            

       

        /*private void Run(TcpClient client)
        {
            //running = true;
            //listener.Start();
          
                //Console.WriteLine("Waiting for connection....");
                //TcpClient client = listener.AcceptTcpClient();
                Console.WriteLine("Client connected");
                ClientHandler handle=new ClientHandler(client);
                client.Close();
            
           
        }*/

       

        
    }
}
