using Klir.TechChallenge.Web.Api.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Klir.TechChallenge.Web.Api.Data
{
    public class ProductsDB
    {
        public readonly List<Product> products = new List<Product>()
        {
            new Product { Id = 1, Name = "Product A", Price = 20, PromotionId = 1 },
            new Product { Id = 2, Name = "Product B", Price = 4, PromotionId = 2 },
            new Product { Id = 3, Name = "Product C", Price = 2 },
            new Product { Id = 4, Name = "Product D", Price = 4, PromotionId = 2}
        };
    }
}
