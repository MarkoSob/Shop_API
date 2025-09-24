using Microsoft.AspNetCore.Mvc;
using Shop_BL.Services.Interfaces;

namespace Shop_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet("birthdays")]
        public async Task<IActionResult> GetCustomersBirthdays([FromQuery] DateTime date)
        {
            var customers = await _customerService.GetCustomersBirthdaysAsync(date);
            return Ok(customers);
        }

        [HttpGet("recent")]
        public async Task<IActionResult> GetRecentCustomers([FromQuery] int days)
        {
            var customers = await _customerService.GetRecentCustomersAsync(days);
            return Ok(customers);
        }

        [HttpGet("{customerId}/categories")]
        public async Task<IActionResult> GetCustomerCategories(Guid customerId)
        {
            var categories = await _customerService.GetCustomerCategoryStatisticsAsync(customerId);
            return Ok(categories);
        }
    }
}