using System;
using System.Collections.Generic;
using System.IO;

namespace MySampleWebServer
{
    internal class httpResponse
    {
        private Byte[] _data = null;
        private string _status;
        private string _mime;
        
        public httpResponse(string status, string mime, Byte[] data)
        {
            _data = data;
            _status = status;
            _mime = mime;
        }
        public void Post(Stream stream)
        {
            StreamWriter writer = new StreamWriter(stream);
            writer.WriteLine(string.Format("{0} {1}\r\nServer: {2}\r\nContent-Type: {3}\r\nAccept-Ranges: bytes\r\nContent-Length: {4}\r\n", HTTPServer.VERSION, _status, HTTPServer.NAME, _mime, _data.Length));
            writer.Flush();
            stream.Write(_data, 0, _data.Length);

        }

    }
}