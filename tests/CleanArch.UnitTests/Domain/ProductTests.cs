using CleanArch.Domain.Validation;
using CleanArch.UnitTests.Builders;
using FluentAssertions;

namespace CleanArch.UnitTests.Domain
{
    public class ProductTests
    {
        [Theory]
        [InlineData("ab")]
        [InlineData("bc")]
        [InlineData("db")]
        public void ShouldReturnAnInvalidNameException(string name)
        {
            var message = "Name is too short. Minimum 3 characters.";

            var productBuilder = new ProductBuilder();

            productBuilder.Invoking(m => m.Build(name: name))
                .Should()
                .Throw<ValueObjectExceptionValidation>()
                .WithMessage(message);
        }
    }
}
