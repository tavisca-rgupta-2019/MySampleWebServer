using System.IO;
using System.Net.Sockets;
using System.Threading;

namespace MySampleWebServer
{
    public interface IGetStream
    {
        Stream GetStream();
    }
    public class Httplistener : IGetStream
    {
        private TcpClient wrappedClient;
       
        public Httplistener(TcpClient client)
        {
            wrappedClient = client;
            string requestMessage = GetRequestMessage();
            
            
            HttpRequestHandler request = new HttpRequestHandler(requestMessage,client);
        }
        public Stream GetStream()
        {
            return wrappedClient.GetStream();
        }

        public string GetRequestMessage()
        {
            StreamReader reader = new StreamReader(GetStream());
            string message = "";
            while (reader.Peek() != -1)
                message += reader.ReadLine() + "\n";
            return message;

        }
    }
    
}