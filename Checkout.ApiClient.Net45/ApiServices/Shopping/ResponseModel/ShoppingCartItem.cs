using System;

namespace Checkout.ApiServices.Shopping.ResponseModel
{
    public class ShoppingCartItem
    {
        public int Quantity { get; set; }
        public IComparable Id { get; set; }
    }
}