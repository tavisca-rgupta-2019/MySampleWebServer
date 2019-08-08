using System.IO;
using System.Net.Sockets;

namespace MySampleWebServer
{
    internal class HttpRequestHandler
    {
        public HttpRequestHandler(string requestMessage,TcpClient client)
        {
            httpResponse httpResponse = null;
            RequestParser parsedRequest = new RequestParser(requestMessage);
            if (!RequestValidator.IsValidRequest(parsedRequest, out int statusCode))
                httpResponse = ErrorHandler.GetErrorResponseMessage(statusCode);
            else
                httpResponse = FileHandler.GetResponse(parsedRequest);

            httpResponse.Post(client.GetStream());
        }

                
            

            
    }
       
}
