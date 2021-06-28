using Klir.TechChallenge.Web.Api.Controllers;
using Klir.TechChallenge.Web.Api.Data;
using Klir.TechChallenge.Web.Api.Dtos;
using Klir.TechChallenge.Web.Api.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Klir.TechChallenge.Tests
{
    public class ShoppingCartControllerTests
    {
        private Random rng = new Random();
        private readonly List<Product> products = new ProductsDB().products;

        [Fact]
        public void GetCheckoutTotal_WithoutPromotionProduct_ReturnsEqualPrice()
        {
            // Arrange
            var checkOutList = new List<CheckOutProductRequest>()
            {
                new CheckOutProductRequest(){ Id = 3, Quantity = rng.Next(10)  },
            };

            var controller = new ShoppingCartController();

            // Act
            var result = controller.GetCheckOutTotal(checkOutList).FirstOrDefault();

            // Assert
            decimal expectedResult = 0;
            checkOutList.ForEach(t => expectedResult += products.Find(f => f.Id == t.Id).Price * t.Quantity);
            Assert.Equal(expectedResult, result.TotalPrice);
        }

        /// <summary>
        /// Product id: 1
        /// Product price: 20
        /// Promotion: Buy 1 Get 1 Free
        /// Notes: Does not apply with 1 product
        ///
        /// Product id: 2
        /// Product price: 4
        /// Promotion: 3 for 10 Euro
        /// </summary>

        [Theory]
        [InlineData(1, 1, 20)]
        [InlineData(1, 2, 20)]
        [InlineData(1, 3, 40)]
        [InlineData(1, 4, 40)]
        [InlineData(1, 5, 60)]
        [InlineData(2, 1, 4)]
        [InlineData(2, 2, 8)]
        [InlineData(2, 3, 10)]
        [InlineData(2, 4, 14)]
        [InlineData(2, 5, 18)]
        [InlineData(2, 6, 20)]
        [InlineData(2, 7, 24)]
        public void GetCheckoutTotal_WithPromotion_ReturnCalculatedPriceWithPromotion(int Id, int Quantity, decimal ExpectedPrice)
        {
            // Arrange
            var checkOutList = new List<CheckOutProductRequest>()
            {
                new CheckOutProductRequest() { Id = Id, Quantity = Quantity }
            };

            var controller = new ShoppingCartController();

            // Act
            var result = controller.GetCheckOutTotal(checkOutList).FirstOrDefault();

            // Assert
            Assert.Equal(ExpectedPrice, result.TotalPrice);
        }

        [Theory]
        [InlineData(new int[] { 1, 2, 3 }, new int[] { 2, 2, 5 }, 38)]
        [InlineData(new int[] { 1, 2, 4 }, new int[] { 5, 3, 1 }, 74)]
        [InlineData(new int[] { 1, 3, 4 }, new int[] { 1, 7, 3 }, 44)]
        [InlineData(new int[] { 2, 4, 3 }, new int[] { 1, 2, 3 }, 18)]
        public void GetCheckoutTotal_WithMixedProducts_ReturnCalculatedPrice(int[] Id, int[] Quantity, decimal ExpectedPrice)
        {
            // Arrange
            var checkOutList = new List<CheckOutProductRequest>();

            for (int i = 0; i < Id.Length; i++)
            {
                checkOutList.Add(new CheckOutProductRequest() { Id = Id[i], Quantity = Quantity[i] });
            }

            var controller = new ShoppingCartController();

            // Act
            var result = controller.GetCheckOutTotal(checkOutList);

            // Assert
            Assert.Equal(ExpectedPrice, result.Sum(t => t.TotalPrice));
        }

    }
}