using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Klir.TechChallenge.Web.Api.Dtos
{
    public class CheckOutProductRequest
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
    }

    public class CheckOutProductReturn
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal TotalPrice { get; set; }
        public string PromotioName { get; set; }
    }
}
