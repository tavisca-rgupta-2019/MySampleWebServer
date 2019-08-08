namespace MySampleWebServer
{
    internal class RequestParser
    {
        public string Host { get; set; }
        public string Url { get; set; }
        public string Method { get; set; }
        public string Referer { get; set; }

        public RequestParser(string requestMessage)
        {
            if (requestMessage == null)
            {
                Host = Url = Method = Referer = null;
            }
            else
            {
                string[] tokens = requestMessage.Split(' ');
                Method = tokens[0];
                Url = tokens[1];
                Host = tokens[3].Substring(0, tokens[3].IndexOf('\n'));
                Referer = "";
                for (int i = 0; i < tokens.Length; i++)
                {
                    if (tokens[i] == "Referer:")
                    {
                        Referer = tokens[i + 1];
                        break;
                    }
                }
            }
            //Console.WriteLine($"{type} {url} @ {host} \nReferer: {referer}");
         }
    }
}