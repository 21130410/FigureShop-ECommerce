using FigureShopSharedLibrary.Models;
using FigureShopSharedLibrary.Respones;


namespace FigureShopSharedLibrary.Contracts
{
    public interface IProduct
    {
        Task<ServiceRespone> AddProduct(Product model);
        Task<List<Product>> GetAllProducts(bool featuredProducts);
        
    }
}
