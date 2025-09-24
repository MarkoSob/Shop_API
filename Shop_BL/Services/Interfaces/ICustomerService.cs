using Shop_DAL.DTOs;

namespace Shop_BL.Services.Interfaces
{
    public interface ICustomerService
    {
        Task<IEnumerable<CustomerBirthdayDto>> GetCustomersBirthdaysAsync(DateTime date);
        Task<IEnumerable<RecentCustomerDto>> GetRecentCustomersAsync(int days);
        Task<IEnumerable<CategoryStatisticsDto>> GetCustomerCategoryStatisticsAsync(Guid customerId);
    }
}
