using ECommerce.Api.Customers.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Api.Customers.Controllers
{
    [ApiController]
    [Route("api/customers")]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomersProvider customersProvider;

        public CustomersController(ICustomersProvider customersProvider)
        {
            this.customersProvider = customersProvider;
        }

        [HttpGet]
        public async Task<IActionResult> GetCustomersAsync()
        {
            var result = await customersProvider.GetCustomersAsync();   

            if (result.isSuccess)
            {
                return Ok(result.Customers);
            }

            return NotFound();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomerByIdAsync(int id)
        {
            var result = await customersProvider.GetCustomerByIdAsync(id);

            if (result.IsSuccess)
            {
                return Ok(result.Customer);
            }

            return NotFound();
        }


    }
}
