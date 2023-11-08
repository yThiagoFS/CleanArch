using Bogus;
using CleanArch.Domain.Entities;

namespace CleanArch.UnitTests.Builders
{
    public class CategoryBuilder
    {
        public Category Build(string? name = null)
            => new Faker<Category>()
                .CustomInstantiator(c => new Category(name ?? c.Name.FullName()));
    }
}
