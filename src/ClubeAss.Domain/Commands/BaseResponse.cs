using System.Net;

namespace ClubeAss.Domain.Commands
{
    public class BaseResponse
    {
        public BaseResponse(HttpStatusCode statusCode, object content = null)
        {
            StatusCode = statusCode;
            Content = content;
        }

        public HttpStatusCode StatusCode;
        public object Content { get; set; }
    }
}
