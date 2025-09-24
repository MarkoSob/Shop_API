using Microsoft.EntityFrameworkCore;
using Shop_DAL.DTOs;
using Shop_DAL.Models;
using Shop_DAL.Repositories.Interfaces;

namespace Shop_DAL.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ShopDbContext _context;

        public CustomerRepository(ShopDbContext context) => _context = context;

        public async Task<Customer> GetCustomerByIdAsync(Guid customerId) =>
                await _context.Customers.AsNoTracking().FirstOrDefaultAsync(c => c.Id == customerId);

        public async Task<IEnumerable<CustomerBirthdayDto>> GetCustomersBirthdaysAsync(DateTime date) => 
                await _context.Customers
                .Where(c => c.DateOfBirth.Month == date.Month && c.DateOfBirth.Day == date.Day)
                .Select(c => new CustomerBirthdayDto
                {
                    Id = c.Id,
                    FullName = c.FullName
                })
                .ToListAsync();


        public async Task<IEnumerable<RecentCustomerDto>> GetRecentCustomersAsync(int days)
        {
            var cutoffDate = days == 0 ? DateTime.Today : DateTime.Now.AddDays(-days);

            var data = await _context.Customers
                .Where(c => c.Orders.Any(p => p.OrderDate >= cutoffDate))
                .Select(c => new
                {
                    c.Id,
                    c.FullName,
                    LastPurchaseDate = c.Orders
                        .Where(p => p.OrderDate >= cutoffDate)
                        .Max(p => (DateTime?)p.OrderDate) 
                })
                .OrderByDescending(c => c.LastPurchaseDate)
                .ToListAsync();

            return data.Select(c => new RecentCustomerDto
            {
                Id = c.Id,
                FullName = c.FullName,
                LastPurchaseDate = c.LastPurchaseDate?.ToShortDateString()
            });
        }

        public async Task<IEnumerable<CategoryStatisticsDto>> GetCustomerCategoryStatisticsAsync(Guid customerId) =>
                await _context.OrderItems
                .Include(oi => oi.Product)
                .Include(oi => oi.Order)
                .Where(oi => oi.Order.CustomerId == customerId)
                .GroupBy(oi => oi.Product.Category)
                .Select(g => new CategoryStatisticsDto
                {
                    Category = g.Key,
                    TotalQuantity = g.Sum(oi => oi.Quantity)
                })
                .OrderByDescending(cs => cs.TotalQuantity)
                .ToListAsync();
    }
}
