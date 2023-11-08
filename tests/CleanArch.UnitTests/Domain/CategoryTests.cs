using CleanArch.Domain.Validation;
using CleanArch.UnitTests.Builders;
using CleanArch.UnitTests.Utils;
using FluentAssertions;

namespace CleanArch.UnitTests.Domain
{
    public class CategoryTests
    {
        [Fact()]
        public void ShouldCreateAValidCateogry()
        {
            var productBuilder = new CategoryBuilder();

            var category = productBuilder.Build();
        }

        [Theory]
        [InlineData("ab")]
        [InlineData("bc")]
        [InlineData("db")]
        public void ShouldThrowNameExceptionWithIsTooShortMessage(string name)
        {
            var message = "Name is too short. Minimum 3 characters.";

            var productBuilder = new CategoryBuilder();

            productBuilder.Invoking(m => m.Build(name: name))
                .Should()
                .Throw<ValueObjectExceptionValidation>()
                .WithMessage(message);
        }

        [Theory]
        [InlineData(65)]
        [InlineData(95)]
        [InlineData(73)]
        public void ShouldThrowNameExceptionWithIsTooLargeMessage(int nameLength)
        {
            var message = "Name is too large. Maximum 60 characters.";

            var productBuilder = new CategoryBuilder();

            productBuilder.Invoking(m => m.Build(name: GenerateRandomText.Generate(nameLength)))
                .Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage(message);
        }
    }
}
