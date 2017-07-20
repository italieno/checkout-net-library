using System.Net;

namespace Checkout.ApiServices.Shopping.ResponseModel
{
    public class SuccessCommandReponse : BasicCommandResponse
    {
        public SuccessCommandReponse() : this(null)
        {
        }

        public SuccessCommandReponse(object content)
        {
            IsSuccess = true;
            Content = content;
            Code = HttpStatusCode.OK;
        }
    }
}