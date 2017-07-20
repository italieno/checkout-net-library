using System.Net;
using Checkout.ApiServices.Shopping.RequestModels;
using FluentAssertions;
using NUnit.Framework;

namespace Tests
{
    [TestFixture(Category = "ShoppingApi")]
    public class ShoppingService : BaseServiceTests
    {
        //Beacuse Lack of time i've tested only the happy path for all the methods
        [Test]
        public void GetShoppingItemsShouldNotBeNull()
        {
            //Arrange
            CheckoutClient.ShoppingService.ResetItems();
            CheckoutClient.ShoppingService.AddItem(new ShoppingCartCommand("coca-cola", 10));
            CheckoutClient.ShoppingService.AddItem(new ShoppingCartCommand("sprite", 3));

            //Act
            var response = CheckoutClient.ShoppingService.GetAllItems();
            
            //Assert
            response.Should().NotBeNull();
            response.HttpStatusCode.Should().Be(HttpStatusCode.OK);
            response.Model.Count.Should().Be(2);
        }

        [Test]
        public void GetShoppingItemShouldRetrieveAnItem()
        {
            //Arrange
            CheckoutClient.ShoppingService.ResetItems();
            CheckoutClient.ShoppingService.AddItem(new ShoppingCartCommand("coffee", 3));

            //Act
            var response = CheckoutClient.ShoppingService.GetItem("coffee");

            //Assert
            response.Should().NotBeNull();
            response.HttpStatusCode.Should().Be(HttpStatusCode.OK);
            response.Model.Id.Should().Be("coffee");
            response.Model.Quantity.Should().Be(3);
        }

        [Test]
        public void AddShoppingItemShouldAddAnItemIfDoesntExist()
        {
            //Arrange
            CheckoutClient.ShoppingService.ResetItems();

            //Act
            var commandResponse = CheckoutClient.ShoppingService.AddItem(new ShoppingCartCommand("water", 3));
            
            //Assert
            commandResponse.Should().NotBeNull();
            commandResponse.HttpStatusCode.Should().Be(HttpStatusCode.OK);
            commandResponse.Model.Should().BeTrue();

            var queryResponse = CheckoutClient.ShoppingService.GetItem("water");

            queryResponse.Should().NotBeNull();
            queryResponse.HttpStatusCode.Should().Be(HttpStatusCode.OK);
            queryResponse.Model.Id.Should().Be("water");
            queryResponse.Model.Quantity.Should().Be(3);
        }

        [Test]
        public void UpdateShoppingItemShouldUpdateItemQuantity()
        {
            //Arrange
            CheckoutClient.ShoppingService.ResetItems();
            CheckoutClient.ShoppingService.AddItem(new ShoppingCartCommand("juice", 1));

            //Act
            var updateCommandResponse = CheckoutClient.ShoppingService.UpdateItem(new ShoppingCartCommand("juice", 8));

            //Assert
            updateCommandResponse.Should().NotBeNull();
            updateCommandResponse.HttpStatusCode.Should().Be(HttpStatusCode.OK);
            updateCommandResponse.Model.Should().BeTrue();

            var queryResponse = CheckoutClient.ShoppingService.GetItem("juice");

            queryResponse.Should().NotBeNull();
            queryResponse.HttpStatusCode.Should().Be(HttpStatusCode.OK);
            queryResponse.Model.Id.Should().Be("juice");
            queryResponse.Model.Quantity.Should().Be(8);
        }

        [Test]
        public void RemoveShoppingItemShouldRemoveDesiredItemQuantity()
        {
            //Arrange
            CheckoutClient.ShoppingService.ResetItems();
            CheckoutClient.ShoppingService.AddItem(new ShoppingCartCommand("lemonade", 10));

            //Act
            var removeCommandResponse = CheckoutClient.ShoppingService.RemoveItem(new ShoppingCartCommand("lemonade", 3));

            //Assert
            removeCommandResponse.Should().NotBeNull();
            removeCommandResponse.HttpStatusCode.Should().Be(HttpStatusCode.OK);
            removeCommandResponse.Model.Should().BeTrue();

            var queryResponse = CheckoutClient.ShoppingService.GetItem("lemonade");

            queryResponse.Should().NotBeNull();
            queryResponse.HttpStatusCode.Should().Be(HttpStatusCode.OK);
            queryResponse.Model.Id.Should().Be("lemonade");
            queryResponse.Model.Quantity.Should().Be(7);
        }

        [Test]
        public void ResetShoppingItemsShouldRemoveAllItemsFromTheCart()
        {
            //Arrange
            CheckoutClient.ShoppingService.AddItem(new ShoppingCartCommand("wine", 8));

            //Act
            var resetCommandResponse = CheckoutClient.ShoppingService.ResetItems();

            //Assert
            resetCommandResponse.Should().NotBeNull();
            resetCommandResponse.HttpStatusCode.Should().Be(HttpStatusCode.OK);
            resetCommandResponse.Model.Should().BeTrue();

            var queryResponse = CheckoutClient.ShoppingService.GetAllItems();

            queryResponse.Should().NotBeNull();
            queryResponse.HttpStatusCode.Should().Be(HttpStatusCode.OK);
            queryResponse.Model.Count.ShouldBeEquivalentTo(0);
        }
    }
}