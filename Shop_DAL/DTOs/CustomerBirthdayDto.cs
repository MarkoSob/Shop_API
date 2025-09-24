using System;
namespace Shop_DAL.DTOs
{
    public class CustomerBirthdayDto
    {
        public Guid Id { get; set; }
        public string FullName { get; set; } = string.Empty;
    }
}
