using Klir.TechChallenge.Web.Api.Data;
using Klir.TechChallenge.Web.Api.Dtos;
using Klir.TechChallenge.Web.Api.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Klir.TechChallenge.Web.Api.Controllers
{
    [Route("shoppingcart")]
    [ApiController]
    public class ShoppingCartController : ControllerBase
    {
        private readonly List<Product> products = new ProductsDB().products;
        private readonly List<Promotion> promotions = new PromotionsDB().promotions;

        [HttpPost]
        public List<CheckOutProductReturn> GetCheckOutTotal(List<CheckOutProductRequest> Products)
        {
            var listProductsCheckoutCart = new List<CheckOutProductReturn>();

            if (Products is null)
            {
                return null;
            }

            foreach (var product in Products)
            {
                listProductsCheckoutCart.Add(CalculateProductPrice(product));
            }

            return listProductsCheckoutCart;
        }

        private CheckOutProductReturn CalculateProductPrice(CheckOutProductRequest Product)
        {
            if (Product is null)
            {
                return null;
            }

            var objProduct = products.Find(t => t.Id == Product.Id);
            var promotion = promotions.Find(t => t.Id == objProduct.PromotionId);

            var result = new CheckOutProductReturn()
            {
                Id = objProduct.Id,
                Name = objProduct.Name,
                Price = objProduct.Price,
                PromotioName = promotion?.Name,
                Quantity = Product.Quantity
            };

            if (promotion != null && Product.Quantity >= promotion.Quantity)
            {
                result.TotalPrice += (Product.Quantity / promotion.Quantity * promotion.Price) + Product.Quantity % promotion.Quantity * objProduct.Price;
            }
            else
            {
                result.TotalPrice += objProduct.Price * Product.Quantity;
            }

            return result;
        }
    }
}
