using System.Net;

namespace Checkout.ApiServices.Shopping.ResponseModel
{
    public class ErrorCommandResponse : BasicCommandResponse
    {
        public ErrorCommandResponse(HttpStatusCode code, object content = null)
        {
            IsSuccess = false;
            Code = code;
            Content = content;
        }
    }
}