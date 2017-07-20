namespace Checkout.ApiServices.Shopping.RequestModels
{
    public class ShoppingCartCommand
    {
        public ShoppingCartCommand(string what, int howMany = 1)
        {
            What = what;
            HowMany = howMany;
        }

        public string What { get; }
        public int HowMany { get; }
    }
}