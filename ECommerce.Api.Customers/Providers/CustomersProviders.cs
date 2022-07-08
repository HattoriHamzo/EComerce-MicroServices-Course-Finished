using AutoMapper;
using ECommerce.Api.Customers.DataBase;
using ECommerce.Api.Customers.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Api.Customers.Providers
{
    public class CustomersProviders : ICustomersProvider
    {
        private readonly CustomerDbContext dbContext;
        private readonly ILogger<CustomersProviders> logger;
        private readonly IMapper mapper;

        public CustomersProviders(CustomerDbContext dbContext, ILogger<CustomersProviders> logger, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.logger = logger;
            this.mapper = mapper;

            SeedData();
        }

        private void SeedData()
        {
            if (!dbContext.Customers.Any())
            {
                dbContext.Customers.Add(new Customer() { Id = 1, Name = "Customer One", Address = "Customer Address"});
                dbContext.Customers.Add(new Customer() { Id = 2, Name = "Customer Two", Address = "Customer Address" });
                dbContext.Customers.Add(new Customer() { Id = 3, Name = "Customer Three", Address = "Customer Address" });
                dbContext.Customers.Add(new Customer() { Id = 4, Name = "Customer Four", Address = "Customer Address" });
                dbContext.Customers.Add(new Customer() { Id = 5, Name = "Customer Five", Address = "Customer Address" });
                dbContext.SaveChanges();
            }
        }

        public async Task<(bool isSuccess, IEnumerable<Model.Customer> Customers, string ErrorMessage)> GetCustomersAsync() 
        {
           

            try 
            {
                var customers = await dbContext.Customers.ToListAsync();
                if (customers != null && customers.Any())
                {
                    var result = mapper.Map<IEnumerable<Customer>, IEnumerable<Model.Customer>>(customers);

                    return (true, result, null);
                }

                return (false, null, "Not Found");

            }catch(Exception ex)
            {
                logger?.LogError(ex.ToString());
                return (false, null, ex.Message);
            }
        }

        public async Task<(bool IsSuccess, Model.Customer Customer, string ErrorMessage)> GetCustomerByIdAsync(int id)
        {
            try
            {

                var customer = await dbContext.Customers.FirstOrDefaultAsync(c => c.Id == id);

                if(customer != null)
                {

                    var result = mapper.Map<Customer, Model.Customer>(customer);
                    return (true, result, null);
                }

                return (false, null, "Not Found");

            }catch(Exception ex)
            {
                logger?.LogError(ex.ToString());
                return (false, null, ex.Message);
            }
        }
    }
}
