using Bogus;

namespace SauceDemo.TestData
{
    public class UserDataGenerator
    {
        public static Faker<CustomerInfo> CustomerInfoFaker => new Faker<CustomerInfo>()
            .RuleFor(c => c.FirstName, f => f.Name.FirstName())
            .RuleFor(c => c.LastName, f => f.Name.LastName())
            .RuleFor(c => c.ZipCode, f => f.Address.ZipCode());

        public class CustomerInfo
        {
            public required string FirstName { get; set; }
            public required string LastName { get; set; }
            public required string ZipCode { get; set; }
        }
    }
}
