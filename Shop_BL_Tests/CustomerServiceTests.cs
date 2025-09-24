using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;
using Shop_BL.Services;
using Shop_DAL.DTOs;
using Shop_DAL.Models;
using Shop_DAL.Repositories.Interfaces;

namespace Shop_BL_Tests
{
    public class CustomerServiceTests
    {
        private readonly Mock<ICustomerRepository> _mockCustomerRepository;
        private readonly Mock<ILogger<CustomerService>> _mockLogger;
        private readonly CustomerService _customerService;

        public CustomerServiceTests()
        {
            _mockCustomerRepository = new Mock<ICustomerRepository>();
            _mockLogger = new Mock<ILogger<CustomerService>>();
            _customerService = new CustomerService(_mockCustomerRepository.Object, _mockLogger.Object);
        }

        [Fact]
        public async Task GetCustomersBirthdaysAsync_WithValidDate_ShouldReturnCustomerBirthdays()
        {
            var testDate = new DateTime(2024, 1, 15);
            var expectedCustomers = new List<CustomerBirthdayDto>
            {
                new CustomerBirthdayDto { Id = Guid.NewGuid(), FullName = "Ivan Ivanenko Ivanovych" },
                new CustomerBirthdayDto { Id = Guid.NewGuid(), FullName = "Ivan Ivanenko Petrovych"}
            };

            _mockCustomerRepository
                .Setup(x => x.GetCustomersBirthdaysAsync(testDate))
                .ReturnsAsync(expectedCustomers);

            var result = await _customerService.GetCustomersBirthdaysAsync(testDate);

            result.Should().NotBeNull();
            result.Should().HaveCount(2);
            result.Should().BeEquivalentTo(expectedCustomers);

            _mockCustomerRepository.Verify(x => x.GetCustomersBirthdaysAsync(testDate), Times.Once);

            VerifyLogInformation($"Getting birthday customers for date: {testDate.ToShortDateString()}");
            VerifyLogInformation("Found 2 birthday customers");
        }

        [Fact]
        public async Task GetCustomersBirthdaysAsync_WithNoCustomersFound_ShouldThrowArgumentException()
        {
            var testDate = new DateTime(2024, 1, 15);
            var emptyCustomers = new List<CustomerBirthdayDto>();

            _mockCustomerRepository
                .Setup(x => x.GetCustomersBirthdaysAsync(testDate))
                .ReturnsAsync(emptyCustomers);

            var exception = await Assert.ThrowsAsync<ArgumentException>(
                () => _customerService.GetCustomersBirthdaysAsync(testDate));

            exception.Message.Should().Contain($"Found 0 customers with the birth date {testDate.ToShortDateString()}");

            _mockCustomerRepository.Verify(x => x.GetCustomersBirthdaysAsync(testDate), Times.Once);

            VerifyLogInformation($"Getting birthday customers for date: {testDate.ToShortDateString()}");
            VerifyLogError($"Getting of customers birthdays failed - there are no customers with the birth date {testDate.ToShortDateString()}");
        }

        [Fact]
        public async Task GetRecentCustomersAsync_WithValidDays_ShouldReturnRecentCustomers()
        {
            const int days = 7;
            var expectedCustomers = new List<RecentCustomerDto>
            {
                new RecentCustomerDto { Id = Guid.NewGuid(), FullName = "Ivan Ivanenko Ivanovych" },
                new RecentCustomerDto { Id = Guid.NewGuid(), FullName = "Ivan Ivanenko Petrovych" },
                new RecentCustomerDto { Id = Guid.NewGuid(), FullName = "Ivan Ivanenko Maksymovich" }
            };

            _mockCustomerRepository
                .Setup(x => x.GetRecentCustomersAsync(days))
                .ReturnsAsync(expectedCustomers);

            var result = await _customerService.GetRecentCustomersAsync(days);

            result.Should().NotBeNull();
            result.Should().HaveCount(3);
            result.Should().BeEquivalentTo(expectedCustomers);

            _mockCustomerRepository.Verify(x => x.GetRecentCustomersAsync(days), Times.Once);

            VerifyLogInformation($"Getting recent customers for last {days} days");
            VerifyLogInformation("Found 3 recent customers");
        }

        [Fact]
        public async Task GetRecentCustomersAsync_WithZeroDays_ShouldReturnRecentCustomers()
        {
            const int days = 0;
            var expectedCustomers = new List<RecentCustomerDto>
        {
            new RecentCustomerDto { Id = Guid.NewGuid(), FullName = "Ivan Ivanenko Ivanovych" }
        };

            _mockCustomerRepository
                .Setup(x => x.GetRecentCustomersAsync(days))
                .ReturnsAsync(expectedCustomers);

            var result = await _customerService.GetRecentCustomersAsync(days);

            result.Should().NotBeNull();
            result.Should().HaveCount(1);
            result.Should().BeEquivalentTo(expectedCustomers);

            _mockCustomerRepository.Verify(x => x.GetRecentCustomersAsync(days), Times.Once);
        }

        [Fact]
        public async Task GetRecentCustomersAsync_WithNegativeDays_ShouldThrowArgumentException()
        {
            const int negativeDays = -5;

            var exception = await Assert.ThrowsAsync<ArgumentException>(
                () => _customerService.GetRecentCustomersAsync(negativeDays));

            exception.Message.Should().Be("Number of days should be positive or 0");

            _mockCustomerRepository.Verify(x => x.GetRecentCustomersAsync(It.IsAny<int>()), Times.Never);

            VerifyLogError("Getting of recent customers failed - Number of days should be positive or 0");
        }

        [Fact]
        public async Task GetRecentCustomersAsync_WithNoCustomersFound_ShouldReturnEmptyCollection()
        {
            const int days = 30;
            var emptyCustomers = new List<RecentCustomerDto>();

            _mockCustomerRepository
                .Setup(x => x.GetRecentCustomersAsync(days))
                .ReturnsAsync(emptyCustomers);

            var result = await _customerService.GetRecentCustomersAsync(days);

            result.Should().NotBeNull();
            result.Should().BeEmpty();

            _mockCustomerRepository.Verify(x => x.GetRecentCustomersAsync(days), Times.Once);

            VerifyLogInformation("Found 0 recent customers");
        }

        [Fact]
        public async Task GetCustomerCategoryStatisticsAsync_WithValidCustomerId_ShouldReturnCategoryStatistics()
        {
            var customerId = Guid.NewGuid();
            var customer = new Customer { Id = customerId, FirstName = "Ivan" };
            var expectedStatistics = new List<CategoryStatisticsDto>
            {
                new CategoryStatisticsDto { Category = "Electronics", TotalQuantity = 15 },
                new CategoryStatisticsDto { Category = "Audio", TotalQuantity = 8 }
            };

            _mockCustomerRepository
                .Setup(x => x.GetCustomerByIdAsync(customerId))
                .ReturnsAsync(customer);

            _mockCustomerRepository
                .Setup(x => x.GetCustomerCategoryStatisticsAsync(customerId))
                .ReturnsAsync(expectedStatistics);

            var result = await _customerService.GetCustomerCategoryStatisticsAsync(customerId);

            result.Should().NotBeNull();
            result.Should().HaveCount(2);
            result.Should().BeEquivalentTo(expectedStatistics);

            _mockCustomerRepository.Verify(x => x.GetCustomerByIdAsync(customerId), Times.Once);
            _mockCustomerRepository.Verify(x => x.GetCustomerCategoryStatisticsAsync(customerId), Times.Once);

            VerifyLogInformation($"Getting categories for customer: {customerId}");
            VerifyLogInformation("Found 2 categories for customer");
        }

        [Fact]
        public async Task GetCustomerCategoryStatisticsAsync_WithNonExistentCustomer_ShouldThrowArgumentException()
        {
            var customerId = Guid.NewGuid();

            _mockCustomerRepository
                .Setup(x => x.GetCustomerByIdAsync(customerId))
                .ReturnsAsync((Customer)null);

            var exception = await Assert.ThrowsAsync<ArgumentException>(
                () => _customerService.GetCustomerCategoryStatisticsAsync(customerId));

            exception.Message.Should().Contain($"Customer with ID: {customerId} is not found");

            _mockCustomerRepository.Verify(x => x.GetCustomerByIdAsync(customerId), Times.Once);
            _mockCustomerRepository.Verify(x => x.GetCustomerCategoryStatisticsAsync(It.IsAny<Guid>()), Times.Never);

            VerifyLogError($"Getting of customers statistics failed - customer with ID: {customerId} is not found");
        }

        [Fact]
        public async Task GetCustomerCategoryStatisticsAsync_WithValidCustomerButNoCategories_ShouldReturnEmptyCollection()
        {
            var customerId = Guid.NewGuid();
            var customer = new Customer { Id = customerId, FirstName = "Ivan" };
            var emptyStatistics = new List<CategoryStatisticsDto>();

            _mockCustomerRepository
                .Setup(x => x.GetCustomerByIdAsync(customerId))
                .ReturnsAsync(customer);

            _mockCustomerRepository
                .Setup(x => x.GetCustomerCategoryStatisticsAsync(customerId))
                .ReturnsAsync(emptyStatistics);

            var result = await _customerService.GetCustomerCategoryStatisticsAsync(customerId);

            result.Should().NotBeNull();
            result.Should().BeEmpty();

            _mockCustomerRepository.Verify(x => x.GetCustomerByIdAsync(customerId), Times.Once);
            _mockCustomerRepository.Verify(x => x.GetCustomerCategoryStatisticsAsync(customerId), Times.Once);

            VerifyLogInformation("Found 0 categories for customer");
        }

        private void VerifyLogInformation(string message)
        {
            _mockLogger.Verify(
                x => x.Log(
                    LogLevel.Information,
                    It.IsAny<EventId>(),
                    It.Is<It.IsAnyType>((v, t) => v.ToString().Contains(message)),
                    It.IsAny<Exception>(),
                    It.IsAny<Func<It.IsAnyType, Exception, string>>()),
                Times.Once);
        }

        private void VerifyLogInformation(string message, object arg)
        {
            _mockLogger.Verify(
                x => x.Log(
                    LogLevel.Information,
                    It.IsAny<EventId>(),
                    It.Is<It.IsAnyType>((v, t) => v.ToString().Contains("Getting recent customers for last") && v.ToString().Contains("days")),
                    It.IsAny<Exception>(),
                    It.IsAny<Func<It.IsAnyType, Exception, string>>()),
                Times.Once);
        }

        private void VerifyLogError(string message)
        {
            _mockLogger.Verify(
                x => x.Log(
                    LogLevel.Error,
                    It.IsAny<EventId>(),
                    It.Is<It.IsAnyType>((v, t) => v.ToString().Contains(message)),
                    It.IsAny<Exception>(),
                    It.IsAny<Func<It.IsAnyType, Exception, string>>()),
                Times.Once);
        }
    }
}
