using Microsoft.EntityFrameworkCore;
using Shop_DAL.Models;

namespace Shop_DAL
{
    public static class DataSeeder
    {
        public static void SeedData(ModelBuilder modelBuilder)
        {
            var custIds = new[]
            {
                Guid.Parse("419b5de9-a67c-4523-9b42-c602ad4e95e0"),
                Guid.Parse("89c1335a-fe9d-4dfd-90e7-a2daf29c0507"),
                Guid.Parse("df906552-8cc2-4caf-8ee1-d1bbc3312c5e"),
                Guid.Parse("0a56660f-5664-4fd4-989c-6d5dbe898151"),
                Guid.Parse("b4a3057c-2010-4551-9fdc-3a39757a2628"),
                Guid.Parse("71968629-657a-4065-9838-31f810440795"),
                Guid.Parse("dcae2a80-ca6c-40c1-95f2-4f34b6c0e910"),
                Guid.Parse("b65f64a4-7183-4405-afc6-12e274044ad3"),
            };

            var prodIds = new[]
            {
                Guid.Parse("5a8963f2-6ad7-4d55-b270-6270d3c0cb8a"),
                Guid.Parse("d52350b9-6dab-4b03-82a5-ce07f02b4a20"),
                Guid.Parse("cb640ce5-071e-4df7-bfc9-68864ada6fc8"),
                Guid.Parse("9a59d2e0-f9d1-4a7a-86e1-6a4d8f6d2a10"),
                Guid.Parse("7b62f3b7-2f72-4a0a-8d44-0a4a9320b6d4"),
                Guid.Parse("bdf7eab0-3d2c-4c5d-8e2f-3a3b0f1a1c0e"),
                Guid.Parse("df3fe2a8-4b92-41b4-9a03-5e0f6a7bcd01"),
                Guid.Parse("a4c0db5f-b1b8-459f-9a0d-49ab1b5a7a2f"),
                Guid.Parse("ac7a0d3a-0a5e-4a55-8bca-bb6a7d8e9f33"),
                Guid.Parse("f0d1e2c3-b4a5-4c6d-8e9f-0a1b2c3d4e5f"),
            };

            var orderIds = new[]
            {
                Guid.Parse("23ba0b1b-a877-4739-8230-77e325fa7cab"),
                Guid.Parse("b45ea5b4-625e-406f-8cd4-aaa5434701d5"),
                Guid.Parse("1f7edc08-35cc-4b1d-a3d4-3a14f3b2a7f0"),
                Guid.Parse("3b8a6a98-0d9f-4d7b-9440-3f2b69f2c1b0"),
                Guid.Parse("a1d2c3b4-5678-49ab-8cde-0123456789ab"),
                Guid.Parse("2c3d4e5f-6a7b-4c8d-9e0f-1a2b3c4d5e6f"),
                Guid.Parse("6d5c4b3a-2f1e-4d0c-9b8a-7f6e5d4c3b2a"),
                Guid.Parse("8e7d6c5b-4a3f-2e1d-0c9b-8a7f6e5d4c3b"),
                Guid.Parse("9a8b7c6d-5e4f-3a2b-1c0d-9e8f7a6b5c4d"),
                Guid.Parse("0f1e2d3c-4b5a-6978-8a9b-bc0d1e2f3a4b"),
            };

            modelBuilder.Entity<Customer>().HasData(new[]
            {
                new Customer { Id = custIds[0], LastName = "Ivanov", FirstName = "Ivan", MiddleName = "Petrovich", DateOfBirth = new DateTime(1988, 3, 22), RegistrationDate = new DateTime(2024, 6, 15) },
                new Customer { Id = custIds[1], LastName = "Petrenko", FirstName = "Olena", MiddleName = "Mykolayivna", DateOfBirth = new DateTime(1988, 3, 22), RegistrationDate = new DateTime(2024, 7, 1) },
                new Customer { Id = custIds[2], LastName = "Shevchenko", FirstName = "Taras", MiddleName = "Hryhorovych", DateOfBirth = new DateTime(1988, 3, 22), RegistrationDate = new DateTime(2024, 7, 20) },
                new Customer { Id = custIds[3], LastName = "Koval", FirstName = "Oksana", MiddleName = "Serhiivna", DateOfBirth = new DateTime(1992, 9, 14), RegistrationDate = new DateTime(2024, 8, 2) },
                new Customer { Id = custIds[4], LastName = "Bondar", FirstName = "Andriy", MiddleName = "Stepanovych", DateOfBirth = new DateTime(1985, 11, 30), RegistrationDate = new DateTime(2024, 8, 18) },
                new Customer { Id = custIds[5], LastName = "Melnyk", FirstName = "Iryna", MiddleName = "Volodymyrivna", DateOfBirth = new DateTime(1993, 2, 9), RegistrationDate = new DateTime(2024, 9, 5) },
                new Customer { Id = custIds[6], LastName = "Savchenko", FirstName = "Dmytro", MiddleName = "Oleksandrovych", DateOfBirth = new DateTime(1991, 12, 2), RegistrationDate = new DateTime(2024, 9, 21) },
                new Customer { Id = custIds[7], LastName = "Horodetska", FirstName = "Natalia", MiddleName = "Yuriyivna", DateOfBirth = new DateTime(1996, 4, 17), RegistrationDate = new DateTime(2024, 10, 1) },
            });

            modelBuilder.Entity<Product>().HasData(new[]
            {
                new Product { Id = prodIds[0], Name = "Laptop 14\"", Category = "Electronics", ArticleNumber = "ART-1001", Price = 899.99m },
                new Product { Id = prodIds[1], Name = "Mechanical Keyboard", Category = "Peripherals", ArticleNumber = "ART-1002", Price = 129.50m },
                new Product { Id = prodIds[2], Name = "Wireless Mouse", Category = "Peripherals", ArticleNumber = "ART-1003", Price = 39.90m },
                new Product { Id = prodIds[3], Name = "27\" Monitor", Category = "Displays", ArticleNumber = "ART-1004", Price = 299.00m },
                new Product { Id = prodIds[4], Name = "USB-C Hub", Category = "Accessories", ArticleNumber = "ART-1005", Price = 49.99m },
                new Product { Id = prodIds[5], Name = "External SSD 1TB", Category = "Storage", ArticleNumber = "ART-1006", Price = 119.95m },
                new Product { Id = prodIds[6], Name = "Gaming Chair", Category = "Furniture", ArticleNumber = "ART-1007", Price = 259.00m },
                new Product { Id = prodIds[7], Name = "Webcam 1080p", Category = "Peripherals", ArticleNumber = "ART-1008", Price = 79.49m },
                new Product { Id = prodIds[8], Name = "Noise-canceling Headphones", Category = "Audio", ArticleNumber = "ART-1009", Price = 199.99m },
                new Product { Id = prodIds[9], Name = "Desk Lamp", Category = "Lighting", ArticleNumber = "ART-1010", Price = 24.75m },
            });

            modelBuilder.Entity<Order>().HasData(new[]
            {
                new Order { Id = orderIds[0], Number = "ORD-2025-0001", OrderDate = new DateTime(2025, 8, 5),  CustomerId = custIds[0], TotalAmount = 979.79m },
                new Order { Id = orderIds[1], Number = "ORD-2025-0002", OrderDate = new DateTime(2025, 8, 8),  CustomerId = custIds[1], TotalAmount = 228.99m },
                new Order { Id = orderIds[2], Number = "ORD-2025-0003", OrderDate = new DateTime(2025, 9, 12), CustomerId = custIds[2], TotalAmount = 598.00m },
                new Order { Id = orderIds[3], Number = "ORD-2025-0004", OrderDate = new DateTime(2025, 9, 15), CustomerId = custIds[3], TotalAmount = 239.34m },
                new Order { Id = orderIds[4], Number = "ORD-2025-0005", OrderDate = new DateTime(2025, 9, 18), CustomerId = custIds[4], TotalAmount = 259.00m },
                new Order { Id = orderIds[5], Number = "ORD-2025-0006", OrderDate = new DateTime(2025, 9, 23), CustomerId = custIds[5], TotalAmount = 329.49m },
                new Order { Id = orderIds[6], Number = "ORD-2025-0007", OrderDate = new DateTime(2025, 8, 25), CustomerId = custIds[6], TotalAmount = 174.72m },
                new Order { Id = orderIds[7], Number = "ORD-2025-0008", OrderDate = new DateTime(2025, 8, 28), CustomerId = custIds[7], TotalAmount = 238.78m },
                new Order { Id = orderIds[8], Number = "ORD-2025-0009", OrderDate = new DateTime(2025, 9, 2),  CustomerId = custIds[0], TotalAmount = 548.98m },
                new Order { Id = orderIds[9], Number = "ORD-2025-0010", OrderDate = new DateTime(2025, 9, 6),  CustomerId = custIds[2], TotalAmount = 1189.34m },
            });

            modelBuilder.Entity<OrderItem>().HasData(new[]
            {
                new OrderItem { Id = Guid.Parse("2a2bdad3-197e-4fb0-9f2c-a80cd0032df5"), OrderId = orderIds[0], ProductId = prodIds[0], Quantity = 1, UnitPrice = 899.99m },
                new OrderItem { Id = Guid.Parse("8f5a7d7e-34b6-4e16-8292-653ce8aae41e"), OrderId = orderIds[0], ProductId = prodIds[2], Quantity = 2, UnitPrice = 39.90m },

                new OrderItem { Id = Guid.Parse("18136114-5a9b-4b4c-90ab-5ab43280ce1a"), OrderId = orderIds[1], ProductId = prodIds[1], Quantity = 1, UnitPrice = 129.50m },
                new OrderItem { Id = Guid.Parse("70ec66f6-9b31-4c1f-95f1-42a7fc467e06"), OrderId = orderIds[1], ProductId = prodIds[4], Quantity = 1, UnitPrice = 49.99m },
                new OrderItem { Id = Guid.Parse("39d298a2-506e-4ed7-beee-3f2709114406"), OrderId = orderIds[1], ProductId = prodIds[9], Quantity = 2, UnitPrice = 24.75m },

                new OrderItem { Id = Guid.Parse("5f2a3b4c-6d7e-4890-a1b2-c3d4e5f6a7b8"), OrderId = orderIds[2], ProductId = prodIds[3], Quantity = 2, UnitPrice = 299.00m },

                new OrderItem { Id = Guid.Parse("6a7b8c9d-0e1f-4a2b-b3c4-d5e6f7a8b9c0"), OrderId = orderIds[3], ProductId = prodIds[5], Quantity = 1, UnitPrice = 119.95m },
                new OrderItem { Id = Guid.Parse("7b8c9d0e-1f2a-4b3c-c4d5-e6f7a8b9c0d1"), OrderId = orderIds[3], ProductId = prodIds[2], Quantity = 1, UnitPrice = 39.90m },
                new OrderItem { Id = Guid.Parse("8c9d0e1f-2a3b-4c4d-d5e6-f7a8b9c0d1e2"), OrderId = orderIds[3], ProductId = prodIds[7], Quantity = 1, UnitPrice = 79.49m },

                new OrderItem { Id = Guid.Parse("9d0e1f2a-3b4c-4d5e-e6f7-a8b9c0d1e2f3"), OrderId = orderIds[4], ProductId = prodIds[6], Quantity = 1, UnitPrice = 259.00m },

                new OrderItem { Id = Guid.Parse("0e1f2a3b-4c5d-4e6f-f7a8-b9c0d1e2f3a4"), OrderId = orderIds[5], ProductId = prodIds[8], Quantity = 1, UnitPrice = 199.99m },
                new OrderItem { Id = Guid.Parse("1f2a3b4c-5d6e-4f7a-a8b9-c0d1e2f3a4b5"), OrderId = orderIds[5], ProductId = prodIds[1], Quantity = 1, UnitPrice = 129.50m },

                new OrderItem { Id = Guid.Parse("2a3b4c5d-6e7f-4a8b-b9c0-d1e2f3a4b5c6"), OrderId = orderIds[6], ProductId = prodIds[4], Quantity = 3, UnitPrice = 49.99m },
                new OrderItem { Id = Guid.Parse("3b4c5d6e-7f8a-4b9c-c0d1-e2f3a4b5c6d7"), OrderId = orderIds[6], ProductId = prodIds[9], Quantity = 1, UnitPrice = 24.75m },

                new OrderItem { Id = Guid.Parse("4c5d6e7f-8a9b-4c0d-d1e2-f3a4b5c6d7e8"), OrderId = orderIds[7], ProductId = prodIds[7], Quantity = 2, UnitPrice = 79.49m },
                new OrderItem { Id = Guid.Parse("5d6e7f8a-9b0c-4d1e-e2f3-a4b5c6d7e8f9"), OrderId = orderIds[7], ProductId = prodIds[2], Quantity = 2, UnitPrice = 39.90m },

                new OrderItem { Id = Guid.Parse("6e7f8a9b-0c1d-4e2f-f3a4-b5c6d7e8f9a0"), OrderId = orderIds[8], ProductId = prodIds[3], Quantity = 1, UnitPrice = 299.00m },
                new OrderItem { Id = Guid.Parse("7f8a9b0c-1d2e-4f3a-a4b5-c6d7e8f9a0b1"), OrderId = orderIds[8], ProductId = prodIds[8], Quantity = 1, UnitPrice = 199.99m },
                new OrderItem { Id = Guid.Parse("8a9b0c1d-2e3f-4a4b-b5c6-d7e8f9a0b1c2"), OrderId = orderIds[8], ProductId = prodIds[4], Quantity = 1, UnitPrice = 49.99m },

                new OrderItem { Id = Guid.Parse("9b0c1d2e-3f4a-4b5c-c6d7-e8f9a0b1c2d3"), OrderId = orderIds[9], ProductId = prodIds[0], Quantity = 1, UnitPrice = 899.99m },
                new OrderItem { Id = Guid.Parse("0c1d2e3f-4a5b-4c6d-d7e8-f9a0b1c2d3e4"), OrderId = orderIds[9], ProductId = prodIds[5], Quantity = 1, UnitPrice = 119.95m },
                new OrderItem { Id = Guid.Parse("1d2e3f4a-5b6c-4d7e-e8f9-a0b1c2d3e4f5"), OrderId = orderIds[9], ProductId = prodIds[1], Quantity = 1, UnitPrice = 129.50m },
                new OrderItem { Id = Guid.Parse("2e3f4a5b-6c7d-4e8f-f9a0-b1c2d3e4f506"), OrderId = orderIds[9], ProductId = prodIds[2], Quantity = 1, UnitPrice = 39.90m },
            });
        }
    }
}
