using Microsoft.Extensions.Logging;
using Shop_BL.Services.Interfaces;
using Shop_DAL.DTOs;
using Shop_DAL.Repositories.Interfaces;

namespace Shop_BL.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly ILogger<CustomerService> _logger;

        public CustomerService(ICustomerRepository customerRepository, ILogger<CustomerService> logger)
        {
            _customerRepository = customerRepository;
            _logger = logger;
        }

        public async Task<IEnumerable<CustomerBirthdayDto>> GetCustomersBirthdaysAsync(DateTime date)
        {
            _logger.LogInformation($"Getting birthday customers for date: {date.ToShortDateString()}");
            var result = await _customerRepository.GetCustomersBirthdaysAsync(date);

            if (result.Count() == 0)
            {
                _logger.LogError($"Getting of customers birthdays failed - there are no customers with the birth date {date.ToShortDateString()}");
                throw new ArgumentException($"Found 0 customers with the birth date {date.ToShortDateString()}");
            }

            _logger.LogInformation($"Found {result.Count()} birthday customers");
            return result;
        }

        public async Task<IEnumerable<RecentCustomerDto>> GetRecentCustomersAsync(int days)
        {
            if (days < 0)
            {
                _logger.LogError("Getting of recent customers failed - Number of days should be positive or 0");
                throw new ArgumentException("Number of days should be positive or 0");
            }

            _logger.LogInformation($"Getting recent customers for last {days} days");
            var result = await _customerRepository.GetRecentCustomersAsync(days);
            _logger.LogInformation($"Found {result.Count()} recent customers");
            return result;
        }

        public async Task<IEnumerable<CategoryStatisticsDto>> GetCustomerCategoryStatisticsAsync(Guid customerId)
        {
            var customer = await _customerRepository.GetCustomerByIdAsync(customerId); 

            if (customer is null)
            {
                _logger.LogError($"Getting of customers statistics failed - customer with ID: {customerId} is not found");
                throw new ArgumentException($"Customer with ID: {customerId} is not found");
            }

            _logger.LogInformation($"Getting categories for customer: {customerId}");
            var result = await _customerRepository.GetCustomerCategoryStatisticsAsync(customerId);
            _logger.LogInformation($"Found {result.Count()} categories for customer");
            return result;
        }
    }
}
