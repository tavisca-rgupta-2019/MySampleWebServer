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
        public const string NAME = "Rohit's Personal HTTP WebServer v0.1";
        private bool running = false;
        private TcpListener listener;

        public HTTPServer(int port)
        {
            listener = new TcpListener(IPAddress.Any, port);
        }

        public void Start()
        {
            listener.Start();
            while (true)
            {
                Console.WriteLine("Waiting for connection....");
                TcpClient client = listener.AcceptTcpClient();

                Thread serverThread = new Thread(new ThreadStart(() => Run(client)));
                serverThread.Start();
            }
        }

        private void Run(TcpClient client)
        {
            //running = true;
            //listener.Start();
          
                //Console.WriteLine("Waiting for connection....");
                //TcpClient client = listener.AcceptTcpClient();
                Console.WriteLine("Client connected");
                ClientHandler handle=new ClientHandler(client);
                client.Close();
            
           
        }

       

        
    }
}
