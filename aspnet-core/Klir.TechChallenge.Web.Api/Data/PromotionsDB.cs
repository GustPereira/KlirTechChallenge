using Klir.TechChallenge.Web.Api.Entities;
using System.Collections.Generic;

namespace Klir.TechChallenge.Web.Api.Data
{
    public class PromotionsDB
    {
        public readonly List<Promotion> promotions = new List<Promotion>()
        {
            new Promotion(){ Id = 1, Name = "Buy 1 Get 1 Free", Price = 20, Quantity = 2 },
            new Promotion(){ Id = 2, Name = "3 for 10 Euro", Price = 10, Quantity = 3 }
        };
    }
}
