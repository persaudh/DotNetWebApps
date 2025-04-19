using AspDotNetCoreMVC.Data;

namespace AspDotNetCoreMVC.Services
{
    public interface IProductService
    {
        public Task<List<Product>> GetTopProductsAsync(int count);
    }
}
