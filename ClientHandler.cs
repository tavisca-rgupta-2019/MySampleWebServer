using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Sockets;
using System.Text;

namespace MySampleWebServer
{
    class ClientHandler
    {   public ClientHandler(TcpClient client)
        {
            string requestMessage =(new RequestMessageHandler()).GetRequestMessage(client);
            Debug.WriteLine("Request: \n" + requestMessage);
            Request request = Request.GetRequest(requestMessage);
            Response response = Response.From(request);
            response.Post(client.GetStream());
        }
    }
}
