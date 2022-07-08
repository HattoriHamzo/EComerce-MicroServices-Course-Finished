using ECommerce.Api.Search.Model;

namespace ECommerce.Api.Search.Interfaces
{
    public interface IProductService
    {
        Task<(bool isSuccess, IEnumerable<Product> Products, string ErrorMessage)> GetProductsAsync();
    }
}
