using Shop_DAL.DTOs;
using Shop_DAL.Models;

namespace Shop_DAL.Repositories.Interfaces
{
    public interface ICustomerRepository
    {
        Task<Customer> GetCustomerByIdAsync(Guid customerId);
        Task<IEnumerable<CustomerBirthdayDto>> GetCustomersBirthdaysAsync(DateTime date);
        Task<IEnumerable<RecentCustomerDto>> GetRecentCustomersAsync(int days);
        Task<IEnumerable<CategoryStatisticsDto>> GetCustomerCategoryStatisticsAsync(Guid customerId);
    }
}
