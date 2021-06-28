using Klir.TechChallenge.Web.Api.Controllers;
using Klir.TechChallenge.Web.Api.Dtos;
using System;
using System.Collections.Generic;
using Xunit;

namespace KlirTechChallenge.Tests
{
    public class ProductControllerTests
    {
        [Fact]
        public void ListProducts_ReturnProductDtoList()
        {
            // Arrange
            var controller = new ProductsController();

            // Act
            List<ProductsDtos> result = controller.GetProducts();

            // Assert
            Assert.NotNull(result);
        }
    }
}
