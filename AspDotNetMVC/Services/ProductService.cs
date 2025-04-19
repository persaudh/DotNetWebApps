using AspDotNetCoreMVC.Data;

namespace AspDotNetCoreMVC.Services
{
    public class ProductService : IProductService
    {
        public Task<List<Product>> GetTopProductsAsync(int count)
        {
            var products = new List<Product>
            {
                new Product("Laptop", 1200),
                new Product("Smartphone", 800),
                new Product("Tablet", 600),
                new Product("Smartwatch", 300),
                new Product("Headphones", 150),
                new Product("Monitor", 400),
                new Product("Keyboard", 100),
                new Product("Mouse", 50),
                new Product("Printer", 200),
                new Product("Speaker", 250),
                new Product("Camera", 900),
                new Product("Drone", 1500),
                new Product("Smart TV", 2000),
                new Product("Game Console", 500),
                new Product("VR Headset", 350),
                new Product("External Hard Drive", 120),
                new Product("USB Flash Drive", 20)
            };

            return Task.FromResult(products.Take(count).ToList());
        }
    }
}
