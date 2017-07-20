using System.Collections.Generic;
using Checkout.ApiServices.SharedModels;
using Checkout.ApiServices.Shopping.RequestModels;
using Checkout.ApiServices.Shopping.ResponseModel;

namespace Checkout.ApiServices.Shopping
{
    public class ShoppingService
    {

        /// <summary>
        /// Get All Items from the shoping chart
        /// </summary>
        public HttpResponse<IList<ShoppingCartItem>> GetAllItems()
        {
            return new ApiHttpClient().GetRequest<IList<ShoppingCartItem>>(ApiUrls.ShoppingListIems, AppSettings.OAuthToken);
        }

        /// <summary>
        /// Get a single Item from the shoping chart
        /// </summary>
        public HttpResponse<ShoppingCartItem> GetItem(string name)
        {
            var getItemUri = string.Format(ApiUrls.ShoppingGetItem, name);
            return new ApiHttpClient().GetRequest<ShoppingCartItem>(getItemUri, AppSettings.OAuthToken);
        }

        /// <summary>
        /// Add an Item to the shoping chart
        /// </summary>
        public HttpResponse<bool> AddItem(ShoppingCartCommand command)
        {
            return new ApiHttpClient().PostRequest<bool>(ApiUrls.ShoppingAddItem, AppSettings.OAuthToken, command);
        }

        /// <summary>
        /// Remove an Item from the shoping chart
        /// </summary>
        public HttpResponse<bool> RemoveItem(ShoppingCartCommand command)
        {
            return new ApiHttpClient().DeleteRequest<bool>(ApiUrls.ShoppingRemoveItem, AppSettings.OAuthToken, command);
        }

        /// <summary>
        /// Update an Item in the shoping chart
        /// </summary>
        public HttpResponse<bool> UpdateItem(ShoppingCartCommand command)
        {
            return new ApiHttpClient().PutRequest<bool>(ApiUrls.ShoppingUpdateItem, AppSettings.OAuthToken, command);
        }

        /// <summary>
        /// Delete all items in the shoping chart
        /// </summary>
        public HttpResponse<bool> ResetItems()
        {
            return new ApiHttpClient().DeleteRequest<bool>(ApiUrls.ShoppingResetItems, AppSettings.OAuthToken);
        }
    }
}