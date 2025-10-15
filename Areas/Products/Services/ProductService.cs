using MiniShopBE.Areas.Products.Models;
using MiniShopBE.Data;

namespace MiniShopBE.Areas.Products.Services
{
    public class ProductService : IProductService
    {
        private readonly AppDbContext _context;

        public ProductService(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<ProductModel> GetAllProducts()
        {
            return _context.Products.ToList();
        }

        public ProductModel GetProductById(int id)
        {
            var product = _context.Products.Find(id);
            if (product == null)
                throw new KeyNotFoundException($"Product with ID {id} not found");
            return product;
        }

        public ProductModel CreateProduct(ProductModel product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
            return product;
        }

        public ProductModel UpdateProduct(int id, ProductModel product)
        {
            var existing = _context.Products.Find(id);
            if (existing == null)
                throw new KeyNotFoundException($"Product with ID {id} not found");

            existing.Name = product.Name;
            existing.Price = product.Price;
            existing.Description = product.Description;

            _context.Products.Update(existing);
            _context.SaveChanges();
            return existing;
        }

        public void DeleteProduct(int id)
        {
            var product = _context.Products.Find(id);
            if (product == null)
                throw new KeyNotFoundException($"Product with ID {id} not found");

            _context.Products.Remove(product);
            _context.SaveChanges();
        }
    }
}
