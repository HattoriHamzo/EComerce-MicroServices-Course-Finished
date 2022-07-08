namespace ECommerce.Api.Orders.Interfaces
{
    public interface IOrdersProvider
    {
        Task<(bool isSuccess, IEnumerable<Model.Order> Orders, string ErrorMessage)> GetOrdersAsync(int customerId);
        //Task<(bool isSuccess, IEnumerable<DataBase.Order>, string ErrorMessage)> GetOrderById(int id);
    }
}
