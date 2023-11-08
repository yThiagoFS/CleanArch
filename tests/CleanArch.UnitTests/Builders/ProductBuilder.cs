using Bogus;
using CleanArch.Domain.Entities;

namespace CleanArch.UnitTests.Builders
{
    public class ProductBuilder
    {
        public Product Build(
            string? name = null
            , string? description = null
            , decimal? price = null
            , int? stock = null
            , string? image = null)
            => new Faker<Product>()
                .CustomInstantiator(f => new Product(
                    name ?? f.Name.FirstName()
                    , description ?? f.Lorem.Letter(f.Random.Int(0, 255))
                    , price ?? f.Random.Decimal()
                    , stock ?? f.Random.Int(0)
                    , image ?? Bogus.DataSets.LoremPixelCategory.Random));
    }
}
