using System;

namespace MySampleWebServer
{
    public class Request
    {
        public Request(string type, string uRL, string host)
        {
            Type = type;
            URL = uRL;
            Host = host;
        }

        public static Request GetRequest(String request)
        {
            if (String.IsNullOrEmpty(request))
                return null;

            return (new RequestMessageHandler()).RequestMessageParser(request);
        }

        public String Type { get; set; }
        public String URL { get; set; }
        public String Host { get; set; }
        
    }
}
