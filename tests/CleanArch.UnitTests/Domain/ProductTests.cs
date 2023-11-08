using CleanArch.Domain.Entities;
using CleanArch.Domain.Validation;
using CleanArch.UnitTests.Builders;
using CleanArch.UnitTests.Utils;
using FluentAssertions;
using System.Text;

namespace CleanArch.UnitTests.Domain
{
    public class ProductTests
    {
        [Theory]
        [InlineData("ab")]
        [InlineData("bc")]
        [InlineData("db")]
        public void ShouldThrowDomainExceptionWithIsTooShortMessage(string name)
        {
            var message = "Name is too short. Minimum 3 characters.";

            var productBuilder = new ProductBuilder();

            productBuilder.Invoking(m => m.Build(name: name))
                .Should()
                .Throw<ValueObjectExceptionValidation>()
                .WithMessage(message);
        }

        [Theory]
        [InlineData(65)]
        [InlineData(95)]
        [InlineData(73)]
        public void ShouldThrowDomainExceptionWithIsTooLargeMessage(int nameLength)
        {
            var message = "Name is too large. Maximum 60 characters.";

            var productBuilder = new ProductBuilder();

            productBuilder.Invoking(m => m.Build(name: GenerateRandomText.Generate(nameLength)))
                .Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage(message);
        }

        [Fact]
        public void ShouldThrowDomainExceptionWithInvalidDescriptionMessage()
        {
            var message = "Invalid description.";

            var productBuilder = new ProductBuilder();

            productBuilder.Invoking(m => m.Build(description: string.Empty))
                .Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage(message);
        }

        [Fact]
        public void ShouldThrowDomainExceptionWithInvalidImageMessage()
        {
            var message = "Invalid image.";

            var productBuilder = new ProductBuilder();

            productBuilder.Invoking(m => m.Build(image: string.Empty))
                .Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage(message);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        public void ShouldThrowDomainExceptionWithDescriptionTooShortMessage(int descriptionLength)
        {
            var message = "Description is too short. Minimum 5 characters.";

            var productBuilder = new ProductBuilder();

            productBuilder.Invoking(m => m.Build(description: GenerateRandomText.Generate(descriptionLength)))
                .Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage(message);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(-2)]
        [InlineData(-3)]
        [InlineData(-4)]
        public void ShouldThrowDomainExceptionWithInvalidPriceMessage(int price)
        {
            var message = "Invalid price. Price should be bigger than 0.";

            var productBuilder = new ProductBuilder();

            productBuilder.Invoking(m => m.Build(price:price))
                .Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage(message);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(-2)]
        [InlineData(-3)]
        [InlineData(-4)]
        public void ShouldThrowDomainExceptionWithInvalidStockMessage(int stock)
        {
            var message = "Invalid stock. Stock cannot be negative.";

            var productBuilder = new ProductBuilder();

            productBuilder.Invoking(m => m.Build(stock: stock))
                .Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage(message);
        }
    }
}
