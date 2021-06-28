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
    [Route("products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly List<Product> products = new ProductsDB().products;
        private readonly List<Promotion> promotions = new PromotionsDB().promotions;

        // GET /products
        [HttpGet]
        public List<ProductsDtos> GetProducts()
        {
            var result = new List<ProductsDtos>();

            foreach (var item in products)
            {
                result.Add(new ProductsDtos() { Id = item.Id, Name = item.Name, Price = item.Price, PromotioName = promotions.FirstOrDefault(t => t.Id == item.PromotionId)?.Name  });
            }

            return result;
        }
    }
}
