using System.Net;

namespace Checkout.ApiServices.Shopping.ResponseModel
{
    public class BasicCommandResponse
    {
        public bool IsSuccess { get; set; }
        public object Content { get; set; }
        public HttpStatusCode Code { get; set; }
    }
}