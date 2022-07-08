using ECommerce.Api.Search.Interfaces;

namespace ECommerce.Api.Search.Services
{
    public class SearchService : ISearchService
    {
        private readonly IOrdersService ordersService;
        private readonly IProductService productService;
        private readonly ICustomersService customersService;

        public SearchService(IOrdersService ordersService, IProductService productService, ICustomersService customersService)
        {
            this.ordersService = ordersService;
            this.productService = productService;
            this.customersService = customersService;
        }
        public async Task<(bool isSuccess, dynamic SearchResults)> SearchAsync(int customerId)
        {
            var customersResult = await customersService.GetCustomerAsync(customerId);
            var ordersResult = await ordersService.GetOrdersAsync(customerId);
            var productsResult = await productService.GetProductsAsync();

            if (ordersResult.isSuccess)
            {
                foreach (var order in ordersResult.Orders)
                {
                    foreach (var item in order.Items)
                    {
                        item.ProductName = productsResult.isSuccess ?
                            productsResult.Products.FirstOrDefault(p => p.Id == item.ProductId)?.Name :
                            "Product information is not available";
                    }
                }
                var result = new
                {
                    Customer = customersResult.isSuccess ?
                                customersResult.Customer :
                                new { Name = "Customer information is not available"},
                    Orders = ordersResult.Orders
                };

                return (true, result);
            }
            return (false, null);
        }
    }
}
