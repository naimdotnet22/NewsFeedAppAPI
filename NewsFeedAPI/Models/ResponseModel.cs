using NewsFeedAPI.Enums;

namespace NewsFeedAPI.Models
{
    public class ResponseModel
    {
        public ResponseModel(ResponseCode statusCode, string message, object data)
        {
            StatusCode = statusCode;
            Message = message;
            Data = data;
        }
        public ResponseCode StatusCode { get; set; }
        public string Message { get; set; } = string.Empty;
        public object Data { get; set; } = null;
    }
}
