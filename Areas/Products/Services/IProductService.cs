using System.Collections.Generic;
using MiniShopBE.Areas.Products.Models;

namespace MiniShopBE.Areas.Products.Services
{
    public interface IProductService
    {
        IEnumerable<ProductModel> GetAllProducts();
        ProductModel GetProductById(int id);
        ProductModel CreateProduct(ProductModel product);
        ProductModel UpdateProduct(int id, ProductModel product);
        void DeleteProduct(int id);
    }
}
