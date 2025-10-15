// Areas/Products/Models/ProductModel.cs
namespace MiniShopBE.Areas.Products.Models
{
    public class ProductModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public decimal Price { get; set; }
        public string? Description { get; set; }
    }
}
