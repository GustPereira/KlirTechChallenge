namespace Klir.TechChallenge.Web.Api.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int PromotionId { get; internal set; }
    }
}
