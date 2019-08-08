using System;
using System.Collections.Generic;
using System.Text;

namespace MySampleWebServer
{
    interface IError
    {
        httpResponse GetResponse();
    }
}
