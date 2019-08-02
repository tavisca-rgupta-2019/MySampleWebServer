using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Text;

namespace MySampleWebServer
{
    class RequestMessageHandler
    {
        public String Type { get; set; }
        public String URL { get; set; }
        public String Host { get; set; }

        public string GetRequestMessage(TcpClient client)
        {
            StreamReader reader = new StreamReader(client.GetStream());
            String msg = "";
            while (reader.Peek() != -1)
                msg += reader.ReadLine() + "\n";
            return msg;
        }



        public Request RequestMessageParser(string requestMessage)
        {
            String[] tokens = requestMessage.Split(' ');
            String type = tokens[0];
            String url = tokens[1];
            String host = tokens[3].Substring(0, tokens[3].IndexOf('\n'));
            String referer = "";
            for (int i = 0; i < tokens.Length; i++)
            {
                if (tokens[i] == "Referer:")
                {
                    referer = tokens[i + 1];
                    break;
                }
            }
            Console.WriteLine($"{type} {url} @ {host} \nReferer: {referer}");
            return new Request(type, url, host);
        }

    }
}
