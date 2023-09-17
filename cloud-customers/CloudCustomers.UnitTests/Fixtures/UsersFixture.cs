using CloudCustomers.API.Models;

namespace CloudCustomers.UnitTests.Fixtures
{
    public static class UserFixture
    {
        public static List<User> GetTestUsers() =>
            new()
            {
                new User
                {
                    Name = "Test User 1",
                    Email = "test.user.1@productivedev.com",
                    Address = new Address
                    {
                        Street = "123 Market St",
                        City = "Somewhere",
                        ZipCode = "213124"
                    }
                },
                new User
                {
                    Name = "Test User 2",
                    Email = "test.user.2@productivedev.com",
                    Address = new Address
                    {
                        Street = "900 Main St",
                        City = "Somewhere",
                        ZipCode = "213124"
                    }
                },
                new User
                {
                    Name = "Test User 3",
                    Email = "test.user.3@productivedev.com",
                    Address = new Address
                    {
                        Street = "108 Maple St",
                        City = "Somewhere",
                        ZipCode = "213124"
                    }
                }
            };
    }
}
