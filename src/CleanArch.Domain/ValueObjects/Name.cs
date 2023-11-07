using CleanArch.Domain.Validation;
using System.Xml.Linq;

namespace CleanArch.Domain.ValueObjects
{
    public sealed class Name : ValueObject
    {
        public Name(string value)
            => Validate(value);

        public string Value { get; private set; } = string.Empty;

        public static implicit operator string(Name name) => name.Value;

        public static implicit operator Name(string value) => new(value);

        public override string ToString() => Value;

        private void Validate(string value)
        {
            ValueObjectExceptionValidation.When(string.IsNullOrEmpty(value)
            , "Name is required.");

            ValueObjectExceptionValidation.When(value.Length < 3
            , "Name is too short. Minimum 3 characters.");

            this.Value = value;
        }
    }
}
