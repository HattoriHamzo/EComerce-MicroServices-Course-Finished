using ECommerce.Api.Search.Model;

namespace ECommerce.Api.Search.Interfaces
{
    public interface ICustomersService
    {
        Task<(bool isSuccess, dynamic Customer, string ErrorMessage)> GetCustomerAsync(int id);
    }
}
