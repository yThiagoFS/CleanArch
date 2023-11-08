using CleanArch.Domain.Validation;
using CleanArch.Domain.ValueObjects;

namespace CleanArch.Domain.Entities
{
    public sealed class Product : Entity
    {
        public Product(string name, string description
            , decimal price, int stock, string image)
            => this.ValidateDomain(name, description, price, stock, image);

        public Product(int id, string name, string description
            , decimal price, int stock, string image)
        {
            this.ValidateId(id);
            this.ValidateDomain(name, description, price, stock, image);
        }

        public Name Name { get; private set; }

        public string Description { get; private set; }

        public decimal Price { get; private set; }

        public int Stock { get; private set; }

        public string Image { get; private set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }

        public void Update(string name, string description
            , decimal price, int stock, string image, int categoryId)
        {
            this.ValidateDomain(name, description, price, stock, image);
            this.CategoryId = categoryId;
        }

        private void ValidateDomain(string name, string description, decimal price, int stock, string image)
        {
            DomainExceptionValidation.When(name.Length > 60
                , "Name is too large. Maximum 60 characters.");

            DomainExceptionValidation.When(string.IsNullOrEmpty(description)
                , "Invalid description.");

            DomainExceptionValidation.When(string.IsNullOrEmpty(image)
                , "Invalid image.");

            DomainExceptionValidation.When(description.Length < 5
                , "Description is too short. Minimum 5 characters.");

            DomainExceptionValidation.When(description.Length > 255
                , "Description is too large. Maximum 255 characters.");

            DomainExceptionValidation.When(price < 0
                , "Invalid price. Price should be bigger than 0.");

            DomainExceptionValidation.When(stock < 0
                , "Invalid stock. Stock cannot be negative.");

            this.Name = name;
            this.Description = description;
            this.Price = price;
            this.Stock = stock;
            this.Image = image;
        }
    }
}
