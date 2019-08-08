using System;
using System.Collections.Generic;
using System.Text;

namespace MySampleWebServer
{
    class ErrorHandler
    {
        private static Dictionary<int, IError> ErrorMessages = new Dictionary<int, IError>
    {
        {400,new MakeNullRequest() },
        {405,new MakeMethodNotAllowed() },
        {404,new MakePageNotFound() }
    };
        public static httpResponse GetErrorResponseMessage(int statusCode)
        {
            IError errorMessage= ErrorMessages[statusCode];
            return errorMessage.GetResponse();
        }
      
        

    }
}
