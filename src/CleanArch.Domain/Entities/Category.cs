using CleanArch.Domain.Validation;
using CleanArch.Domain.ValueObjects;

namespace CleanArch.Domain.Entities
{
    public sealed class Category : Entity
    {
        public Category(string name)
        {
            ValidateDomain(name);
        }

        public Category(long id, string name)
        {
            ValidateId(id);
            ValidateDomain(name);
        }

        public Name Name { get; private set; }

        public ICollection<Product> Products { get; set; }

        public void Update(string name) => ValidateDomain(name);

        private void ValidateDomain(string name)
        {
            DomainExceptionValidation.When(name.Length > 60
            , "Name is too large. Maximum 60 characters");

            this.Name = name;
        }
    }
} 
